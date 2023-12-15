namespace Northwind.IA.Sales.Gateways.EFCore.Contexts;
internal class NorthwindDomainLogsContextFactory : IDesignTimeDbContextFactory<NorthwindDomainLogsContext>
{
    public NorthwindDomainLogsContext CreateDbContext(string[] args)
    {
        IOptions<DbOptions> options = Microsoft.Extensions.Options.Options.Create(
            new DbOptions
            {
                DomainLogsConnectionString = "Server=(localdb)\\MSSQLLocaldb;Database=NorthwindLogsDb"
            });

        return new NorthwindDomainLogsContext(options);
    }
}
