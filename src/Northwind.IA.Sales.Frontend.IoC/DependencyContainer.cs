namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthwindSalesServices(
        this IServiceCollection services,
        Action<HttpClient> configureClient)
    {
        services
            .AddNorthwindValidators()
            .AddWebApiGateways(configureClient)
            .AddViewsServices();

        return services;
    }
}
