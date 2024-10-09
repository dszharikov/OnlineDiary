using FluentValidation;
using OnlineDiary.Presentation.DTOs.ClassDtos;

namespace OnlineDiary.Presentation.Validations.ClassValidations;

public class CreateClassDtoValidator : AbstractValidator<CreateClassDto>
{
    public CreateClassDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название класса обязательно.")
            .MaximumLength(100).WithMessage("Название класса не может быть длиннее 100 символов.");

        RuleFor(x => x.ClassLevel)
            .GreaterThan(0).WithMessage("Уровень класса должен быть больше 0.");

        RuleFor(x => x.HomeroomTeacherId)
            .NotEmpty().WithMessage("Классный руководитель обязателен.");
    }
}
