using FluentValidation;
using OnlineDiary.Presentation.DTOs.ScheduleDtos;

namespace OnlineDiary.Presentation.Validations.ScheduleValidations;

public class CreateScheduleDtoValidator : AbstractValidator<CreateScheduleDto>
{
    public CreateScheduleDtoValidator()
    {
        RuleFor(x => x.ClassId)
            .NotEmpty().WithMessage("ClassSubjectId обязателен.");
        RuleFor(x => x.SubjectId)
            .NotEmpty().WithMessage("SubjectId обязателен.");
        RuleFor(x => x.DayOfWeek)
            .NotEmpty().WithMessage("DayOfWeek обязателен.");
        RuleFor(x => x.Time)
            .NotEmpty().WithMessage("Time обязателен.");
        RuleFor(x => x.Room)
            .MaximumLength(50).WithMessage("Room не должен превышать 50 символов.");
        RuleFor(x => x.TermId)
            .NotEmpty().WithMessage("TermId обязателен.");
    }
}