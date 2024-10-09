using FluentValidation;
using OnlineDiary.Presentation.DTOs.TermDtos;

namespace OnlineDiary.Presentation.Validations.TermValidations;

public class CreateTermDtoValidator : AbstractValidator<CreateTermDto>
{
    public CreateTermDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название обязательно.")
            .MaximumLength(100).WithMessage("Название не может быть длиннее 100 символов.");

        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate).WithMessage("Дата начала должна быть меньше даты окончания.");
    }
}
