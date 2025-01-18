using Microsoft.AspNetCore.Authorization;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Infrastructure.Authorization.Requirements.Grades;
using System.Security.Claims;

namespace OnlineDiary.Infrastructure.Authorization.Handlers.Grades;

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

        var lesson = resource.Lesson;

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
