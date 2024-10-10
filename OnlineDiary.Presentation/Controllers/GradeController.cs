using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Presentation.DTOs.GradeDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GradeController : BaseController
{
    private readonly IGradeService _gradeService;
    private readonly Infrastructure.Services.Authorization.IAuthorizationService _authorizationService;
    private readonly IValidator<CreateGradeDto> _createGradeValidator;
    private readonly IValidator<UpdateGradeDto> _updateGradeValidator;
    private readonly IMapper _mapper;

    public GradeController(IGradeService gradeService,
        Infrastructure.Services.Authorization.IAuthorizationService authorizationService,
        IValidator<CreateGradeDto> createGradeValidator,
        IValidator<UpdateGradeDto> updateGradeValidator,
        IMapper mapper
        )
    {
        _gradeService = gradeService;
        _authorizationService = authorizationService;
        _createGradeValidator = createGradeValidator;
        _updateGradeValidator = updateGradeValidator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Director, Teacher, Student")]
    public async Task<ActionResult<GradeDto>> GetGrade(Guid id)
    {
        var grade = await _gradeService.GetGradeByIdAsync(id);

        var authorized = await _authorizationService.AuthorizeAsync(grade, "CanViewGrade");
        if (!authorized)
        {
            return Forbid();
        }

        return Ok(_mapper.Map<GradeDto>(grade));
    }

    [HttpPost]
    [Authorize(Roles = "Director, Teacher")]
    public async Task<IActionResult> CreateGrade(CreateGradeDto dto)
    {
        await ValidateAsync(_createGradeValidator, dto);

        var grade = _mapper.Map<Grade>(dto);

        var authorized = await _authorizationService.AuthorizeAsync(grade, "CanCreateGrade");
        if (!authorized)
        {
            return Forbid();
        }

        await _gradeService.CreateGradeAsync(grade);
        return CreatedAtAction(nameof(GetGrade), new { id = grade.GradeId }, dto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Director, Teacher")]
    public async Task<IActionResult> EditGrade(Guid id, UpdateGradeDto dto)
    {
        await ValidateAsync(_updateGradeValidator, dto);
        
        var grade = _mapper.Map<Grade>(dto);

        var authorized = await _authorizationService.AuthorizeAsync(grade, "CanEditGrade");
        if (!authorized)
        {
            return Forbid();
        }


        await _gradeService.UpdateGradeAsync(id, grade);
        return NoContent();
    }
}
