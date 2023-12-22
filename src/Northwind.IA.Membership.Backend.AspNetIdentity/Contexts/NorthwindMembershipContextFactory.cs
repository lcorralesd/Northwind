using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Northwind.IA.Membership.Backend.AspNetIdentity.Options;

namespace Northwind.IA.Membership.Backend.AspNetIdentity.Contexts;
internal class NorthwindMembershipContextFactory : IDesignTimeDbContextFactory<NorthwindMembershipContext>
{
    public NorthwindMembershipContext CreateDbContext(string[] args)
    {
        IOptions<MembershipOptions> options =
            Microsoft.Extensions.Options.Options.Create(
                new MembershipOptions
                {
                    ConnectionString = "Server=(localdb)\\MSSQLLocaldb;Database=NorthwindUsersDb"
                });

        return new NorthwindMembershipContext(options);
    }
}
