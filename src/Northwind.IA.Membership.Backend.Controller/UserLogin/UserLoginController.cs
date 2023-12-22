namespace Northwind.IA.Membership.Backend.Controller.UserLogin;
internal static class UserLoginController
{
    public static WebApplication UseUserLoginController(this WebApplication app)
    {
        app.MapPost(Endpoints.Login,
                       async (UserCredentialsDTO userData,
                                  IUserLoginInputPort inputPort,
                                  IUserLoginOutputPort presenter) =>
                       {
                           await inputPort.Handle(userData);
                           return presenter.Result;
                       });
        return app;
    }
}
