using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Filters.Subjects;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Presentation.DTOs.SubjectDtos;

namespace OnlineDiary.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController : BaseController
{
    private readonly IMapper _mapper;
    private readonly ISubjectService _subjectService;
    private readonly IValidator<CreateSubjectDto> _createSubjectValidator;
    private readonly IValidator<UpdateSubjectDto> _updateSubjectValidator;

    public SubjectController(
        IMapper mapper, 
        ISubjectService subjectService,
        IValidator<CreateSubjectDto> createSubjectValidator, 
        IValidator<UpdateSubjectDto> updateSubjectValidator)
    {
        _mapper = mapper;
        _subjectService = subjectService;
        _createSubjectValidator = createSubjectValidator;
        _updateSubjectValidator = updateSubjectValidator;
    }

    [Authorize(Roles = "Director")]
    [HttpGet]
    public async Task<IActionResult> GetSubjects([FromQuery] PaginationAndFilterRequestDto<SubjectFilterRequestDto> paginationAndFilterRequest)
    {
        var subjects = await _subjectService.GetSubjectsAsync(paginationAndFilterRequest);

        var mappedResult = _mapper.Map<PaginationResponseDto<SubjectDto>>(subjects);

        return Ok(mappedResult);
    }

    [Authorize(Roles = "Director")]
    [HttpGet("{subjectId}")]
    public async Task<IActionResult> GetSubjectById(Guid subjectId)
    {
        var subject = await _subjectService.GetSubjectByIdAsync(subjectId);

        return Ok(_mapper.Map<SubjectDto>(subject));
    }

    [Authorize(Roles = "Director")]
    [HttpPost]
    public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDto subjectDto)
    {
        await ValidateAsync(_createSubjectValidator, subjectDto);

        var subject = _mapper.Map<Domain.Entities.Subject>(subjectDto);

        await _subjectService.CreateSubjectAsync(subject);

        return CreatedAtAction(nameof(GetSubjectById), new { subjectId = subject.SubjectId }, subject);
    }

    [Authorize(Roles = "Director")]
    [HttpPut("{subjectId}")]
    public async Task<IActionResult> UpdateSubject(Guid subjectId, [FromBody] UpdateSubjectDto subjectDto)
    {
        await ValidateAsync(_updateSubjectValidator, subjectDto);

        var subject = _mapper.Map<Domain.Entities.Subject>(subjectDto);

        await _subjectService.UpdateSubjectAsync(subjectId, subject);

        return NoContent();
    }

    [Authorize(Roles = "Director")]
    [HttpDelete("{subjectId}")]
    public async Task<IActionResult> DeleteSubject(Guid subjectId)
    {
        await _subjectService.DeleteSubjectAsync(subjectId);

        return NoContent();
    }
}
