using FluentValidation;
using OnlineDiary.Presentation.DTOs.SubjectDtos;

namespace OnlineDiary.Presentation.Validations.SubjectValidations;

public class UpdateSubjectDtoValidator : AbstractValidator<UpdateSubjectDto>
{
    public UpdateSubjectDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название предмета обязательно.")
            .MaximumLength(100).WithMessage("Название предмета не может быть длиннее 100 символов.");
    }
}
