using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Presentation.DTOs.ClassDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ClassController : BaseController
{
    private readonly IClassService _classService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateClassDto> _createGradeValidator;
    private readonly IValidator<UpdateClassDto> _updateGradeValidator;

    public ClassController(
        IClassService classService, IMapper mapper,
        IValidator<CreateClassDto> createGradeValidator, IValidator<UpdateClassDto> updateGradeValidator)
    {
        _classService = classService;
        _mapper = mapper;
        _createGradeValidator = createGradeValidator;
        _updateGradeValidator = updateGradeValidator;
    }

    [HttpGet]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> GetClasses([FromQuery] PaginationRequestDto paginationRequest)
    {
        var paginationResult = await _classService.GetClasses(paginationRequest);

        var mappedResult = _mapper.Map<PaginationResponseDto<ClassDto>>(paginationResult);

        return Ok(mappedResult);
    }

    // TODO: get classes by teacher id

    // TODO: get class by student id

    [HttpGet("{classId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> GetClassById(Guid classId)
    {
        var classEntity = await _classService.GetClassByIdAsync(classId);

        return Ok(_mapper.Map<ClassDto>(classEntity));
    }

    [HttpPost]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> CreateClass([FromBody] CreateClassDto classDto)
    {
        await ValidateAsync(_createGradeValidator, classDto);

        var classEntity = _mapper.Map<Domain.Entities.Class>(classDto);

        await _classService.CreateClassAsync(classEntity);

        return CreatedAtAction(nameof(GetClassById), new { classId = classEntity.ClassId }, classEntity);
    }

    [HttpPut("{classId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> UpdateClass(Guid classId, [FromBody] UpdateClassDto classDto)
    {
        await ValidateAsync(_updateGradeValidator, classDto);

        var classEntity = _mapper.Map<Domain.Entities.Class>(classDto);

        await _classService.UpdateClassAsync(classId, classEntity);

        return Ok();
    }

    [HttpDelete("{classId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> DeleteClass(Guid classId)
    {
        await _classService.DeleteClassAsync(classId);

        return NoContent();
    }


}
