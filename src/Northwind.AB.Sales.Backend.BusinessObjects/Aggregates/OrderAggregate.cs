namespace Northwind.AB.Sales.Backend.BusinessObjects.Aggregates;
public class OrderAggregate : Order
{
    readonly List<OrderDetail> _orderDetails = new();

    public IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails;

    public void AddDetail(int productId, decimal unitPrice, short quantity)
    {
        var existingOrderDetail = _orderDetails.FirstOrDefault(o => o.ProductId == productId);

        if(existingOrderDetail != default)
        {
            quantity += existingOrderDetail.Quantity;
            _orderDetails.Remove(existingOrderDetail);
        }

        _orderDetails.Add(
            new OrderDetail(productId, unitPrice, quantity));
    }

    public static OrderAggregate From(CreateOrderDto orderDto)
    {
        OrderAggregate order = new()
        {
            CustomerId = orderDto.CustomerId,
            ShipAddress = orderDto.ShipAddress,
            ShipCity = orderDto.ShipCity,
            ShipCountry = orderDto.ShipCountry,
            ShipPostalCode = orderDto.ShipPostalCode,
        };

        foreach (var item in orderDto.OrderDetails)
        {
            order.AddDetail(item.ProductId, item.UnitPrice, item.Quantity);
        }

        return order;
    }
}
