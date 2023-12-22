namespace Northwind.IA.Membership.Backend.Presenters.UserLogin;
internal class UserLoginPresenter(JwtService jwtService) : IUserLoginOutputPort
{
    public IResult Result { get; private set; }

    public Task Handle(Result<UserDTO, IEnumerable<ValidationError>> userLoginResult)
    {
        userLoginResult.HandleError(
            userDto =>
            {
                Result = Results.Ok(new TokensDTO(jwtService.GetToken(userDto)));
            },
            errors =>
            {
                Result = Results.Problem(
                    errors.ProblemDetails(
                        Messages.UserLoginErrorTitle,
                        Messages.UserLoginErrorDetail,
                        nameof(UserLoginPresenter)));
            });

        return Task.CompletedTask;
    }
}
