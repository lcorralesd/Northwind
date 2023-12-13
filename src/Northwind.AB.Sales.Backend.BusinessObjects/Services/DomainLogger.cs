namespace Northwind.AB.Sales.Backend.BusinessObjects.Services;
internal class DomainLogger(IDomaiLogsRepository domaiLogsRepository) : IDomainLogger
{
    public async ValueTask LogInformation(DomainLog log)
    {
        await domaiLogsRepository.Add(log);
        await domaiLogsRepository.SaveChanges();
    }
}
