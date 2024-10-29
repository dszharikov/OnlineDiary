using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Presentation.DTOs.SubjectSubcategoryDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize(Roles = "Director")]
[Route("api/[controller]")]
[ApiController]
public class SubjectSubcategoryController : BaseController
{
    private readonly ISubjectSubcategoryService _subjectSubcategoryService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateSubjectSubcategoryDto> _createSubjectSubcategoryValidator;
    private readonly IValidator<UpdateSubjectSubcategoryDto> _updateSubjectSubcategoryValidator;

    public SubjectSubcategoryController(
        ISubjectSubcategoryService subjectSubcategoryService, IMapper mapper,
        IValidator<CreateSubjectSubcategoryDto> createSubjectSubcategoryValidator,
        IValidator<UpdateSubjectSubcategoryDto> updateSubjectSubcategoryValidator)
    {
        _subjectSubcategoryService = subjectSubcategoryService;
        _mapper = mapper;
        _createSubjectSubcategoryValidator = createSubjectSubcategoryValidator;
        _updateSubjectSubcategoryValidator = updateSubjectSubcategoryValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetSubjectSubcategories()
    {
        var subjectSubcategories = await _subjectSubcategoryService.GetAllSubcategoriesAsync();

        return Ok(_mapper.Map<IEnumerable<SubjectSubcategoryDto>>(subjectSubcategories));
    }

    [HttpGet("{subjectSubcategoryId}")]
    public async Task<IActionResult> GetSubjectSubcategoryById(Guid subjectSubcategoryId)
    {
        var subjectSubcategory = await _subjectSubcategoryService.GetSubcategoryByIdAsync(subjectSubcategoryId);

        return Ok(_mapper.Map<SubjectSubcategoryDto>(subjectSubcategory));
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubjectSubcategory([FromBody] CreateSubjectSubcategoryDto subjectSubcategoryDto)
    {
        await ValidateAsync(_createSubjectSubcategoryValidator, subjectSubcategoryDto);

        var subjectSubcategory = _mapper.Map<Domain.Entities.SubjectSubcategory>(subjectSubcategoryDto);

        await _subjectSubcategoryService.CreateSubcategoryAsync(subjectSubcategory);

        return CreatedAtAction(nameof(GetSubjectSubcategoryById),
            new { subjectSubcategoryId = subjectSubcategory.SubcategoryId }, subjectSubcategory);
    }

    [HttpPut("{subjectSubcategoryId}")]
    public async Task<IActionResult> UpdateSubjectSubcategory(Guid subjectSubcategoryId, [FromBody] UpdateSubjectSubcategoryDto subjectSubcategoryDto)
    {
        await ValidateAsync(_updateSubjectSubcategoryValidator, subjectSubcategoryDto);

        var subjectSubcategory = _mapper.Map<Domain.Entities.SubjectSubcategory>(subjectSubcategoryDto);

        await _subjectSubcategoryService.UpdateSubcategoryAsync(subjectSubcategoryId, subjectSubcategory);

        return Ok();
    }

    [HttpDelete("{subjectSubcategoryId}")]
    public async Task<IActionResult> DeleteSubjectSubcategory(Guid subjectSubcategoryId)
    {
        await _subjectSubcategoryService.DeleteSubcategoryAsync(subjectSubcategoryId);

        return Ok();
    }
}
