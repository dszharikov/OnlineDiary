using Microsoft.AspNetCore.Authorization;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Infrastructure.Authorization.Requirements.Grades;
using System.Security.Claims;

namespace OnlineDiary.Infrastructure.Authorization.Handlers.Grades;

public class CanViewGradeHandler : AuthorizationHandler<CanViewGradeRequirement, Grade>
{
    protected override Task HandleRequirementAsync
        (AuthorizationHandlerContext context, CanViewGradeRequirement requirement, Grade resource)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        // Проверка, что студент, учитель или директор может просматривать оценки
        if (resource.Student.UserId.ToString() == userId ||
            resource.Lesson.ClassSubject.TeacherId.ToString() == userId ||
            resource.Student.Class.HomeroomTeacherId.ToString() == userId ||
            context.User.IsInRole("Director"))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
