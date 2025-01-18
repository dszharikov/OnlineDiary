using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Presentation.DTOs.QuarterlyGradeDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class QuarterlyGradeController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IQuarterlyGradeService _quarterlyGradeService;
    private readonly IValidator<CreateQuarterlyGradeDto> _createQuarterlyGradeValidator;
    private readonly IValidator<UpdateQuarterlyGradeDto> _updateQuarterlyGradeValidator;
    private readonly Infrastructure.Services.Authorization.IAuthorizationService _authorizationService;

    public QuarterlyGradeController(
        IMapper mapper,
        IQuarterlyGradeService quarterlyGradeService,
        IValidator<CreateQuarterlyGradeDto> createQuarterlyGradeValidator,
        IValidator<UpdateQuarterlyGradeDto> updateQuarterlyGradeValidator,
        Infrastructure.Services.Authorization.IAuthorizationService authorizationService)
    {
        _mapper = mapper;
        _quarterlyGradeService = quarterlyGradeService;
        _createQuarterlyGradeValidator = createQuarterlyGradeValidator;
        _updateQuarterlyGradeValidator = updateQuarterlyGradeValidator;
        _authorizationService = authorizationService;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Director, Teacher, Student")]
    public async Task<ActionResult<QuarterlyGradeDto>> GetQuarterlyGrade(Guid id)
    {
        var quarterlyGrade = await _quarterlyGradeService.GetQuarterlyGradeByIdAsync(id);

        var authorized = await _authorizationService.AuthorizeAsync(quarterlyGrade, "CanViewQuarterlyGrade");
        if (!authorized)
        {
            return Forbid();
        }

        return Ok(_mapper.Map<QuarterlyGradeDto>(quarterlyGrade));
    }

    [HttpGet("classSubjects/{classSubjectId}/term/{termId}")]
    [Authorize(Roles = "Director, Teacher")]
    public async Task<ActionResult<IEnumerable<QuarterlyGradeDto>>> GetQuarterlyGradesByClassSubjectAndTerm(
        Guid classSubjectId, Guid termId)
    {
        var quarterlyGrades = await _quarterlyGradeService.GetQuarterlyGradesByClassSubjectAndTermAsync(classSubjectId, termId);

        var firstGrade = quarterlyGrades.FirstOrDefault();

        if (firstGrade is not null)
        {
            var authorized = await _authorizationService.AuthorizeAsync(firstGrade, "CanViewQuarterlyGrade");
            if (!authorized)
            {
                return Forbid();
            }
        }
        return Ok(_mapper.Map<IEnumerable<QuarterlyGradeDto>>(quarterlyGrades));
    }

    [HttpGet("students/{studentId}/term/{termId}")]
    [Authorize(Roles = "Director, Student")]
    public async Task<ActionResult<IEnumerable<QuarterlyGradeDto>>>
        GetQuarterlyGradesByStudentIdTermId(Guid studentId, Guid termId)
    {
        var quarterlyGrades = await _quarterlyGradeService.GetQuarterlyGradesByStudentIdTermIdAsync(studentId, termId);

        var firstGrade = quarterlyGrades.FirstOrDefault();

        if (firstGrade is not null)
        {
            var authorized = await _authorizationService.AuthorizeAsync(firstGrade, "CanViewQuarterlyGrade");
            if (!authorized)
            {
                return Forbid();
            }
        }
        return Ok(_mapper.Map<IEnumerable<QuarterlyGradeDto>>(quarterlyGrades));
    }

    [HttpPost]
    [Authorize(Roles = "Director, Teacher")]
    public async Task<IActionResult> CreateQuarterlyGrade(CreateQuarterlyGradeDto dto)
    {
        await ValidateAsync(_createQuarterlyGradeValidator, dto);

        var quarterlyGrade = _mapper.Map<QuarterlyGrade>(dto);

        var authorized = await _authorizationService.AuthorizeAsync(quarterlyGrade, "CanCreateQuarterlyGrade");
        if (!authorized)
        {
            return Forbid();
        }

        await _quarterlyGradeService.CreateQuarterlyGradeAsync(quarterlyGrade);

        return CreatedAtAction(nameof(GetQuarterlyGrade), new { id = quarterlyGrade.QuarterlyGradeId },
            _mapper.Map<QuarterlyGradeDto>(quarterlyGrade));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Director, Teacher")]
    public async Task<IActionResult> EditQuarterlyGrade(Guid id, UpdateQuarterlyGradeDto dto)
    {
        await ValidateAsync(_updateQuarterlyGradeValidator, dto);

        var quarterlyGrade = await _quarterlyGradeService.GetQuarterlyGradeByIdAsync(id);

        var authorized = await _authorizationService.AuthorizeAsync(quarterlyGrade, "CanEditQuarterlyGrade");
        if (!authorized)
        {
            return Forbid();
        }

        _mapper.Map(dto, quarterlyGrade);

        await _quarterlyGradeService.UpdateQuarterlyGradeAsync(quarterlyGrade);

        return NoContent();
    }
}
