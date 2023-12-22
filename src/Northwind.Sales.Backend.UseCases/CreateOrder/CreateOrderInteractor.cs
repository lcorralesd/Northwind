namespace Northwind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderInteractor(
    ICreateOrderOutputPort createOrderOutputPort,
    ICommandSalesRepository commandSalesRepository,
    IModelValidatorService<CreateOrderDto> validatorService,
    IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub,
    IDomainLogger domainLogger,
    IDomainTransaction domainTransaction,
    IUserService userService
    ) : ICreateOrderInputPort
{
    public async ValueTask Handle(CreateOrderDto createOrderDto)
    {
        if (!userService.IsAuthenticated)
            throw new UnauthorizedAccessException();

        if (!await validatorService.Validate(createOrderDto))
            throw new ValidationException(validatorService.Errors);

        await domainLogger.LogInformation(new DomainLog(CreateOrderMessages.StartingPurchaseOrderCreation, userService.UserName));

        var order = OrderAggregate.From(createOrderDto);

        try
        {
            domainTransaction.BeginTransaction();

            await commandSalesRepository.CreateOrder(order);
            await commandSalesRepository.SaveChanges();

            await domainLogger.LogInformation(new DomainLog(string.Format(CreateOrderMessages.PurchaseOrderCreatedTemplate, order.Id), userService.UserName));

            await createOrderOutputPort.Handle(order);

            if (new SpecialOrderSpecification().IsSatisfiedBy(order))
            {
                await domainEventHub.Raise(new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));
            }

            domainTransaction.CommitTransaction();
        }
        catch
        {
            domainTransaction.RollbackTransaction();
            string information = string.Format(CreateOrderMessages.OrderCreationCancelledTemplate, order.Id);
            await domainLogger.LogInformation(new DomainLog(information, userService.UserName));
            throw;
        }
    }
}
