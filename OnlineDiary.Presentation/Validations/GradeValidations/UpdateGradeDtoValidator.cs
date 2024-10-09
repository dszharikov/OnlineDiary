using FluentValidation;
using OnlineDiary.Presentation.DTOs.GradeDtos;

namespace OnlineDiary.Presentation.Validations.GradeValidations;

public class UpdateGradeDtoValidator : AbstractValidator<UpdateGradeDto>
{
    public UpdateGradeDtoValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Оценка обязательна.")
            .MaximumLength(20).WithMessage("Оценка не может быть длиннее 20 символов.");
    }
}
