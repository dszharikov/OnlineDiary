using OnlineDiary.Infrastructure.Services.Tenant;

namespace OnlineDiary.Presentation.Middlewares;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantService tenantService)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var schoolIdClaim = context.User.FindFirst("school_id");
            if (schoolIdClaim != null)
            {
                tenantService.SchoolId = schoolIdClaim.Value;
            }
        }

        await _next(context);
    }
}