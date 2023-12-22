using Northwind.IA.Sales.Frontend.Views.Components;
using Northwind.Validation.Entities.Interfaces;
using Northwind.Validation.Entities.ValueObjects;

namespace Northwind.IA.Sales.Frontend.Views.ViewModels.CreateOrder;
public class CreateOrderViewModel
{
    readonly ICreateOrderGateway _gateway;
    readonly IModelValidator<CreateOrderViewModel> _validator;


    public CreateOrderViewModel(ICreateOrderGateway gateway, IModelValidator<CreateOrderViewModel> validator)
    {
        _gateway = gateway;
        _validator = validator;

    }

    public string CustomerId { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipPostalCode { get; set; }
    public List<CreateOrderDetailViewModel> OrderDetails { get; set; } = new();

    public IModelValidator<CreateOrderViewModel> Validator => _validator;

    public ModelValidator<CreateOrderViewModel> ModelValidator {  get; set; }


    public string InformationMessage { get; private set; }

    public void AddNewOrderDetail()
    {
        OrderDetails.Add(new CreateOrderDetailViewModel());
    }

    public async Task Send()
    {
        InformationMessage = string.Empty;

        try
        {
            var orderId = await _gateway.CreateOrderAsync((CreateOrderDto)this);
            InformationMessage = string.Format(CreateOrderMessages.CreatedOrderTemplate, orderId);
        }
        catch (HttpRequestException ex)
        {
            if (ex.Data.Contains("Errors"))
            {
                IEnumerable<ValidationError> errors = ex.Data["Errors"] as IEnumerable<ValidationError>;
                ModelValidator.AddErrors(errors);
                
            }
            else
            {
                throw;
            }
        }
    }

    public static explicit operator CreateOrderDto(
        CreateOrderViewModel model) =>
            new CreateOrderDto(model.CustomerId,
                model.ShipAddress,
                model.ShipCity,
                model.ShipCountry,
                model.ShipPostalCode,
                model.OrderDetails
                .Select(d =>
                    new CreateOrderDetailDto(d.ProductId,
                        d.UnitPrice,
                        d.Quantity)));
}
