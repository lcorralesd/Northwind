namespace Northwind.Sales.Backend.UseCases.Test;

public class CreateOrderInteractorTests
{
    [Fact]
    public async void CreateOrder_Should_ReturnIdGreatherThanZero()
    {
        // Arrange
        var stubRepository = new RepositoryFake();
        var mockPresenter = new PresenterFake();
        var order = new CreateOrderDto(
            customerId: "ALFI",
            shipAddress: "Los Alpes",
            shipCity: "Cartagena",
            shipCountry: "Colombia",
            shipPostalCode: "12345",
            new List<CreateOrderDetailDto> 
            {
                new CreateOrderDetailDto(1, 22, 100)
            }
        );

        CreateOrderInteractor interactor = new CreateOrderInteractor(mockPresenter, stubRepository);

        // Act
        await interactor.Handle(order);

        // Assert
        Assert.True(mockPresenter.OrderId > 0);
        Assert.True(mockPresenter.OrderAggregate.ShippingType == AB.Sales.Backend.BusinessObjects.Enums.ShippingType.Road);
    }
}