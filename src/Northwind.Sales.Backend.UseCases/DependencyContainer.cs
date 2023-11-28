using Northwind.EB.Sales.Entities.Validators.Interfaces.Common;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthwindUseCasesServices(this IServiceCollection services)
    {
        services.AddScoped<IModelValidator<CreateOrderDto>, CreateOrderDBValidator>();

        services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();

        return services;
    }
}
