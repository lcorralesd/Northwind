using Microsoft.AspNetCore.Components;
using Northwind.IA.Sales.Frontend.Views.ViewModels;

namespace Northwind.IA.Sales.Frontend.Views.Components;
public partial class CreateOrderComponent
{
    [Parameter]
    public CreateOrderViewModel Order { get; set; }
}
