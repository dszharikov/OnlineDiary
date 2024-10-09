using FluentValidation;
using OnlineDiary.Presentation.DTOs.UserDtos;

namespace OnlineDiary.Presentation.Validations.UserValidations;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Имя обязательно.")
            .MaximumLength(100).WithMessage("Имя не может быть длиннее 100 символов.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Фамилия обязательна.")
            .MaximumLength(100).WithMessage("Фамилия не может быть длиннее 100 символов.");

        RuleFor(x => x.Password)
            .MinimumLength(8).WithMessage("Пароль должен содержать не менее 8 символов.")
            .When(x => !string.IsNullOrEmpty(x.Password));
    }
}
