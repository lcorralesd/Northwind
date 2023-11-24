﻿namespace Northwind.IA.Sales.Gateways.EFCore.Entities;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }
}
