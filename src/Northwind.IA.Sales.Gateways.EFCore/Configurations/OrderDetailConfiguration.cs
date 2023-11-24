namespace Northwind.IA.Sales.Gateways.EFCore.Configurations;
internal class OrderDetailConfiguration : IEntityTypeConfiguration<Entities.OrderDetail>
{
    public void Configure(EntityTypeBuilder<Entities.OrderDetail> builder)
    {
        builder.HasKey(od => new { od.OrderId, od.ProductId });
        builder.Property(od => od.UnitPrice)
            .HasPrecision(8, 2);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(od => od.ProductId);
    }
}
