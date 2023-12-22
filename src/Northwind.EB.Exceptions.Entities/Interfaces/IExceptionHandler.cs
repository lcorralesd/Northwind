namespace Northwind.EB.Exceptions.Entities.Interfaces;
public interface IExceptionHandler<T> where T : Exception
{
    ProblemDetails Handle(T exception);
}
