namespace Northwind.IA.Sales.Gateways.EFCore.Entities;
internal class DomainLog
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Informatiion { get; set; }
    public string UserName { get; set; }
}
