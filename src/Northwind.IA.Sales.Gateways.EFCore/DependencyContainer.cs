namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services,
        Action<DbOptions> configureOptions)
    {
        services.Configure(configureOptions);
        services.AddDbContext<NorthwindSalesContext>();
        services.AddDbContext<NorthwindDomainLogsContext>();

        services.AddScoped<ICommandSalesRepository, CommandSalesRepository>();
        services.AddScoped<IQuerySalesRepository, QuerySalesRepository>();
        services.AddScoped<IDomaiLogsRepository, DomainLogsRepository>();

        return services;
    }
}
