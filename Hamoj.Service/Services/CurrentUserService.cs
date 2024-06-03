using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Hamoj.Service.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly ClaimsPrincipal _claimsPrincipal;
    public CurrentUserService(IHttpContextAccessor httpContext)
    {
        if (httpContext?.HttpContext?.User == null)
            throw new ArgumentNullException(nameof(httpContext));

        _claimsPrincipal = httpContext.HttpContext!.User;
    }

    public int GetCurrentUserId() => int.Parse(_claimsPrincipal.FindFirst("Id")!.Value);

    public string GetCurrentUserName() => _claimsPrincipal.FindFirst(ClaimTypes.Name)!.Value;

    public string GetCurrentUserRole() => _claimsPrincipal.FindFirst(ClaimTypes.Role)!.Value;
}
