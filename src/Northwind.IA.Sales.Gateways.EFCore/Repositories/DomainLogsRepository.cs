namespace Northwind.IA.Sales.Gateways.EFCore.Repositories;
internal class DomainLogsRepository(NorthwindDomainLogsContext domainLogsContext) : IDomaiLogsRepository
{
    public async ValueTask Add(AB.Sales.Backend.BusinessObjects.ValueObjects.DomainLog log)
    {
        await domainLogsContext.AddAsync(new Entities.DomainLog
        {
            CreatedDate = log.DateTime,
            Informatiion = log.Information,
            UserName = log.UserName,
        });
    }
    public async ValueTask SaveChanges()
    {
        try
        {
            await domainLogsContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new UnitOfWorkException(ex,
                ex.Entries.Select(e => e.Entity.GetType().Name));
        }

        catch (Exception)
        {
            throw;
        }
    }

}
