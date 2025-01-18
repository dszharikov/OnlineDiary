using Microsoft.AspNetCore.Authorization;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Infrastructure.Authorization.Requirements.QuarterlyGrades;
using System.Security.Claims;

namespace OnlineDiary.Infrastructure.Authorization.Handlers.QuarterlyGrades;

public class CanEditQuarterlyGradeHandler : AuthorizationHandler<CanEditQuarterlyGradeRequirement, QuarterlyGrade>
{
    private readonly IUnitOfWork _unitOfWork;

    public CanEditQuarterlyGradeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        CanEditQuarterlyGradeRequirement requirement, 
        QuarterlyGrade resource)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var classSubject = resource.ClassSubject;

        // Проверка, что учитель, который поставил оценку, может ее редактировать
        if (classSubject.TeacherId.ToString() == userId || context.User.IsInRole("Director"))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}
