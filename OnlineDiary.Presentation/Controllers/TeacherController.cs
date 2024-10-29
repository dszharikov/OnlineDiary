using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Filters.Teachers;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Presentation.DTOs.TeacherDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize(Roles = "Director")]
[Route("api/[controller]")]
[ApiController]
public class TeacherController : BaseController
{
    private readonly ITeacherService _teacherService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTeacherDto> _createTeacherValidator;
    private readonly IValidator<UpdateTeacherDto> _updateTeacherValidator;

    public TeacherController(
        ITeacherService teacherService, IMapper mapper,
        IValidator<CreateTeacherDto> createTeacherValidator, IValidator<UpdateTeacherDto> updateTeacherValidator)
    {
        _teacherService = teacherService;
        _mapper = mapper;
        _createTeacherValidator = createTeacherValidator;
        _updateTeacherValidator = updateTeacherValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeachers(
        [FromQuery] PaginationAndFilterRequestDto<TeacherFilterRequestDto> paginationRequest)
    {
        var paginationResult = await _teacherService.GetAllTeachersAsync(paginationRequest);

        var mappedResult = _mapper.Map<PaginationResponseDto<TeacherDto>>(paginationResult);

        return Ok(mappedResult);
    }

    [HttpGet("{teacherId}")]
    public async Task<IActionResult> GetTeacherById(Guid teacherId)
    {
        var teacher = await _teacherService.GetTeacherByIdAsync(teacherId);

        return Ok(_mapper.Map<TeacherDto>(teacher));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherDto teacherDto)
    {
        await ValidateAsync(_createTeacherValidator, teacherDto);

        var teacher = _mapper.Map<Domain.Entities.Teacher>(teacherDto);

        await _teacherService.CreateTeacherAsync(teacher);

        return CreatedAtAction(nameof(GetTeacherById),
            new { teacherId = teacher.UserId }, teacher);
    }

    [HttpPut("{teacherId}")]
    public async Task<IActionResult> UpdateTeacher(Guid teacherId, [FromBody] UpdateTeacherDto teacherDto)
    {
        await ValidateAsync(_updateTeacherValidator, teacherDto);

        var teacher = _mapper.Map<Domain.Entities.Teacher>(teacherDto);

        await _teacherService.UpdateTeacherAsync(teacherId, teacher);

        return Ok();
    }

    [HttpDelete("{teacherId}")]
    public async Task<IActionResult> DeleteTeacher(Guid teacherId)
    {
        await _teacherService.DeleteTeacherAsync(teacherId);

        return NoContent();
    }
}
