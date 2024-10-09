using FluentValidation;
using OnlineDiary.Presentation.DTOs.DirectorDtos;

namespace OnlineDiary.Presentation.Validations.DirectorValidations;

public class CreateDirectorDtoValidator : AbstractValidator<CreateDirectorDto>
{
    public CreateDirectorDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Имя обязательно.")
            .MaximumLength(100).WithMessage("Имя не может быть длиннее 100 символов.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Фамилия обязательна.")
            .MaximumLength(100).WithMessage("Фамилия не может быть длиннее 100 символов.");

        RuleFor(x => x.SchoolId)
            .NotEmpty().WithMessage("Идентификатор школы обязателен.");
    }
}
