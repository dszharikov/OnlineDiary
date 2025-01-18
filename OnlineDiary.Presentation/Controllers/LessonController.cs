using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Presentation.DTOs.LessonDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize(Roles = "Director")]
[Route("api/[controller]")]
[ApiController]
public class LessonController : BaseController
{
    private readonly ILessonService _lessonService;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateLessonDto> _updateLessonValidator;

    public LessonController(
        ILessonService lessonService,
        IMapper mapper,
        IValidator<UpdateLessonDto> updateLessonValidator)
    {
        _lessonService = lessonService;
        _mapper = mapper;
        _updateLessonValidator = updateLessonValidator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLessonByIdAsync(Guid id)
    {
        var lesson = await _lessonService.GetLessonByIdAsync(id);

        return Ok(_mapper.Map<LessonDto>(lesson));
    }

    [HttpGet("teacher/{teacherId}/date/{date}")]
    public async Task<IActionResult> GetLessonsByTeacherForWeekAsync(Guid teacherId, DateTime date)
    {
        var lessons = await _lessonService.GetLessonsByTeacherForWeekAsync(teacherId, date);

        return Ok(_mapper.Map<IEnumerable<LessonDto>>(lessons));
    }

    [HttpGet("class/{classId}/date/{date}")]
    public async Task<IActionResult> GetLessonsByClassForWeekAsync(Guid classId, DateTime date)
    {
        var lessons = await _lessonService.GetLessonsByClassForWeekAsync(classId, date);

        return Ok(_mapper.Map<IEnumerable<LessonDto>>(lessons));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLessonAsync(Guid id, UpdateLessonDto updateLessonDto)
    {
        var validationResult = await _updateLessonValidator.ValidateAsync(updateLessonDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var lesson = _mapper.Map<Lesson>(updateLessonDto);

        await _lessonService.UpdateLessonAsync(id, lesson);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLessonAsync(Guid id)
    {
        await _lessonService.DeleteLessonAsync(id);

        return NoContent();
    }
}
