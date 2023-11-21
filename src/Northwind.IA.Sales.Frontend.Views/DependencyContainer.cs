namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddViewsServices(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderViewModel>();

        return services;
    }
}
