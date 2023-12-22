namespace Northwind.AB.Membership.Backend.BusinessObjects.Interfaces.UserLogin;
public interface IUserLoginInputPort
{
    Task Handle(UserCredentialsDTO userData);
}
