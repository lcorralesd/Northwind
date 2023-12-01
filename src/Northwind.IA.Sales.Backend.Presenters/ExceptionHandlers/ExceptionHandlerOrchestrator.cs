namespace Northwind.IA.Sales.Backend.Presenters.ExceptionHandlers;
internal class ExceptionHandlerOrchestrator : IExceptionHandler
{
    readonly Dictionary<Type, object> Handlers;

    public ExceptionHandlerOrchestrator(
        [FromKeyedServices(typeof(IExceptionHandler<>))]
        IEnumerable<object> handlers)
    {
        Handlers = new();
        foreach (var handler in handlers)
        {
            Type exceptionType = handler.GetType().GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>))
                .GetGenericArguments()[0];

            Handlers.TryAdd(exceptionType, handler);
        }
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        bool handled = false;

        if (Handlers.TryGetValue(exception.GetType(), out object handler))
        {
            Type handlerType = handler.GetType();

            ProblemDetails details = (ProblemDetails)handlerType.GetMethod(nameof(IExceptionHandler<Exception>.Handle))
                .Invoke(handler, new object[] { exception });

            await httpContext.WriteProblemDetails(details);
            handled = true;
        }
        return handled;
    }
}
