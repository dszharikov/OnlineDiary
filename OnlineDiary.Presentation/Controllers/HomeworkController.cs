using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Presentation.DTOs.HomeworkDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class HomeworkController : BaseController
{
    private readonly IHomeworkService _homeworkService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateHomeworkDto> _createHomeworkValidator;
    private readonly IValidator<UpdateHomeworkDto> _updateHomeworkValidator;

    public HomeworkController(
        IHomeworkService homeworkService, IMapper mapper,
        IValidator<CreateHomeworkDto> createHomeworkValidator,
        IValidator<UpdateHomeworkDto> updateHomeworkValidator)
    {
        _homeworkService = homeworkService;
        _mapper = mapper;
        _createHomeworkValidator = createHomeworkValidator;
        _updateHomeworkValidator = updateHomeworkValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetHomeworks()
    {
        var homeworks = await _homeworkService.GetAllHomeworksAsync();

        return Ok(_mapper.Map<IEnumerable<HomeworkDto>>(homeworks));
    }

    [HttpGet("{homeworkId}")]
    public async Task<IActionResult> GetHomeworkById(Guid homeworkId)
    {
        var homework = await _homeworkService.GetHomeworkByIdAsync(homeworkId);

        return Ok(_mapper.Map<HomeworkDto>(homework));
    }

    [Authorize(Roles = "Student")]
    [HttpGet]
    public async Task<IActionResult> GetActualHomeworks()
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        var homeworks = await _homeworkService.GetActualHomeworksByStudentIdAsync(userId);

        return Ok(_mapper.Map<IEnumerable<HomeworkDto>>(homeworks));
    }

    [HttpGet("/lesson/{lessonId}")]
    public async Task<IActionResult> GetHomeworksByLessonId(Guid lessonId)
    {
        var homework = await _homeworkService.GetHomeworkByLessonIdAsync(lessonId);

        return Ok(_mapper.Map<HomeworkDto>(homework));
    }

    [Authorize(Roles = "Teacher")]
    [HttpPost]
    public async Task<IActionResult> CreateHomework([FromBody] CreateHomeworkDto homeworkDto)
    {
        await ValidateAsync(_createHomeworkValidator, homeworkDto);

        var homework = _mapper.Map<Domain.Entities.Homework>(homeworkDto);

        await _homeworkService.CreateHomeworkAsync(homework);

        return CreatedAtAction(nameof(GetHomeworkById), new { homeworkId = homework.HomeworkId }, homework);
    }

    [Authorize(Roles = "Teacher")]
    [HttpPut("{homeworkId}")]
    public async Task<IActionResult> UpdateHomework(Guid homeworkId, [FromBody] UpdateHomeworkDto homeworkDto)
    {
        await ValidateAsync(_updateHomeworkValidator, homeworkDto);

        var homework = _mapper.Map<Domain.Entities.Homework>(homeworkDto);

        await _homeworkService.UpdateHomeworkAsync(homeworkId, homework);

        return Ok();
    }

    [Authorize(Roles = "Teacher")]
    [HttpDelete("{homeworkId}")]
    public async Task<IActionResult> DeleteHomework(Guid homeworkId)
    {
        await _homeworkService.DeleteHomeworkAsync(homeworkId);

        return Ok();
    }
}
