namespace Northwind.AB.Sales.Frontend.BusinessObjects.Interfaces;
public interface ICreateOrderGateway
{
    Task<int> CreateOrderAsync(CreateOrderDto order);
}
