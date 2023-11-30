using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();

        services.AddKeyedSingleton<object, ValidationExceptionHandler>(typeof(IExceptionHandler<>));

        services.AddKeyedSingleton<object, UnitOfWorkExceptionHandler>(typeof(IExceptionHandler<>));

        services.AddSingleton<ExceptionHandlerOrchestrator>();

        return services;
    }

    public static WebApplication UseCustomExceptionHandlers(this WebApplication app)
    {
        var orchestrator = app.Services.GetRequiredService<ExceptionHandlerOrchestrator>();

        app.UseExceptionHandler(buider =>
        {
            buider.Run(orchestrator.HandleException);
        });

        return app;
    }
}
