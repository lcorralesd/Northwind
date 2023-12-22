namespace Northwind.IA.Membership.Backend.AspNetIdentity.Services;
internal static class ErrorMessageMapper
{
    public static IEnumerable<ValidationError> ToValidationErrors(this IEnumerable<IdentityError> errors)
    {
        List<ValidationError> result = [];
        foreach (var error in errors)
        {
            switch (error.Code)
            {
                case nameof(IdentityErrorDescriber.DuplicateUserName):
                    result.Add(new ValidationError(nameof(UserRegistrationDTO.Email), Messages.DuplicateUserNameErrorMessage));
                    break;
                default:
                    result.Add(new ValidationError(error.Code, error.Description));
                    break;
            }
        }
        return result;
    }
}
