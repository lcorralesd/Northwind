﻿namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipUseCasesServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRegistrationInputPort, UserRegistrationInteractor>();
        services.AddScoped<IUserLoginInputPort, UserLoginInteractor>();

        return services;
    }
}
