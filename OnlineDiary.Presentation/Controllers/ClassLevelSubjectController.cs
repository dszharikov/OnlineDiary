using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Filters.ClassLevelSubjects;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Presentation.DTOs.ClassLevelSubjectDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize(Roles = "Director")]
[Route("api/[controller]")]
[ApiController]
public class ClassLevelSubjectController : BaseController
{
    private readonly IClassLevelSubjectService _classLevelSubjectService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateClassLevelSubjectDto> _createClassLevelSubjectValidator;
    private readonly IValidator<UpdateClassLevelSubjectDto> _updateClassLevelSubjectValidator;

    public ClassLevelSubjectController(
        IClassLevelSubjectService classLevelSubjectService, 
        IMapper mapper,
        IValidator<CreateClassLevelSubjectDto> createClassLevelSubjectValidator,
        IValidator<UpdateClassLevelSubjectDto> updateClassLevelSubjectValidator)
    {
        _classLevelSubjectService = classLevelSubjectService;
        _mapper = mapper;
        _createClassLevelSubjectValidator = createClassLevelSubjectValidator;
        _updateClassLevelSubjectValidator = updateClassLevelSubjectValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetClassLevelSubjects(
        [FromQuery] PaginationAndFilterRequestDto<ClassLevelSubjectFilterRequestDto> paginationAndFilterRequest)
    {
        var paginationResult = await _classLevelSubjectService.GetClassLevelSubjectsAsync(paginationAndFilterRequest);

        var mappedResult = _mapper.Map<PaginationResponseDto<ClassLevelSubjectDto>>(paginationResult);

        return Ok(mappedResult);
    }

    [HttpGet("{classLevelSubjectId}")]
    public async Task<IActionResult> GetClassLevelSubjectById(Guid classLevelSubjectId)
    {
        var classLevelSubject = await _classLevelSubjectService.GetClassLevelSubjectByIdAsync(classLevelSubjectId);

        return Ok(_mapper.Map<ClassLevelSubjectDto>(classLevelSubject));
    }

    [HttpPost]
    public async Task<IActionResult> CreateClassLevelSubject([FromBody] CreateClassLevelSubjectDto classLevelSubjectDto)
    {
        await ValidateAsync(_createClassLevelSubjectValidator, classLevelSubjectDto);

        var classLevelSubject = _mapper.Map<Domain.Entities.ClassLevelSubject>(classLevelSubjectDto);

        await _classLevelSubjectService.CreateClassLevelSubjectAsync(classLevelSubject);

        return CreatedAtAction(nameof(GetClassLevelSubjectById),
            new { classLevelSubjectId = classLevelSubject.ClassLevelSubjectId }, classLevelSubject);
    }

    [HttpPut("{classLevelSubjectId}")]
    public async Task<IActionResult> UpdateClassLevelSubject(Guid classLevelSubjectId,
        [FromBody] UpdateClassLevelSubjectDto classLevelSubjectDto)
    {
        await ValidateAsync(_updateClassLevelSubjectValidator, classLevelSubjectDto);

        var classLevelSubject = _mapper.Map<Domain.Entities.ClassLevelSubject>(classLevelSubjectDto);

        await _classLevelSubjectService.UpdateClassLevelSubjectAsync(classLevelSubjectId, classLevelSubject);

        return Ok();
    }

    [HttpDelete("{classLevelSubjectId}")]
    public async Task<IActionResult> DeleteClassLevelSubject(Guid classLevelSubjectId)
    {
        await _classLevelSubjectService.DeleteClassLevelSubjectAsync(classLevelSubjectId);

        return NoContent();
    }
}
