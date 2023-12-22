namespace Northwind.Validation.Entities.Services;
internal class ModelValidatorService<ModelType>(IEnumerable<IModelValidator<ModelType>> validators) 
    : IModelValidatorService<ModelType>
{
    public IEnumerable<ValidationError> Errors { get; private set; }
    public async Task<bool> Validate(ModelType model)
    {
        var enumerator = validators.GetEnumerator();
        bool isValid = true;

        while (isValid && enumerator.MoveNext())
            isValid = await enumerator.Current.Validate(model);

        if (!isValid)
            Errors = enumerator.Current.Errors;
        return isValid;
    }
}
