namespace Northwind.AB.Membership.Backend.BusinessObjects.Interfaces.Common;
public interface IMembershipService
{
    Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDTO userData);
    Task<UserDTO> GetUserByCredentials(UserCredentialsDTO userData);
}
