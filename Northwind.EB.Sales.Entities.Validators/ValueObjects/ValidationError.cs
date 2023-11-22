namespace Northwind.EB.Sales.Entities.Validators.ValueObjects;
public class ValidationError
{
    public string Message { get; }
    public string PropertyName { get; }

    public ValidationError(string propertyName, string message)
    {
        PropertyName = propertyName;
        Message = message;
    }
}
