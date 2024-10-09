using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace OnlineDiary.Presentation.Controllers;

public abstract class BaseController : ControllerBase
{
    protected async Task ValidateAsync<T>(IValidator<T> validator, T dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }
}