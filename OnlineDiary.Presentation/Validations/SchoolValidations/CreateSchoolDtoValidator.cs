using FluentValidation;
using OnlineDiary.Presentation.DTOs.SchoolDtos;

namespace OnlineDiary.Presentation.Validations.SchoolValidations;

public class CreateSchoolDtoValidator : AbstractValidator<CreateSchoolDto>
{
    public CreateSchoolDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название школы обязательно.")
            .MaximumLength(200).WithMessage("Название школы не может быть длиннее 200 символов.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Адрес школы обязателен.");

        RuleFor(x => x.ContactInfo)
            .NotEmpty().WithMessage("Контактная информация обязательна.")
            .MaximumLength(200).WithMessage("Контактная информация не может быть длиннее 200 символов.");
    }
}
