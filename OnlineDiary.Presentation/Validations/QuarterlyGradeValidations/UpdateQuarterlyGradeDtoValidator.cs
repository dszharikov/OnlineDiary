using FluentValidation;
using OnlineDiary.Presentation.DTOs.QuarterlyGradeDtos;

namespace OnlineDiary.Presentation.Validations.QuarterlyGradeValidations;

public class UpdateQuarterlyGradeDtoValidator : AbstractValidator<UpdateQuarterlyGradeDto>
{
    public UpdateQuarterlyGradeDtoValidator()
    {
        RuleFor(x => x.Comment)
            .MaximumLength(500).WithMessage("Комментарий не может быть длиннее 500 символов.");
    }
}