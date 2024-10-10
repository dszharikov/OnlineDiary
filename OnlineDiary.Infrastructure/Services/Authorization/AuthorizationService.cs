using Microsoft.AspNetCore.Http;

namespace OnlineDiary.Infrastructure.Services.Authorization;

public class AuthorizationService : IAuthorizationService
{
    private readonly Microsoft.AspNetCore.Authorization.IAuthorizationService _authorizationService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationService(Microsoft.AspNetCore.Authorization.IAuthorizationService authorizationService,
        IHttpContextAccessor httpContextAccessor)
    {
        _authorizationService = authorizationService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> AuthorizeAsync(object resource, string policyName)
    {
        var user = _httpContextAccessor.HttpContext.User;
        var result = await _authorizationService.AuthorizeAsync(user, resource, policyName);
        return result.Succeeded;
    }
}