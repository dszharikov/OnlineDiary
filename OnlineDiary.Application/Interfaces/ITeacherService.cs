using OnlineDiary.Application.Filters.Teachers;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ITeacherService
{
    Task<Teacher> GetTeacherByIdAsync(Guid teacherId);
    Task<PaginationResponseDto<Teacher>> GetTeachersAsync(
        PaginationAndFilterRequestDto<TeacherFilterRequestDto> paginationAndFilterRequestDto);
    Task CreateTeacherAsync(Teacher dto);
    Task UpdateTeacherAsync(Guid teacherId, Teacher dto);
    Task DeleteTeacherAsync(Guid teacherId);
}
