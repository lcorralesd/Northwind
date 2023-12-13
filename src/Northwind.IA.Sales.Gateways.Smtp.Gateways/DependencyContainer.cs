using Microsoft.Extensions.DependencyInjection;
using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Common;
using Northwind.IA.Sales.Gateways.Smtp.Gateways.Options;

namespace Northwind.IA.Sales.Gateways.Smtp.Gateways;
public static class DependencyContainer
{
    public static IServiceCollection AddMailServices(this IServiceCollection services,
        Action<SmtpOptions> configureSmtpOptions)
    {
        services.AddSingleton<IMailService, MailService>();
        services.AddOptions<SmtpOptions>()
            .Configure(configureSmtpOptions);

        return services;
    }
}
