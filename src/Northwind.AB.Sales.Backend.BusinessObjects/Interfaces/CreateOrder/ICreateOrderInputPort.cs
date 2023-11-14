namespace Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;
public interface ICreateOrderInputPort
{
    ValueTask Handle(CreateOrderDto createOrderDto);
}
