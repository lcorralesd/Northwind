using Northwind.IA.Membership.Backend.Presenters.Extensions;
using Northwind.IA.Membership.Backend.Presenters.Resources;
using Northwind.Result.Entities;

namespace Northwind.IA.Membership.Backend.Presenters.UserRegistration;
internal class UserRegistrationPresenter : IUserRegistrationOutputPort
{
    public IResult Result { get; private set; }

    public Task Handle(Result<IEnumerable<ValidationError>> userRegistrationResult)
    {
        //implementamos este metodo
        userRegistrationResult.HandleError(
            errors =>
            {
                Result = Results.Problem(errors.ProblemDetails(
                    Messages.UserRegistrationErrorTitle,
                    Messages.UserRegistrationErrorDetail,
                    nameof(UserRegistrationPresenter)));
            },
            () => Result = Results.Created());

        return Task.CompletedTask;

    }
}
