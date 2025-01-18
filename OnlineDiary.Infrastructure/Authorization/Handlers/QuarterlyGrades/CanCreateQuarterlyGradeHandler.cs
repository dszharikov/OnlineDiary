using Microsoft.AspNetCore.Authorization;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Infrastructure.Authorization.Requirements.QuarterlyGrades;
using System.Security.Claims;

namespace OnlineDiary.Infrastructure.Authorization.Handlers.QuarterlyGrades;

public class CanCreateQuarterlyGradeHandler : AuthorizationHandler<CanCreateQuarterlyGradeRequirement, QuarterlyGrade>
{
    private readonly IUnitOfWork _unitOfWork;

    public CanCreateQuarterlyGradeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        CanCreateQuarterlyGradeRequirement requirement, 
        QuarterlyGrade resource)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var classSubject = await _unitOfWork.ClassSubjects.GetByIdAsync(resource.ClassSubjectId);

        if (classSubject == null)
        {
            context.Fail();
            return;
        }

        // Проверка, что пользователь является учителем, который ведет предмет у ученика, или директором
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
