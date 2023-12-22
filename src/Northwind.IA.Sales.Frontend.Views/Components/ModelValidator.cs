using Northwind.Validation.Entities.Interfaces;
using Northwind.Validation.Entities.ValueObjects;

namespace Northwind.IA.Sales.Frontend.Views.Components;
public class ModelValidator<T> : ComponentBase
{
    [CascadingParameter]
    EditContext EditContext { get; set; }

    [Parameter]
    public IModelValidator<T> Validator { get; set; }

    ValidationMessageStore validationMessageStore;

    FieldIdentifier GetFieldIdentifier(object model, string propertyName)
    {
        char[] propertyNameSeparators = new[] { '.', '[' };
        object newModel = model;

        string propertyPath = propertyName;
        int separatorIndex;
        string token = null;

        do
        {
            separatorIndex = propertyPath.IndexOfAny(propertyNameSeparators);
            if (separatorIndex >= 0)
            {
                token = propertyPath.Substring(0, separatorIndex);
                propertyPath = propertyPath.Substring(separatorIndex + 1);

                if (token.EndsWith("]"))
                {
                    token = token.Substring(0, token.Length - 1);
                    var propertyInfo =
                        newModel.GetType().GetProperty("Item");

                    var indexerType = propertyInfo.GetIndexParameters()[0].ParameterType;

                    var indexerValue =
                        Convert.ChangeType(token, indexerType);

                    newModel =
                        propertyInfo
                        .GetValue(newModel, new object[] { indexerValue });
                }
                else
                {
                    var propertyInfo = newModel.GetType()
                        .GetProperty(token);
                    newModel = propertyInfo.GetValue(newModel);
                }
                token = null;
            }

        } while (separatorIndex >= 0);

        return new FieldIdentifier(newModel, token ?? propertyPath);

    }

    async void ValidationRequested(object sender, ValidationRequestedEventArgs args)
    {
        bool isValid = await Validator.Validate((T)EditContext.Model);
        if (isValid)
        {
            validationMessageStore.Clear();
            EditContext.NotifyValidationStateChanged();
        }
        else
        {
            AddErrors(Validator.Errors);
        }
    }

    async void FieldChanged(object sender, FieldChangedEventArgs args)
    {
        validationMessageStore.Clear(args.FieldIdentifier);
        bool isValid = await Validator.Validate((T)EditContext.Model);

        if (!isValid)
        {
            foreach (var error in Validator.Errors)
            {
                var fieldIdentifier = GetFieldIdentifier(EditContext.Model, error.PropertyName);

                if (fieldIdentifier.FieldName == args.FieldIdentifier.FieldName && fieldIdentifier.Model == args.FieldIdentifier.Model)
                {
                    validationMessageStore.Add(fieldIdentifier, error.Message);
                }
            }
        }
        EditContext.NotifyValidationStateChanged();
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        EditContext previousEditContext = EditContext;

        await base.SetParametersAsync(parameters);
        if (EditContext != previousEditContext)
        {
            validationMessageStore = new ValidationMessageStore(EditContext);
            EditContext.OnValidationRequested += ValidationRequested;
            EditContext.OnFieldChanged += FieldChanged;
        }
    }

    public void AddErrors(IEnumerable<ValidationError> errors)
    {
        validationMessageStore.Clear();
        foreach (var error in errors)
        {
            var fieldIdentifier = GetFieldIdentifier(EditContext.Model,error.PropertyName);
            validationMessageStore.Add(fieldIdentifier, error.Message);
        }
        EditContext.NotifyValidationStateChanged();
    }
}
