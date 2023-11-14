namespace Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Repositories;
public interface ICommandSalesRepository : IUnitOfWork
{
    ValueTask CreateOrder(OrderAggregate orderAggregate);
}
