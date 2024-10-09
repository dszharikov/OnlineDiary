using FluentValidation;
using OnlineDiary.Presentation.DTOs.GradeDtos;

namespace OnlineDiary.Presentation.Validations.GradeValidations;

public class CreateGradeDtoValidator : AbstractValidator<CreateGradeDto>
{
    public CreateGradeDtoValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Идентификатор студента обязателен.");

        RuleFor(x => x.LessonId)
            .NotEmpty().WithMessage("Идентификатор урока обязателен.");

        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Оценка обязательна.")
            .MaximumLength(20).WithMessage("Оценка не может быть длиннее 20 символов.");
    }
}
