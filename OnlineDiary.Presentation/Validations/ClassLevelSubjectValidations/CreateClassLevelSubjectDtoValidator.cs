using FluentValidation;
using OnlineDiary.Presentation.DTOs.ClassLevelSubjectDtos;

namespace OnlineDiary.Presentation.Validations.ClassLevelSubjectValidations;

public class CreateClassLevelSubjectDtoValidator : AbstractValidator<CreateClassLevelSubjectDto>
{
    public CreateClassLevelSubjectDtoValidator()
    {
        RuleFor(x => x.ClassLevel)
            .GreaterThan(0).WithMessage("Уровень класса должен быть больше 0.");

        RuleFor(x => x.SubjectId)
            .NotEmpty().WithMessage("Предмет обязателен.");
    }
}
