namespace Northwind.IA.Sales.Gateways.EFCore.Contexts;
internal class NorthwindContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=NorthwindDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Entities.OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
}
