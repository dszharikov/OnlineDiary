using FluentValidation;
using OnlineDiary.Presentation.DTOs.UserDtos;

namespace OnlineDiary.Presentation.Validations.UserValidations;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Идентификатор пользователя обязателен.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Имя обязательно.")
            .MaximumLength(100).WithMessage("Имя не может быть длиннее 100 символов.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Фамилия обязательна.")
            .MaximumLength(100).WithMessage("Фамилия не может быть длиннее 100 символов.");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("Указана недопустимая роль пользователя.");
    }
}
