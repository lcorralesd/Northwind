namespace Northwind.AB.Membership.Backend.BusinessObjects.DTOs;
public class UserDTO(string email, string firstName, string lastName)
{
    public string Email { get; set; } = email;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
}
