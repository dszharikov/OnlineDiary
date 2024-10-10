using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Infrastructure.Exceptions;

namespace OnlineDiary.Presentation.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        // База данных
        catch (UniqueConstraintViolationException ex)
        {
            _logger.LogWarning(ex, "Unique constraint violation.");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var problemDetails = new ProblemDetails
            {
                Title = "Validation Error",
                Detail = ex.Message,
                Status = StatusCodes.Status400BadRequest
            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        // Валидация
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Validation errors.");

            // Формирование списка ошибок
            var errors = ex.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );

            var problemDetails = new ValidationProblemDetails(errors)
            {
                Title = "Validation Errors",
                Status = StatusCodes.Status400BadRequest
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        // Не найдено
        catch (NotFoundException ex)
        {
            _logger.LogWarning(ex, "Resource not found.");
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            var problemDetails = new ProblemDetails
            {
                Title = "Not Found",
                Detail = ex.Message,
                Status = StatusCodes.Status404NotFound
            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        // Нет доступа
        catch (AuthorizationException ex)
        {
            _logger.LogWarning(ex, "Authorization error.");
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            var problemDetails = new ProblemDetails
            {
                Title = "Forbidden",
                Detail = ex.Message,
                Status = StatusCodes.Status403Forbidden
            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        // Дублирование данных
        catch (DuplicateException ex){
            _logger.LogWarning(ex, "Duplicate error.");
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            var problemDetails = new ProblemDetails
            {
                Title = "Conflict",
                Detail = ex.Message,
                Status = StatusCodes.Status409Conflict
            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        // Ошибка сервера
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var problemDetails = new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Detail = "Please try again later or contact support.",
                Status = StatusCodes.Status500InternalServerError
            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}