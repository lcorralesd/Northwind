namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddAspNetIdentityMembership(this IServiceCollection services,
        Action<MembershipOptions> configureMembershipOptions)
    {
        services.AddDbContext<NorthwindMembershipContext>();
        services.AddIdentityCore<NorthwindUser>()
            .AddEntityFrameworkStores<NorthwindMembershipContext>();

        services.AddScoped<IMembershipService, MembershipService>();

        services.AddOptions<MembershipOptions>()
            .Configure(configureMembershipOptions);

        return services;
    }
}
