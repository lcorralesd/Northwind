namespace Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Common;
public interface IMailService
{
    ValueTask SendMailToAdministrator(string subject, string body);
}
