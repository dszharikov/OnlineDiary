using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Filters.ClassSubjects;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Presentation.DTOs.ClassSubjectDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ClassSubjectController : BaseController
{
    private readonly IClassSubjectService _classSubjectService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateClassSubjectDto> _createClassSubjectValidator;
    private readonly IValidator<UpdateClassSubjectDto> _updateClassSubjectValidator;

    public ClassSubjectController(
        IClassSubjectService classSubjectService, IMapper mapper,
        IValidator<CreateClassSubjectDto> createClassSubjectValidator,
        IValidator<UpdateClassSubjectDto> updateClassSubjectValidator)
    {
        _classSubjectService = classSubjectService;
        _mapper = mapper;
        _createClassSubjectValidator = createClassSubjectValidator;
        _updateClassSubjectValidator = updateClassSubjectValidator;
    }

    [HttpGet]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> GetClassSubjects(
        [FromQuery] PaginationAndFilterRequestDto<ClassSubjectFilterRequestDto> paginationAndFilterRequest)
    {
        var classSubjects = await _classSubjectService.GetClassSubjectsAsync(paginationAndFilterRequest);

        var mappedResult = _mapper.Map<PaginationResponseDto<ClassSubjectDto>>(classSubjects);

        return Ok(mappedResult);
    }

    [HttpGet("class/{classId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> GetClassSubjectsByClassId(Guid classId)
    {
        var classSubjects = await _classSubjectService.GetClassSubjectsByClassIdAsync(classId);

        return Ok(_mapper.Map<IEnumerable<ClassSubjectDto>>(classSubjects));
    }

    [HttpGet("{classSubjectId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> GetClassSubjectById(Guid classSubjectId)
    {
        var classSubject = await _classSubjectService.GetClassSubjectByIdAsync(classSubjectId);

        return Ok(_mapper.Map<ClassSubjectDto>(classSubject));
    }

    [HttpPost]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> CreateClassSubject([FromBody] CreateClassSubjectDto classSubjectDto)
    {
        await ValidateAsync(_createClassSubjectValidator, classSubjectDto);

        var classSubject = _mapper.Map<Domain.Entities.ClassSubject>(classSubjectDto);

        await _classSubjectService.CreateClassSubjectAsync(classSubject);

        return CreatedAtAction(nameof(GetClassSubjectById),
            new { classSubjectId = classSubject.ClassSubjectId }, classSubject);
    }

    [HttpPut("{classSubjectId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> UpdateClassSubject(Guid classSubjectId,
        [FromBody] UpdateClassSubjectDto classSubjectDto)
    {
        await ValidateAsync(_updateClassSubjectValidator, classSubjectDto);

        var classSubject = _mapper.Map<Domain.Entities.ClassSubject>(classSubjectDto);

        await _classSubjectService.UpdateClassSubjectAsync(classSubjectId, classSubject);

        return Ok();
    }

    [HttpDelete("{classSubjectId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> DeleteClassSubject(Guid classSubjectId)
    {
        await _classSubjectService.DeleteClassSubjectAsync(classSubjectId);

        return NoContent();
    }
}
