namespace Northwind.EB.Sales.Entities.DTOs;
public class CreateOrderDetailDto
{
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    public CreateOrderDetailDto(
        int productId,
        decimal unitPrice,
        int quantity)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}
