using FluentValidation;
using OnlineDiary.Presentation.DTOs.SubjectSubcategoryDtos;

namespace OnlineDiary.Presentation.Validations.SubjectSubcategoryValidations;

public class UpdateSubjectSubcategoryDtoValidator : AbstractValidator<UpdateSubjectSubcategoryDto>
{
    public UpdateSubjectSubcategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название подкатегории обязательно.")
            .MaximumLength(100).WithMessage("Название подкатегории не может быть длиннее 100 символов.");
    }
}
