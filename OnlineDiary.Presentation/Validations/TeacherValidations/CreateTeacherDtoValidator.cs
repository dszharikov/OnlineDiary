using FluentValidation;
using OnlineDiary.Presentation.DTOs.TeacherDtos;

namespace OnlineDiary.Presentation.Validations.TeacherValidations;

public class CreateTeacherDtoValidator : AbstractValidator<CreateTeacherDto>
{
    public CreateTeacherDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Имя обязательно.")
            .MaximumLength(100).WithMessage("Имя не может быть длиннее 100 символов.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Фамилия обязательна.")
            .MaximumLength(100).WithMessage("Фамилия не может быть длиннее 100 символов.");
    }
}
