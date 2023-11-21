﻿namespace Northwind.IA.Sales.Frontend.Views.ViewModels.CreateOrder;
public class CreateOrderViewModel
{
    readonly ICreateOrderGateway _gateway;

    public CreateOrderViewModel(ICreateOrderGateway gateway) => _gateway = gateway;

    public string CustomerId { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipPostalCode { get; set; }
    public List<CreateOrderDetailViewModel> OrderDetails { get; set; } = new();

    public string InformationMessage { get; private set; }

    public void AddNewOrderDetail()
    {
        OrderDetails.Add(new CreateOrderDetailViewModel());
    }

    public async Task Send()
    {
        InformationMessage = string.Empty;

        var orderId = await _gateway.CreateOrderAsync((CreateOrderDto)this);
        InformationMessage = string.Format(CreateOrderMessages.CreatedOrderTemplate, orderId);
    }

    public static explicit operator CreateOrderDto(CreateOrderViewModel model) =>
        new CreateOrderDto(model.CustomerId, model.ShipAddress, model.ShipCity, model.ShipCountry, model.ShipPostalCode, model.OrderDetails.Select(d => new CreateOrderDetailDto(d.ProductId, d.UnitPrice, d.Quantity)));
}