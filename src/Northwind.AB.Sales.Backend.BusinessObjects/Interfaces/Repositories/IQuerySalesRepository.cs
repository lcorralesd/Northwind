namespace Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Repositories;
public interface IQuerySalesRepository
{
    Task<decimal?> GetCustomerCurrentBalance(string customerId);
    Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(IEnumerable<int> productIds);



}
