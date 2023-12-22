namespace Northwind.Membership.Entities.DTOS.UserLogin;
public class UserCredentialsDTO(string email, string password)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}
