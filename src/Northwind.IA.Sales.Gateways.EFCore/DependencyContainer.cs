namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services,
        Action<DbOptions> configureOptions)
    {
        services.Configure(configureOptions);
        services.AddDbContext<NorthwindSalesContext>();

        services.AddScoped<ICommandSalesRepository, CommandSalesRepository>();
        services.AddScoped<IQuerySalesRepository, QuerySalesRepository>();

        return services;
    }
}
