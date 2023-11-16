using Microsoft.AspNetCore.Http;
using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;
using Northwind.EB.Sales.Entities.DTOs;
using Northwind.EB.Sales.Entities.ValueObjetcs;

namespace Microsoft.AspNetCore.Builder;
public static class CreateOrderController
{
    public static WebApplication UseCreateOrderController(this WebApplication app)
    {
        app.MapPost(Endpoints.CreateOrder,
            async (CreateOrderDto orderDto,
        ICreateOrderInputPort inputPort,
        ICreateOrderOutputPort presenter) =>
            Results.Ok(await CreateOrder(orderDto, inputPort, presenter)));

        return app;
    }

    public static async Task<int> CreateOrder(
        CreateOrderDto orderDto,
        ICreateOrderInputPort inputPort,
        ICreateOrderOutputPort presenter)
    {
        await inputPort.Handle(orderDto);
        return presenter.OrderId;
    }
}
