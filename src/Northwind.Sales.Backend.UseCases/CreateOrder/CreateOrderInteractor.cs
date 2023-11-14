namespace Northwind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderInteractor : ICreateOrderInputPort
{
    readonly ICreateOrderOutputPort _createOrderOutputPort;
    readonly ICommandSalesRepository _commandSalesRepository;

    public CreateOrderInteractor(ICreateOrderOutputPort createOrderOutputPort, ICommandSalesRepository commandSalesRepository)
    {
        _createOrderOutputPort = createOrderOutputPort;
        _commandSalesRepository = commandSalesRepository;
    }

    public async ValueTask Handle(CreateOrderDto createOrderDto)
    {
        var order = OrderAggregate.From(createOrderDto);

        await _commandSalesRepository.CreateOrder(order);
        await _commandSalesRepository.SaveChanges();

        await _createOrderOutputPort.Handle(order);
    }
}
