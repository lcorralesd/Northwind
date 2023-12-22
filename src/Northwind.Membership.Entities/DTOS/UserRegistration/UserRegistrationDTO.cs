namespace Northwind.Membership.Entities.DTOS.UserRegistration;
public class UserRegistrationDTO(string email, string password, string firstName, string lastName)
{
    public string Email { get; } = email;
    public string Password { get; } = password;
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
}
