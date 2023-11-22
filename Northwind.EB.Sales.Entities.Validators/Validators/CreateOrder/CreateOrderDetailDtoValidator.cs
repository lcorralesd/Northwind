namespace Northwind.EB.Sales.Entities.Validators.Validators.CreateOrder;
internal class CreateOrderDetailDtoValidator : ValidatorBase<CreateOrderDetailDto>
{
    public CreateOrderDetailDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage(CreateOrderMessages.ProductIdGreatherThanZero);

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0)
            .WithMessage(CreateOrderMessages.UnitPriceGreatherThanZero);

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage(CreateOrderMessages.UnitPriceGreatherThanZero);
    }
}
