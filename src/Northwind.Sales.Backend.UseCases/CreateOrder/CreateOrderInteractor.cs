namespace Northwind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderInteractor : ICreateOrderInputPort
{
    readonly ICreateOrderOutputPort _createOrderOutputPort;
    readonly ICommandSalesRepository _commandSalesRepository;
    readonly IModelValidator<CreateOrderDto> _modelValidator;

    public CreateOrderInteractor(ICreateOrderOutputPort createOrderOutputPort, ICommandSalesRepository commandSalesRepository,
        IModelValidator<CreateOrderDto> modelValidator)
    {
        _createOrderOutputPort = createOrderOutputPort;
        _commandSalesRepository = commandSalesRepository;
        _modelValidator = modelValidator;
    }

    public async ValueTask Handle(CreateOrderDto createOrderDto)
    {
        if (!await _modelValidator.Validate(createOrderDto))
        {
            string errors = string.Join(" ", _modelValidator.Errors
                .Select(e => $"{e.PropertyName}: {e.Message}"));

            throw new Exception(errors);
        }

        var order = OrderAggregate.From(createOrderDto);

        await _commandSalesRepository.CreateOrder(order);
        await _commandSalesRepository.SaveChanges();

        await _createOrderOutputPort.Handle(order);
    }
}
