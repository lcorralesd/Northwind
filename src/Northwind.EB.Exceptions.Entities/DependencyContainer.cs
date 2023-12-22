namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection 
        AddCustomExceptionHandler<ExceptionType, HandlerType>(
        this IServiceCollection services) 
        where ExceptionType : Exception
        where HandlerType : class, IExceptionHandler<ExceptionType>
    {
        services.TryAddOrchestrator();
        services.AddKeyedSingleton<object, HandlerType>(typeof(IExceptionHandler<>));

        return services;
    }

    public static IServiceCollection AddUnhandledExceptionHandler(this IServiceCollection services)
    {
        services.TryAddOrchestrator();
        services.AddExceptionHandler<UnhandledExceptionHandler>();

        return services;
    }

    private static bool AddOrchestrator = true;
    private static IServiceCollection TryAddOrchestrator(this IServiceCollection services)
    {
        if(AddOrchestrator)
        {
            services.AddExceptionHandler<ExceptionHandlerOrchestrator>();
            AddOrchestrator = false;
        }
        return services;
    }

}
