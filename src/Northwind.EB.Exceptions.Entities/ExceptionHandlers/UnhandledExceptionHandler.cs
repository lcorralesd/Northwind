namespace Northwind.EB.Exceptions.Entities.ExceptionHandlers;
internal class UnhandledExceptionHandler : IExceptionHandler
{
    readonly ILogger<UnhandledExceptionHandler> _logger;

    public UnhandledExceptionHandler(ILogger<UnhandledExceptionHandler> logger) => _logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ProblemDetails details = new ProblemDetails();
        details.Status = StatusCodes.Status500InternalServerError;
        details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        details.Title = ExceptionMessages.UnhandledExceptionTitle;
        details.Detail = ExceptionMessages.UnhandledExceptionDetail;
        details.Instance = $"{nameof(ProblemDetails)}/{exception.GetType()}";

        _logger.LogError(exception, ExceptionMessages.UnhandledExceptionTitle);

        await httpContext.WriteProblemDetails(details);

        return true;
    }
}
