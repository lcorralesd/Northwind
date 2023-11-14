namespace Northwind.Sales.Backend.UseCases.Test.Fakes;
internal class PresenterFake : ICreateOrderOutputPort
{
    public int OrderId { get; private set; }
    public OrderAggregate OrderAggregate { get; set; }

    public ValueTask Handle(OrderAggregate addedOrder)
    {
        OrderAggregate = addedOrder;
        OrderId = addedOrder.Id;
        return ValueTask.CompletedTask;
    }
}
