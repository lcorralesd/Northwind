namespace Northwind.AB.Sales.Backend.BusinessObjects.Services;
internal class UserService(IHttpContextAccessor contextAccessor) : IUserService
{
    public bool IsAuthenticated 
        => contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    public string UserName =>
        contextAccessor.HttpContext?.User?.Identity?.Name ?? string.Empty;
    public string FullName 
        => contextAccessor.HttpContext.User.Claims
        .Where(c => c.Type == "FullName")
        .Select(c => c.Value).SingleOrDefault(); 
}
