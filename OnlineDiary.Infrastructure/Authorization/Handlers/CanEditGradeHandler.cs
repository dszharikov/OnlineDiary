using Microsoft.AspNetCore.Authorization;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Infrastructure.Authorization.Requirements.Grade;
using System.Security.Claims;

namespace OnlineDiary.Infrastructure.Authorization.Handlers;

public class CanEditGradeHandler : AuthorizationHandler<CanEditGradeRequirement, Grade>
{
    private readonly IUnitOfWork _unitOfWork;

    public CanEditGradeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanEditGradeRequirement requirement, Grade resource)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var lesson = await _unitOfWork.Lessons.GetByIdAsync(resource.LessonId);

        // Проверка, что учитель, который поставил оценку, может ее редактировать
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
