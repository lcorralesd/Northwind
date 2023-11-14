namespace Northwind.Sales.Backend.UseCases.Test.Fakes;
internal class RepositoryFake : ICommandSalesRepository
{

    OrderAggregate _orderAggregate;

    public ValueTask CreateOrder(OrderAggregate orderAggregate)
    {
        _orderAggregate = orderAggregate;
        return ValueTask.CompletedTask;
    }

    public ValueTask SaveChanges()
    {
        _orderAggregate.Id = 1;
        return ValueTask.CompletedTask;

    }
}
