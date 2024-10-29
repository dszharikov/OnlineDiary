using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Presentation.DTOs.DirectorDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DirectorController : BaseController
{
    private readonly IDirectorService _directorService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateDirectorDto> _createDirectorValidator;
    private readonly IValidator<UpdateDirectorDto> _updateDirectorValidator;

    public DirectorController(
        IDirectorService directorService, IMapper mapper,
        IValidator<CreateDirectorDto> createDirectorValidator, IValidator<UpdateDirectorDto> updateDirectorValidator)
    {
        _directorService = directorService;
        _mapper = mapper;
        _createDirectorValidator = createDirectorValidator;
        _updateDirectorValidator = updateDirectorValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetDirector()
    {
        var director = await _directorService.GetCurrentDirectorAsync();

        return Ok(_mapper.Map<DirectorDto>(director));
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public async Task<IActionResult> CreateDirector([FromBody] CreateDirectorDto directorDto)
    {
        await ValidateAsync(_createDirectorValidator, directorDto);

        var director = _mapper.Map<Domain.Entities.Director>(directorDto);

        await _directorService.CreateDirectorAsync(director);

        return CreatedAtAction(nameof(GetDirector), director);
    }

    [Authorize(Roles = "Director, Administrator")]
    [HttpPut]
    public async Task<IActionResult> UpdateDirector([FromBody] UpdateDirectorDto directorDto)
    {
        await ValidateAsync(_updateDirectorValidator, directorDto);

        var director = _mapper.Map<Domain.Entities.Director>(directorDto);

        await _directorService.UpdateDirectorAsync(director);

        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("{directorId}")]
    public async Task<IActionResult> DeleteDirector(Guid directorId)
    {
        await _directorService.DeleteDirectorAsync(directorId);

        return Ok();
    }
}
