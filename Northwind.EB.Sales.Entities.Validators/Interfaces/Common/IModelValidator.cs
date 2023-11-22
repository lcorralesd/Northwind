namespace Northwind.EB.Sales.Entities.Validators.Interfaces.Common;
public interface IModelValidator<T>
{
    Task<bool> Validate(T model);

    IEnumerable<ValidationError> Errors { get; }
}
