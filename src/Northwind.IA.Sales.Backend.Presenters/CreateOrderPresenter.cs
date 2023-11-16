using Northwind.AB.Sales.Backend.BusinessObjects.Aggregates;
using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;

namespace Northwind.IA.Sales.Backend.Presenters;
internal class CreateOrderPresenter : ICreateOrderOutputPort
{
    public int OrderId { get; private set; }

    public ValueTask Handle(OrderAggregate addedOrder)
    {
        OrderId = addedOrder.Id;
        return ValueTask.CompletedTask;
    }
}
