﻿namespace Northwind.Sales.Backend.UseCases.Common;
internal class SpecialOrderSpecification : Specification<OrderAggregate>
{
    public override Expression<Func<OrderAggregate, bool>> ConditionExpression =>
        order => order.OrderDetails.Count > 3;
}
