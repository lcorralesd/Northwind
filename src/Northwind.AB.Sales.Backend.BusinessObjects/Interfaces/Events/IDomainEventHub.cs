namespace Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Events;
public interface IDomainEventHub<EventType> where EventType : IDomainEvent
{
    ValueTask Raise(EventType eventTypeInstance);
}
