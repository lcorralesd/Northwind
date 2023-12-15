﻿namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddBusinessObjectsServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IDomainEventHub<>), typeof(DomainEventHub<>));
        services.AddScoped<IDomainLogger, DomainLogger>();
        services.AddTransient<IDomainTransaction, DomainTransaction>();
        services.AddHttpContextAccessor();
        services.AddScoped<IUserService, UserServiceFake>();

        return services;
    }
}
