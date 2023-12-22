using Northwind.Validation.Entities.Interfaces;

namespace Northwind.AB.Membership.UseCases.UserRegistration;
internal class UserRegistrationInteractor(
    IUserRegistrationOutputPort outputPort,
    IMembershipService membershipService,
    IModelValidatorService<UserRegistrationDTO> validatorService
    ) : IUserRegistrationInputPort
{
    public async Task Handle(UserRegistrationDTO userData)
    {
        Result<IEnumerable<ValidationError>> Result;

        if (!await validatorService.Validate(userData))
        {
            Result = new(validatorService.Errors);
        }
        else
        {
            Result = await membershipService.Register(userData);
        }

        await outputPort.Handle(Result);
    }
}
