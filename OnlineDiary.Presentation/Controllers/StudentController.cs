using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Filters.Students;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Presentation.DTOs.StudentDtos;

namespace OnlineDiary.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IStudentService _studentService;
    private readonly IValidator<CreateStudentDto> _createStudentValidator;
    private readonly IValidator<UpdateStudentDto> _updateStudentValidator;

    public StudentController(
        IMapper mapper, IStudentService studentService, 
        IValidator<CreateStudentDto> createStudentValidator, 
        IValidator<UpdateStudentDto> updateStudentValidator)
    {
        _mapper = mapper;
        _studentService = studentService;
        _createStudentValidator = createStudentValidator;
        _updateStudentValidator = updateStudentValidator;
    }

    [HttpGet]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> GetStudents(
        [FromQuery] PaginationAndFilterRequestDto<StudentFilterRequestDto> paginationAndFilterRequest)
    {
        var students = await _studentService.GetStudentsAsync(paginationAndFilterRequest);

        var mappedResult = _mapper.Map<PaginationResponseDto<StudentDto>>(students);

        return Ok(mappedResult);
    }

    [HttpGet("{studentId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> GetStudentById(Guid studentId)
    {
        var student = await _studentService.GetStudentByIdAsync(studentId);

        return Ok(_mapper.Map<StudentDto>(student));
    }

    [HttpPost]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto studentDto)
    {
        await ValidateAsync(_createStudentValidator, studentDto);

        var student = _mapper.Map<Domain.Entities.Student>(studentDto);

        // TODO: create username and password
        // TODO: create infrastructureUser
        // TODO: set id from infrastructureUser

        await _studentService.CreateStudentAsync(student);

        return CreatedAtAction(nameof(GetStudentById), new { studentId = student.UserId }, student);
    }

    [HttpPut("{studentId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> UpdateStudent(Guid studentId, [FromBody] UpdateStudentDto studentDto)
    {
        await ValidateAsync(_updateStudentValidator, studentDto);

        var student = _mapper.Map<Domain.Entities.Student>(studentDto);

        await _studentService.UpdateStudentAsync(studentId, student);

        return Ok();
    }

    [HttpDelete("{studentId}")]
    [Authorize(Roles = "Director")]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        await _studentService.DeleteStudentAsync(studentId);

        return NoContent();
    }


}