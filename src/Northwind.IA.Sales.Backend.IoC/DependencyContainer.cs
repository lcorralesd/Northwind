namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthwindSalesServices(this IServiceCollection services,
        Action<DbOptions> configureDbOptions,
        Action<SmtpOptions> configureSmtpOptions,
        Action<MembershipOptions> configureMembershipOptions,
        Action<JwtOptions> configureJwtOptions)
    {
        services
            .AddNorthwindValidators()
            .AddBusinessObjectsServices()
            .AddNorthwindUseCasesServices()
            .AddRepositories(configureDbOptions)
            .AddPresenters()
            .AddMailServices(configureSmtpOptions)
            .AddMemebershipValidators()
            .AddMembershipUseCasesServices()
            .AddMembershipPresenters(configureJwtOptions)
            .AddMemebershipValidators()
            .AddAspNetIdentityMembership(configureMembershipOptions);

        return services;
    }
}
