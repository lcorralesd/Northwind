namespace Northwind.Membership.Entities.Validators.UserLogin;
internal class UserCredentialsDTOValidator : ValidatorBase<UserCredentialsDTO>
{
    public UserCredentialsDTOValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(UserLoginMessages.RequireEmailErrorMessage)
            .EmailAddress()
            .WithMessage(UserLoginMessages.InvalidEmailErrorMessage);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(UserLoginMessages.RequiredPasswordErrorMessage);
    }
}
