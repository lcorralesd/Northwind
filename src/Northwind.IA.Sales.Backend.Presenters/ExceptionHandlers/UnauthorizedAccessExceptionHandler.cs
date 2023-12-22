using Northwind.EB.Exceptions.Entities.Interfaces;

namespace Northwind.IA.Sales.Backend.Presenters.ExceptionHandlers;
internal class UnauthorizedAccessExceptionHandler : IExceptionHandler<UnauthorizedAccessException>
{
    public ProblemDetails Handle(UnauthorizedAccessException exception)
    {
        ProblemDetails details = new()
        {
            Status = StatusCodes.Status401Unauthorized,
            Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
            Title = ExceptionMessages.UnauthorizedAccessExceptionTitle,
            Detail = ExceptionMessages.UnauthorizedAccessExceptionDetail,
            Instance = $"{nameof(ProblemDetails)}/{exception.GetType()}"
        };

        return details;
    }
}
