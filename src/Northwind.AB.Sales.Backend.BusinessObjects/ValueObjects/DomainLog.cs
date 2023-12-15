namespace Northwind.AB.Sales.Backend.BusinessObjects.ValueObjects;
public class DomainLog(string information, string userName)
{
    public DateTime DateTime { get; } = DateTime.Now;
    public string Information { get; } = information;
    public string UserName { get; } = userName;
}
