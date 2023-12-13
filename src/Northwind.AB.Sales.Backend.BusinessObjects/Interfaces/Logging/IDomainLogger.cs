namespace Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Logging;
public interface IDomainLogger
{
    ValueTask LogInformation(DomainLog log);
}
