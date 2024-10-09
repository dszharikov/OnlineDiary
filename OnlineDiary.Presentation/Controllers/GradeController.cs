using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Presentation.DTOs.GradeDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class GradeController : BaseController
{
    private readonly IGradeService _gradeService;

    public GradeController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpGet("{gradeId}")]
    public async Task<IActionResult> GetGradeById(Guid gradeId)
    {
        var gradeDto = await _gradeService.GetGradeByIdAsync(gradeId);

        // TODO: check authorization

        return Ok(gradeDto);
    }
    [Authorize(Roles = "Teacher")]
    [HttpPost]
    public async Task<IActionResult> CreateGrade(CreateGradeDto dto)
    {
        
        await _gradeService.CreateGradeAsync(dto);

        return CreatedAtAction();
    }
}
