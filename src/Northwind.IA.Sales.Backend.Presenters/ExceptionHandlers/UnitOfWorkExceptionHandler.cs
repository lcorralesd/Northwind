using Northwind.EB.Exceptions.Entities.Interfaces;

namespace Northwind.IA.Sales.Backend.Presenters.ExceptionHandlers;
internal class UnitOfWorkExceptionHandler : IExceptionHandler<UnitOfWorkException>
{
    readonly ILogger<UnitOfWorkExceptionHandler> _logger;

    public UnitOfWorkExceptionHandler(ILogger<UnitOfWorkExceptionHandler> logger) => _logger = logger;

    public ProblemDetails Handle(UnitOfWorkException exception)
    {

        ProblemDetails Details = new ProblemDetails();

        Details.Status = StatusCodes.Status500InternalServerError;
        Details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        Details.Title = ExceptionMessages.UnitOfWorkExceptionTitle;
        Details.Detail = ExceptionMessages.UnitOfWorkExceptionDetail;
        Details.Instance = $"{nameof(ProblemDetails)}/{nameof(UnitOfWorkException)}";

        _logger.LogError(exception, ExceptionMessages.UnitOfWorkExceptionTitle + ": " + string.Join(" ", exception.Entities));


        return Details;
    }
}
