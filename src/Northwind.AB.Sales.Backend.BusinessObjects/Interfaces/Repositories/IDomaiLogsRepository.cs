namespace Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Repositories;
public interface IDomaiLogsRepository : IUnitOfWork
{
    ValueTask Add(DomainLog log);
}
