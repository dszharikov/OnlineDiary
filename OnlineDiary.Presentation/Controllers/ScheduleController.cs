using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Presentation.DTOs.ScheduleDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize(Roles = "Director, Teacher")]
[Route("api/[controller]")]
[ApiController]
public class ScheduleController : BaseController
{
    private readonly IScheduleService _scheduleService;
    private readonly IClassSubjectService _classSubjectService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateScheduleDto> _createScheduleValidator;
    private readonly IValidator<UpdateScheduleDto> _updateScheduleValidator;

    public ScheduleController(
        IScheduleService scheduleService,
        IClassSubjectService classSubjectService, 
        IMapper mapper,
        IValidator<CreateScheduleDto> createScheduleValidator,
        IValidator<UpdateScheduleDto> updateScheduleValidator)
    {
        _scheduleService = scheduleService;
        _classSubjectService = classSubjectService;
        _mapper = mapper;
        _createScheduleValidator = createScheduleValidator;
        _updateScheduleValidator = updateScheduleValidator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetScheduleByIdAsync(Guid id)
    {
        var schedule = await _scheduleService.GetScheduleByIdAsync(id);

        return Ok(_mapper.Map<ScheduleDto>(schedule));
    }

    [HttpGet("term/{termId}/class/{classId}")]
    public async Task<IActionResult> GetSchedulesByTermClassAsync(Guid termId, Guid classId)
    {
        var schedules = await _scheduleService.GetSchedulesByTermClassAsync(termId, classId);

        return Ok(_mapper.Map<IEnumerable<ScheduleDto>>(schedules));
    }

    [HttpGet("term/{termId}/teacher/{teacherId}")]
    public async Task<IActionResult> GetSchedulesByTermTeacherAsync(Guid termId, Guid teacherId)
    {
        var schedules = await _scheduleService.GetSchedulesByTermTeacherAsync(termId, teacherId);

        return Ok(_mapper.Map<IEnumerable<ScheduleDto>>(schedules));
    }

    [HttpPost]
    public async Task<IActionResult> CreateScheduleAsync([FromBody] CreateScheduleDto createScheduleDto)
    {
        var validationResult = await _createScheduleValidator.ValidateAsync(createScheduleDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var classSubject = await _classSubjectService.GetClassSubjectByClassIdAndSubjectIdAsync(createScheduleDto.ClassId, createScheduleDto.SubjectId);

        var schedule = _mapper.Map<Schedule>(createScheduleDto);
        schedule.ClassSubjectId = classSubject.ClassSubjectId;

        await _scheduleService.CreateScheduleAsync(schedule);

        return CreatedAtAction(nameof(GetScheduleByIdAsync), new { id = schedule.ScheduleId }, _mapper.Map<ScheduleDto>(schedule));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateScheduleAsync(Guid id, [FromBody] UpdateScheduleDto updateScheduleDto)
    {
        var validationResult = await _updateScheduleValidator.ValidateAsync(updateScheduleDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var schedule = _mapper.Map<Schedule>(updateScheduleDto);

        await _scheduleService.UpdateScheduleAsync(id, schedule);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScheduleAsync(Guid id)
    {
        await _scheduleService.DeleteScheduleAsync(id);

        return NoContent();
    }
}
