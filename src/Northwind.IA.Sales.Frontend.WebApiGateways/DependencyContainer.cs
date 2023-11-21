using Northwind.AB.Sales.Frontend.BusinessObjects.Interfaces;
using Northwind.IA.Sales.Frontend.WebApiGateways;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddWebApiGateways(this IServiceCollection services,
        Action<HttpClient> configureClient)
    {
        services.AddHttpClient<ICreateOrderGateway, CreateOrderGateway>(configureClient);

        return services;
    }
}
