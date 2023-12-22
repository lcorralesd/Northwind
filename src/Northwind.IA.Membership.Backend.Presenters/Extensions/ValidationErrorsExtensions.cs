namespace Northwind.IA.Membership.Backend.Presenters.Extensions;
internal static class ValidationErrorsExtensions
{
    public static ProblemDetails ProblemDetails(this IEnumerable<ValidationError> errors,
        string title, string detail, string instance)
    {
        ProblemDetails Details = new()
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = title,
            Detail = detail,
            Instance = $"{nameof(ProblemDetails)}/{nameof(instance)}"
        };
        Details.Extensions.Add("errors", errors);

        return Details;
    }
}
