using FluentValidation;
using OnlineDiary.Presentation.DTOs.HomeworkDtos;

namespace OnlineDiary.Presentation.Validations.HomeworkValidations;

public class UpdateHomeworkDtoValidator : AbstractValidator<UpdateHomeworkDto>
{
    public UpdateHomeworkDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title обязателен.")
            .MaximumLength(150).WithMessage("Title должен быть не более 150 символов.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description обязателен.")
            .MaximumLength(1000).WithMessage("Description должен быть не более 1000 символов.");
    }
}