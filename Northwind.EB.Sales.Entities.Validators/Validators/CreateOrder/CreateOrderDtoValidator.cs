using FluentValidation;
using Northwind.Validation.Entities.Abstractions;

namespace Northwind.EB.Sales.Entities.Validators.Validators.CreateOrder;
internal class CreateOrderDtoValidator : ValidatorBase<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.CustomerIdRequired)
            .Length(5)
            .WithMessage(CreateOrderMessages.CustomerIdRequiredLenght);

        RuleFor(x => x.ShipAddress)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipAddressRequired)
            .MaximumLength(60)
            .WithMessage(CreateOrderMessages.ShipAddressMaximumLenght);

        RuleFor(x => x.ShipCity)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipCityRequired)
            .MinimumLength(3)
            .WithMessage(CreateOrderMessages.ShipCityMinimumLenght)
            .MaximumLength(15)
            .WithMessage(CreateOrderMessages.ShipCityMaximumLenght);

        RuleFor(x => x.ShipCountry)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipCountryRequired)
            .MinimumLength(3)
            .WithMessage(CreateOrderMessages.ShipCountryMinumunLenght)
            .MaximumLength(15)
            .WithMessage(CreateOrderMessages.ShipCountryMaximumLengt);

        RuleFor(x => x.ShipPostalCode)
            .MaximumLength(10)
            .WithMessage(CreateOrderMessages.ShipPostalCodeMaximumLenght);

        RuleFor(x => x.OrderDetails)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage(CreateOrderMessages.OrderDetailsRequired)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.OrderDetailsNotEmpty);

        RuleForEach(x => x.OrderDetails)
            .SetValidator(new CreateOrderDetailDtoValidator());
    }
}
