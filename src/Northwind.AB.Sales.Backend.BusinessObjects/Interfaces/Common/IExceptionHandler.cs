namespace Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Common;
public interface IExceptionHandler<T> where T : Exception
{
    ProblemDetails Handle(T exception);
}
