namespace Northwind.IA.Membership.Backend.AspNetIdentity.Services;
internal class MembershipService(UserManager<NorthwindUser> manager) : IMembershipService
{
    public async Task<UserDTO> GetUserByCredentials(UserCredentialsDTO userData)
    {
        UserDTO foundUser = null;

        var user = await manager.FindByEmailAsync(userData.Email);
        if (user != null)
        {
            var passwordIsValid = await manager.CheckPasswordAsync(user, userData.Password);
            if (passwordIsValid)
            {
                foundUser = new UserDTO(
                    user.Email,
                    user.FirstName,
                    user.LastName
                );
            }
        }

        return foundUser;
    }

    public async Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDTO userData)
    {
        var user = new NorthwindUser
        {
            UserName = userData.Email,
            Email = userData.Email,
            FirstName = userData.FirstName,
            LastName = userData.LastName,
        };

        var identityResult = await manager.CreateAsync(user, userData.Password);
        return identityResult.Succeeded
            ? new Result<IEnumerable<ValidationError>>()
            : new Result<IEnumerable<ValidationError>>(identityResult.Errors.ToValidationErrors());
    }
}
