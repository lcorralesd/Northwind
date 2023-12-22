namespace Northwind.Membership.Entities.DTOS.UserLogin;
public class TokensDTO(string accessToken)
{
    public string AccessToken { get; set; } = accessToken;
}
