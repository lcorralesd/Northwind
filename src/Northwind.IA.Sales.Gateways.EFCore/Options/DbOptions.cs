﻿namespace Northwind.IA.Sales.Gateways.EFCore.Options;
public class DbOptions
{
    public const string SectionKey = nameof(DbOptions);
    public string ConnectionString { get; set; }
    public string DomainLogsConnectionString { get; set; }
}
