using Microsoft.AspNetCore.Authorization;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Infrastructure.Authorization.Requirements.Grade;
using System.Security.Claims;

namespace OnlineDiary.Infrastructure.Authorization.Handlers;

public class CanCreateGradeHandler : AuthorizationHandler<CanCreateGradeRequirement, Grade>
{
    private readonly IUnitOfWork _unitOfWork;

    public CanCreateGradeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanCreateGradeRequirement requirement, Grade resource)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var lesson = await _unitOfWork.Lessons.GetByIdAsync(resource.LessonId);

        if (lesson == null)
        {
            context.Fail();
            return;
        }

        // Проверка, что пользователь является учителем, который ведет предмет у ученика, или директором
        if (lesson.ClassSubject.TeacherId.ToString() == userId || context.User.IsInRole("Director"))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}
