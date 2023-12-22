namespace Northwind.AB.Membership.Backend.BusinessObjects.Interfaces.UserLogin;
public interface IUserLoginOutputPort
{
    IResult Result { get; }
    Task Handle(Result<UserDTO, IEnumerable<ValidationError>> userLoginResult);
}
