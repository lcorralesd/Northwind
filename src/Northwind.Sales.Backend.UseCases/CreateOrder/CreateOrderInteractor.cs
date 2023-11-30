namespace Northwind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderInteractor : ICreateOrderInputPort
{
    readonly ICreateOrderOutputPort _createOrderOutputPort;
    readonly ICommandSalesRepository _commandSalesRepository;
    readonly IEnumerable<IModelValidator<CreateOrderDto>> _modelValidators;

    public CreateOrderInteractor(ICreateOrderOutputPort createOrderOutputPort, ICommandSalesRepository commandSalesRepository,
        IEnumerable<IModelValidator<CreateOrderDto>> modelValidator)
    {
        _createOrderOutputPort = createOrderOutputPort;
        _commandSalesRepository = commandSalesRepository;
        _modelValidators = modelValidator;
    }

    public async ValueTask Handle(CreateOrderDto createOrderDto)
    {
        var enumerator = _modelValidators.GetEnumerator();
        bool isValid = true;

        while (isValid && enumerator.MoveNext()) 
        {
            isValid = await enumerator.Current.Validate(createOrderDto);
            if (!isValid)
            {
                throw new ValidationException(enumerator.Current.Errors);
            }
        }

        var order = OrderAggregate.From(createOrderDto);

        await _commandSalesRepository.CreateOrder(order);
        await _commandSalesRepository.SaveChanges();

        await _createOrderOutputPort.Handle(order);
    }
}
