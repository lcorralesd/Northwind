namespace Northwind.AB.Membership.Backend.BusinessObjects.Interfaces.UserRegistration;
public interface IUserRegistrationInputPort
{
    Task Handle(UserRegistrationDTO userData);
}
