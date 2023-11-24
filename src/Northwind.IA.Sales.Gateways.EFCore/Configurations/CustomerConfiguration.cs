namespace Northwind.IA.Sales.Gateways.EFCore.Configurations;
internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasMaxLength(5)
            .IsFixedLength();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(c => c.CurrentBalance)
            .HasPrecision(8, 2);

        builder.HasData(
            new Customer
            {
                Id = "ALFKI",
                Name = "Alfred Futterkis",
                CurrentBalance = 0
            },
            new Customer
            {
                Id = "ANATR",
                Name = "Caceres",
                CurrentBalance = 0
            },
            new Customer
            {
                Id = "ANTON",
                Name = "Antobio Moreno",
                CurrentBalance = 100
            });

    }
}
