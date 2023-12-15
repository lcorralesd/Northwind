﻿global using Northwind.AB.Sales.Backend.BusinessObjects.Abstractions.Specifications;
global using Northwind.AB.Sales.Backend.BusinessObjects.Aggregates;
global using Northwind.AB.Sales.Backend.BusinessObjects.Exceptions;
global using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Authentication;
global using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Common;
global using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;
global using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Events;
global using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Logging;
global using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Repositories;
global using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Transactions;
global using Northwind.AB.Sales.Backend.BusinessObjects.ValueObjects;
global using Northwind.EB.Sales.Entities.DTOs;
global using Northwind.EB.Sales.Entities.Validators.Interfaces.Common;
global using Northwind.EB.Sales.Entities.Validators.ValueObjects;
global using Northwind.Sales.Backend.UseCases.Common;
global using Northwind.Sales.Backend.UseCases.CreateOrder;
global using Northwind.Sales.Backend.UseCases.Resources;
global using System.Linq.Expressions;
