namespace Northwind.IA.Sales.Gateways.EFCore.Repositories;
public class CommandSalesRepository : ICommandSalesRepository
{
    readonly NorthwindSalesContext _context;

    public CommandSalesRepository(NorthwindSalesContext context) => _context = context;

    public async ValueTask CreateOrder(OrderAggregate orderAggregate) 
    {
        await _context.AddAsync(orderAggregate);
        await _context.AddRangeAsync(
            orderAggregate.OrderDetails
            .Select(d => new Entities.OrderDetail
            {
                Order = orderAggregate,
                ProductId = d.ProductId,
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice,
            }
            ).ToArray());
    }
    public async ValueTask SaveChanges() 
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new UnitOfWorkException(ex,
                ex.Entries.Select(e => e.Entity.GetType().Name));
        }

        catch(Exception)
        {
            throw;
        }
        
    }
}
