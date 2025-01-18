using FluentValidation;
using OnlineDiary.Presentation.DTOs.QuarterlyGradeDtos;

namespace OnlineDiary.Presentation.Validations.QuarterlyGradeValidations;

public class CreateQuarterlyGradeDtoValidator : AbstractValidator<CreateQuarterlyGradeDto>
{
    public CreateQuarterlyGradeDtoValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Идентификатор студента обязателен.");
        RuleFor(x => x.ClassSubjectId)
            .NotEmpty().WithMessage("Идентификатор предмета обязателен.");
        RuleFor(x => x.TermId)
            .NotEmpty().WithMessage("Идентификатор срока обязателен.");
        RuleFor(x => x.Comment)
            .MaximumLength(500).WithMessage("Комментарий не может быть длиннее 500 символов.");
    }
}