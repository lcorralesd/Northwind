namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddMemebershipValidators(this IServiceCollection services)
    {
        services.AddScoped<IModelValidator<UserRegistrationDTO>, UserRegistrationDTOValidator>();
        services.AddScoped<IModelValidator<UserCredentialsDTO>, UserCredentialsDTOValidator>();

        services.AddDefaultModelValidatorServices();

        return services;
    }
}
