using FluentValidation;
using OnlineDiary.Presentation.DTOs.ScheduleDtos;

namespace OnlineDiary.Presentation.Validations.ScheduleValidations;

public class UpdateScheduleDtoValidator : AbstractValidator<UpdateScheduleDto>
{
    public UpdateScheduleDtoValidator()
    {
        RuleFor(x => x.Time)
            .NotEmpty().WithMessage("Time обязателен.");
        RuleFor(x => x.Room)
            .NotEmpty().WithMessage("Room обязателен.");
    }
}