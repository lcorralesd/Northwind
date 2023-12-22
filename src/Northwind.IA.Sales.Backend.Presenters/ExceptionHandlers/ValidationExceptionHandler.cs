using Northwind.EB.Exceptions.Entities.Interfaces;

namespace Northwind.IA.Sales.Backend.Presenters.ExceptionHandlers;
internal class ValidationExceptionHandler : IExceptionHandler<ValidationException>
{
    public ProblemDetails Handle(ValidationException exception)
    {
        ProblemDetails Details = new()
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = ExceptionMessages.ValidationExceptionTitle,
            Detail = ExceptionMessages.ValidationExceptionDetail,
            Instance = $"{nameof(ProblemDetails)}/{nameof(ValidationException)}"
        };
        Details.Extensions.Add("errors", exception.Errors);

        return Details;
    }
}
