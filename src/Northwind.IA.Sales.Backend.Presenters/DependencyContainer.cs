using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;
using Northwind.IA.Sales.Backend.Presenters;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();

        return services;
    }
}
