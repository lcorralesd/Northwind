namespace Northwind.Membership.Entities.Validators.UserRegistration;
internal class UserRegistrationDTOValidator : ValidatorBase<UserRegistrationDTO>
{
    public UserRegistrationDTOValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(UserRegistrationMessages.RequiredEmailErrorMessage)
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(UserRegistrationMessages.RequiredPasswordErrorMessage)
            .MinimumLength(6)
            .WithMessage(UserRegistrationMessages.PasswordTooShortErrorMessage)
            .Must(p => p.Any(c => char.IsLower(c)))
            .WithMessage(UserRegistrationMessages.PasswordRequiresLowerErrorMessage)
            .Must(p => p.Any(c => char.IsUpper(c)))
            .WithMessage(UserRegistrationMessages.PasswordRequiresDigitErrorMessage)
            .Must(p => p.Any(c => char.IsDigit(c)))
            .WithMessage(UserRegistrationMessages.PasswordRequiresDigitErrorMessage)
            .Must(p => p.Any(c => !char.IsLetterOrDigit(c)))
            .WithMessage(UserRegistrationMessages.PasswordRequiresNonAlphanumericErrorMessage);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(UserRegistrationMessages.RequiredFirstNameErrorMessage);

        RuleFor(x => x.LastName)
           .NotEmpty()
           .WithMessage(UserRegistrationMessages.RequiredLastNameErrorMessage);
    }
}
