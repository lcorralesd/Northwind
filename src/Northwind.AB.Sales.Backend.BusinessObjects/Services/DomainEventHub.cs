namespace Northwind.AB.Sales.Backend.BusinessObjects.Services;
internal class DomainEventHub<EventType> : IDomainEventHub<EventType> where EventType : IDomainEvent
{
    readonly IEnumerable<IDomainEventHandler<EventType>> _eventHandlers;

    public DomainEventHub(IEnumerable<IDomainEventHandler<EventType>> eventHandlers) => _eventHandlers = eventHandlers;

    public async ValueTask Raise(EventType eventTypeInstance)
    {
        foreach (var handler in _eventHandlers)
        {
            await handler.Handle(eventTypeInstance);
        }
    }
}
