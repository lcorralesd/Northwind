namespace Northwind.IA.Sales.Gateways.EFCore.Contexts;
internal class NorthwindDomainLogsContext(IOptions<DbOptions> options) : DbContext
{
    public DbSet<Entities.DomainLog> DomainLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options.Value.DomainLogsConnectionString);
    }
}
