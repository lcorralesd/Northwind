namespace Northwind.AB.Sales.Backend.BusinessObjects.ValueObjects;
public class ProductUnitsInStock
{
    public int ProductId { get; set; }
    public int UnitsInStock { get; set; }

    public ProductUnitsInStock(int productId, int unitsInStock)
    {
        ProductId = productId;
        UnitsInStock = unitsInStock;
    }
}
