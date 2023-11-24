using Northwind.AB.Sales.Backend.BusinessObjects.ValueObjects;

namespace Northwind.IA.Sales.Gateways.EFCore.Repositories;
internal class QuerySalesRepository : IQuerySalesRepository
{

    readonly NorthwindSalesContext _context;

    public QuerySalesRepository(NorthwindSalesContext context) =>
        _context = context;

    public async Task<decimal?> GetCustomerCurrentBalance(string customerId)
    {
       var customer = 
            await _context.Customers
            .Where(c => c.Id == customerId)
            .Select(c => new {c.CurrentBalance})
            .FirstOrDefaultAsync();

        return customer?.CurrentBalance;

    }

    public async Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(IEnumerable<int> productIds) 
    {
        return await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .Select(p => new ProductUnitsInStock(p.Id,p.UnitsInStock)).ToListAsync();
    }
}
