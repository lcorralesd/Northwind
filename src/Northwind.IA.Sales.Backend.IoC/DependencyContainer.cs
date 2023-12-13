using Northwind.IA.Sales.Gateways.EFCore.Options;
using Northwind.IA.Sales.Gateways.Smtp.Gateways;
using Northwind.IA.Sales.Gateways.Smtp.Gateways.Options;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthwindSalesServices(this IServiceCollection services,
        Action<DbOptions> configureDbOptions, Action<SmtpOptions> configureSmtpOptions)
    {
        services
            .AddNorthwindValidators()
            .AddBusinessObjectsServices()
            .AddNorthwindUseCasesServices()
            .AddRepositories(configureDbOptions)
            .AddPresenters()
            .AddMailServices(configureSmtpOptions);

        return services;
    }
}
