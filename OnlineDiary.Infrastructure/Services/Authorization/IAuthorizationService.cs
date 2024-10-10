namespace OnlineDiary.Infrastructure.Services.Authorization;

public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync(object resource, string policyName);
}
