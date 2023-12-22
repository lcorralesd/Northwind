namespace Northwind.IA.Membership.Backend.Presenters.Services;
internal class JwtService(IOptions<JwtOptions> options)
{
    SigningCredentials GetSigningCredentials()
    {
        var secret = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(options.Value.SecurityKey));
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    List<Claim> GetClaims(UserDTO userDTO) =>
        [
            new Claim(ClaimTypes.Name, userDTO.Email),
            new Claim("FullName", $"{userDTO.FirstName} {userDTO.LastName}")
        ];

    JwtSecurityToken GetTokenOptions(
        SigningCredentials signingCredentials, List<Claim> claims) =>
        new JwtSecurityToken(
                       issuer: options.Value.ValidIssuer,
                       audience: options.Value.ValidAudience,
                       claims: claims,
                       expires: DateTime.Now.AddMinutes(options.Value.ExpireInMinutes),
                       signingCredentials: signingCredentials);

    public string GetToken(UserDTO userDTO)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(userDTO);
        var tokenOptions = GetTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}
