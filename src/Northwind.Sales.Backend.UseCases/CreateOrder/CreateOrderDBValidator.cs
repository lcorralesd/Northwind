namespace Northwind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderDBValidator : IModelValidator<CreateOrderDto>
{
    readonly IQuerySalesRepository _salesRepository;

    public CreateOrderDBValidator(IQuerySalesRepository salesRepository) => _salesRepository = salesRepository;

    readonly List<ValidationError> _validationErrors = new();

    public IEnumerable<ValidationError> Errors => _validationErrors;

    public async Task<bool> Validate(CreateOrderDto model) =>
        await ValidateCustomer(model) &&
        await ValidateProducts(model);

    private async Task<bool> ValidateCustomer(CreateOrderDto model)
    {
        var currentBalance =
            await _salesRepository.GetCustomerCurrentBalance(model.CustomerId);
        if (currentBalance == null)
        {
            _validationErrors.Add(new ValidationError(nameof(model.CustomerId), CreateOrderMessages.CustomerIdNotFoundError));
        }
        else if (currentBalance > 0)
        {
            _validationErrors.Add(new ValidationError(nameof(model.CustomerId), string.Format(CreateOrderMessages.CustomerWithBalanceErrorTemplate, model.CustomerId, currentBalance)));
        }

        return !_validationErrors.Any();
    }

    private async Task<bool> ValidateProducts(CreateOrderDto model)
    {
        IEnumerable<ProductUnitsInStock> requiredQuantities
            = model.OrderDetails
            .GroupBy(d => d.ProductId)
            .Select(d => new ProductUnitsInStock(d.Key, d.Sum(d => d.Quantity)));

        var productIds = requiredQuantities
            .Select(d => d.ProductId);

        IEnumerable<ProductUnitsInStock> InStockQuantities =
            await _salesRepository.GetProductsUnitsInStock(productIds);

        var requiredVsInStock = requiredQuantities
            .GroupJoin(InStockQuantities,
            required => required.ProductId,
            inStock => inStock.ProductId,
            (oneRequired, manyInStock) => new { oneRequired, manyInStock })
            .SelectMany(groupResult => groupResult.manyInStock.DefaultIfEmpty(),
            (groupResult, singleInStock) =>
            new
            {
                groupResult.oneRequired.ProductId,
                Required = groupResult.oneRequired.UnitsInStock,
                InStock = singleInStock?.UnitsInStock
            });

        foreach (var item in requiredVsInStock)
        {
            if (!item.InStock.HasValue)
            {
                CreateOrderDetailDto orderDetail =
                    model.OrderDetails.First(i => i.ProductId == item.ProductId);

                var index = model.OrderDetails.ToList().IndexOf(orderDetail);

                string propertyName = $"{nameof(model.OrderDetails)}[{index}].{nameof(orderDetail.ProductId)}";

                _validationErrors.Add(new ValidationError(propertyName, string.Format(CreateOrderMessages.ProductIdNotFoundTemplate, item.ProductId)));
            }
            else if (item.InStock < item.Required)
            {
                CreateOrderDetailDto orderDetail =
                    model.OrderDetails.First(i => i.ProductId == item.ProductId);

                var index = model.OrderDetails.ToList().IndexOf(orderDetail);

                string propertyName = $"{nameof(model.OrderDetails)}[{index}].{nameof(orderDetail.Quantity)}";

                _validationErrors.Add(new ValidationError(propertyName, string.Format(CreateOrderMessages.UnitsInStockLessThanQuantityErrorTemplate, item.Required, item.InStock, item.ProductId)));
            }
        }

        return !_validationErrors.Any();

    }
}
