namespace Northwind.IA.Sales.Frontend.Views.Pages;
public partial class CreateOrder
{
    [Inject]
    CreateOrderViewModel ViewModel { get; set; }

    ErrorBoundary errorBoundaryRef { get; set; }

    void Recover()
    {
        errorBoundaryRef?.Recover();
    }
}