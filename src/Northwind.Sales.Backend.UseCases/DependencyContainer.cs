namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthwindUseCasesServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
        services.AddScoped<IModelValidator<CreateOrderDto>, CreateOrderDBValidator>();


        services.AddScoped<IDomainEventHandler<SpecialOrderCreatedEvent>, SendEmailWhenSpecialOrderCreatedEventHandler>();

        return services;
    }
}
