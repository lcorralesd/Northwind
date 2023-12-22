namespace Northwind.AB.Membership.UseCases.UserLogin;
internal class UserLoginInteractor(IMembershipService membershipService,
    IUserLoginOutputPort outputPort,
    IModelValidatorService<UserCredentialsDTO> validatorService) : IUserLoginInputPort
{
    public async Task Handle(UserCredentialsDTO userData)
    {
        Result<UserDTO, IEnumerable<ValidationError>> result;

        if (!await validatorService.Validate(userData))
        {
            result = new(validatorService.Errors);
        }
        else
        {
            var user = await membershipService.GetUserByCredentials(userData);
            result = user == null
                ? new([
                        new ValidationError(nameof(user.Email),
                        UserLoginMessages.InvalidUserCredentialsErrorMessage)])
                : new(user);
        }

        await outputPort.Handle(result);
    }
}
