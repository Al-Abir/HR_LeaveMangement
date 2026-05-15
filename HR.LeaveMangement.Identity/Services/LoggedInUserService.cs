using System.Security.Claims;
using HR.LeaveMangement.Application.Contracts.Identity;
using Microsoft.AspNetCore.Http;

public class LoggedInUserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId
    {
        get
        {
            return _httpContextAccessor.HttpContext?
                .User?
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;
        }
    }
}