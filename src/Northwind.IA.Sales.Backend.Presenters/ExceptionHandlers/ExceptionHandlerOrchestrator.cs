namespace Northwind.IA.Sales.Backend.Presenters.ExceptionHandlers;
internal class ExceptionHandlerOrchestrator
{
    readonly Dictionary<Type, object> Handlers;
    readonly ILogger<ExceptionHandlerOrchestrator> _logger;

    public ExceptionHandlerOrchestrator(
        [FromKeyedServices(typeof(IExceptionHandler<>))]
        IEnumerable<object> handlers,
        ILogger<ExceptionHandlerOrchestrator> logger)
    {
        Handlers = new();
        foreach (var handler in handlers)
        {
            Type exceptionType = handler.GetType().GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>))
                .GetGenericArguments()[0];

            Handlers.TryAdd(exceptionType, handler);
        }
        _logger = logger;
    }

    ProblemDetails ToProblemDetails(Exception exception)
    {
        ProblemDetails details;

        if(Handlers.TryGetValue(exception.GetType(),out object handler))
        {
            Type handlerType = handler.GetType();

            details = (ProblemDetails)handlerType.GetMethod(nameof(IExceptionHandler<Exception>.Handle))
                .Invoke(handler, new object[] { exception });
        }
        else
        {
            details = new ProblemDetails();
            details.Status = StatusCodes.Status500InternalServerError;
            details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
            details.Title = ExceptionMessages.UnhandledExceptionTitle;
            details.Detail = ExceptionMessages.UnhandledExceptionDetail;
            details.Instance = $"{nameof(ProblemDetails)}/{exception.GetType()}";

            _logger.LogError(exception, ExceptionMessages.UnhandledExceptionTitle);
        }

        return details;
    }

    public async Task HandleException(HttpContext context)
    {
        IExceptionHandlerFeature exceptionDetail = 
            context.Features.Get<IExceptionHandlerFeature>();

        Exception exception = exceptionDetail.Error;

        if(exception != null)
        {
            var problemDetails = ToProblemDetails(exception);
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problemDetails.Status.Value;

            var stream = context.Response.Body;
            await JsonSerializer.SerializeAsync(stream, problemDetails);

        }
    }
}
