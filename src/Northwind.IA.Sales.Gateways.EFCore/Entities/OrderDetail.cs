using Northwind.AB.Sales.Backend.BusinessObjects.POCOs;

namespace Northwind.IA.Sales.Gateways.EFCore.Entities;
public class OrderDetail
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
}
