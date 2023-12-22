namespace Northwind.AB.Membership.Backend.BusinessObjects.Interfaces.UserRegistration;
public interface IUserRegistrationOutputPort
{
    IResult Result { get; }
    Task Handle(Result<IEnumerable<ValidationError>> userRegistrationResult);
}
