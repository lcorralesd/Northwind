namespace Northwind.IA.Sales.Gateways.EFCore.Contexts;
public class NorthwindSalesContext : DbContext
{
    readonly IOptions<DbOptions> _options;

    public NorthwindSalesContext(IOptions<DbOptions> options) => _options = options;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_options.Value.ConnectionString);
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Entities.OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
