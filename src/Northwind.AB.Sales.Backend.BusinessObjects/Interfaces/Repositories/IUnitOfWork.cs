namespace Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Repositories;
public interface IUnitOfWork
{
    ValueTask SaveChanges();
}
