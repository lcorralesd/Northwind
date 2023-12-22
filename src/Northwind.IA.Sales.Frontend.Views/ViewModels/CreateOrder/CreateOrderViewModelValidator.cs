using Northwind.Validation.Entities.Interfaces;
using Northwind.Validation.Entities.ValueObjects;

namespace Northwind.IA.Sales.Frontend.Views.ViewModels.CreateOrder;
internal class CreateOrderViewModelValidator : IModelValidator<CreateOrderViewModel>
{
    readonly IModelValidator<CreateOrderDto> _validator;

    public CreateOrderViewModelValidator(IModelValidator<CreateOrderDto> validator)
    {
        _validator = validator;
    }

    public IEnumerable<ValidationError> Errors => _validator.Errors;

    public Task<bool> Validate(CreateOrderViewModel model) =>
        _validator.Validate((CreateOrderDto)model);
}
