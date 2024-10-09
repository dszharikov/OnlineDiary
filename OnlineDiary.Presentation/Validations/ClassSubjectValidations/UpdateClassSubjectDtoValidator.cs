using FluentValidation;
using OnlineDiary.Presentation.DTOs.ClassSubjectDtos;

namespace OnlineDiary.Presentation.Validations.ClassSubjectValidations;

public class UpdateClassSubjectDtoValidator : AbstractValidator<UpdateClassSubjectDto>
{
    public UpdateClassSubjectDtoValidator()
    {
        RuleFor(x => x.ClassId)
            .NotEmpty().WithMessage("Идентификатор класса обязателен.");

        RuleFor(x => x.SubjectId)
            .NotEmpty().WithMessage("Идентификатор предмета обязателен.");

        RuleFor(x => x.TeacherId)
            .NotEmpty().WithMessage("Идентификатор учителя обязателен.");
    }
}
