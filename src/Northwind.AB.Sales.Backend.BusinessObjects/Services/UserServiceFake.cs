namespace Northwind.AB.Sales.Backend.BusinessObjects.Services;
internal class UserServiceFake : IUserService
{
    public bool IsAuthenticated => true;
    public string UserName => "user@gmail.com";
    public string FullName => "Usuario de prueba";
}
