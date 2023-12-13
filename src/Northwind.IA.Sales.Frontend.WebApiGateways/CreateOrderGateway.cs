using Northwind.AB.Sales.Frontend.BusinessObjects.Interfaces;
using Northwind.EB.Sales.Entities.DTOs;
using Northwind.EB.Sales.Entities.ValueObjetcs;
using System.Net.Http.Json;

namespace Northwind.IA.Sales.Frontend.WebApiGateways;
internal class CreateOrderGateway : ICreateOrderGateway
{
    readonly HttpClient _httpClient;

    public CreateOrderGateway(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<int> CreateOrderAsync(CreateOrderDto order)
    {
        var response = await _httpClient.PostAsJsonAsync(Endpoints.CreateOrder, order);

        return await response.Content.ReadFromJsonAsync<int>();
        //int orderId = 0;
        //var response = await _httpClient.PostAsJsonAsync(Endpoints.CreateOrder, order);

        //return orderId;
    }
}
