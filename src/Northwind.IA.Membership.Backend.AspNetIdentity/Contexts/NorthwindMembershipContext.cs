namespace Northwind.IA.Membership.Backend.AspNetIdentity.Contexts;
internal class NorthwindMembershipContext(IOptions<MembershipOptions> options)
    : IdentityDbContext<NorthwindUser>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options.Value.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
