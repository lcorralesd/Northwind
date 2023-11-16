using Northwind.IA.Sales.Gateways.EFCore.Options;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthwindSalesServices(this IServiceCollection services,
        Action<DbOptions> configureOptions)
    {
        services.AddNorthwindUseCasesServices()
            .AddRepositories(configureOptions)
            .AddPresenters();

        return services;
    }
}
