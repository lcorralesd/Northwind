namespace Microsoft.AspNetCore.Builder;
internal static class UserRegistrationController
{
    public static WebApplication UseUserRegistrationController(this WebApplication app)
    {
        app.MapPost(Endpoints.Register,
            async (UserRegistrationDTO userData,
            IUserRegistrationInputPort inputPort,
            IUserRegistrationOutputPort presenter) =>
            {
                await inputPort.Handle(userData);
                return presenter.Result;
            });
        return app;
    }
}
