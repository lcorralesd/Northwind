namespace Northwind.Validation.Entities.Abstractions;
public abstract class ValidatorBase<T> : AbstractValidator<T>, IModelValidator<T>
{
    public IEnumerable<ValidationError> Errors { get; private set; }

    async Task<bool> IModelValidator<T>.Validate(T model)
    {
        var result = await ValidateAsync(model);
        if (!result.IsValid)
        {
            Errors = result.Errors
                .Select(e => new ValidationError(e.PropertyName, e.ErrorMessage));
        }

        return result.IsValid;
    }
}
