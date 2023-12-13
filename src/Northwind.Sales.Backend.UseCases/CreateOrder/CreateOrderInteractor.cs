using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Logging;

namespace Northwind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderInteractor(
    ICreateOrderOutputPort createOrderOutputPort,
    ICommandSalesRepository commandSalesRepository,
    IEnumerable<IModelValidator<CreateOrderDto>> modelValidator,
    IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub,
    IDomainLogger domainLogger
    ) : ICreateOrderInputPort
{
    public async ValueTask Handle(CreateOrderDto createOrderDto)
    {
        var enumerator = modelValidator.GetEnumerator();
        bool isValid = true;

        while (isValid && enumerator.MoveNext()) 
            isValid = await enumerator.Current.Validate(createOrderDto);
            
        if (!isValid)
            throw new ValidationException(enumerator.Current.Errors);

        await domainLogger.LogInformation(new DomainLog(CreateOrderMessages.StartingPurchaseOrderCreation));

        var order = OrderAggregate.From(createOrderDto);

        await commandSalesRepository.CreateOrder(order);
        await commandSalesRepository.SaveChanges();

        await domainLogger.LogInformation(new DomainLog(string.Format(CreateOrderMessages.PurchaseOrderCreatedTemplate, order.Id)));

        await createOrderOutputPort.Handle(order);

        if(order.OrderDetails.Count > 3) 
        {
            await domainEventHub.Raise(new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));
        }
    }
}
