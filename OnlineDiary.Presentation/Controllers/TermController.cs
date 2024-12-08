using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Presentation.DTOs.TermDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TermController : BaseController
{
    private readonly ITermService _termService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTermDto> _createTermValidator;
    private readonly IValidator<UpdateTermDto> _updateTermValidator;

    public TermController(
        ITermService termService, IMapper mapper,
        IValidator<CreateTermDto> createTermValidator, IValidator<UpdateTermDto> updateTermValidator)
    {
        _termService = termService;
        _mapper = mapper;
        _createTermValidator = createTermValidator;
        _updateTermValidator = updateTermValidator;
    }

    [HttpGet]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> GetTerms([FromQuery] PaginationRequestDto paginationRequest)
    {
        var paginationResult = await _termService.GetTermsAsync(paginationRequest);

        var mappedResult = _mapper.Map<PaginationResponseDto<TermDto>>(paginationResult);

        return Ok(mappedResult);
    }

    [Authorize(Roles = "Director")]
    [HttpGet("{termId}")]
    public async Task<IActionResult> GetTermById(Guid termId)
    {
        var term = await _termService.GetTermByIdAsync(termId);

        return Ok(_mapper.Map<TermDto>(term));
    }

    [Authorize(Roles = "Director")]
    [HttpPost]
    public async Task<IActionResult> CreateTerm([FromBody] CreateTermDto termDto)
    {
        await ValidateAsync(_createTermValidator, termDto);

        var term = _mapper.Map<Domain.Entities.Term>(termDto);

        await _termService.CreateTermAsync(term);

        return CreatedAtAction(nameof(GetTermById),
            new { termId = term.TermId }, term);
    }

    [Authorize(Roles = "Director")]
    [HttpPut("{termId}")]
    public async Task<IActionResult> UpdateTerm(Guid termId, [FromBody] UpdateTermDto termDto)
    {
        await ValidateAsync(_updateTermValidator, termDto);

        var term = _mapper.Map<Domain.Entities.Term>(termDto);

        await _termService.UpdateTermAsync(termId, term);

        return Ok();
    }

    [Authorize(Roles = "Director")]
    [HttpDelete("{termId}")]
    public async Task<IActionResult> DeleteTerm(Guid termId)
    {
        await _termService.DeleteTermAsync(termId);

        return Ok();
    }
}
