using Microsoft.AspNetCore.Authorization;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Infrastructure.Authorization.Requirements.QuarterlyGrades;
using System.Security.Claims;

namespace OnlineDiary.Infrastructure.Authorization.Handlers.QuarterlyGrades;

public class CanViewQuarterlyGradeHandler : AuthorizationHandler<CanViewQuarterlyGradeRequirement, QuarterlyGrade>
{
    protected override Task HandleRequirementAsync
        (AuthorizationHandlerContext context, CanViewQuarterlyGradeRequirement requirement, QuarterlyGrade resource)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        // Проверка, что студент, учитель или директор может просматривать оценки
        if (resource.Student.UserId.ToString() == userId ||
            resource.ClassSubject.TeacherId.ToString() == userId ||
            resource.ClassSubject.Class.HomeroomTeacherId.ToString() == userId ||
            context.User.IsInRole("Director"))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
