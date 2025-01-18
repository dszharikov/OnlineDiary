using FluentValidation;
using OnlineDiary.Presentation.DTOs.LessonDtos;

namespace OnlineDiary.Presentation.Validations.LessonValidations;

public class UpdateLessonDtoValidator : AbstractValidator<UpdateLessonDto>
{
    public UpdateLessonDtoValidator()
    {
        RuleFor(x => x.Topic)
            .MaximumLength(150).WithMessage("Topic не должен превышать 150 символов.");
    }
}