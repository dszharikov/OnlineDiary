using OnlineDiary.Application.Filters.Students;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IStudentService
{
    Task<Student> GetStudentByIdAsync(Guid studentId);
    Task<PaginationResponseDto<Student>> GetStudentsAsync(
        PaginationAndFilterRequestDto<StudentFilterRequestDto> paginationAndFilterRequest);
    Task<IEnumerable<Student>> GetStudentsByClassIdAsync(Guid classId);
    Task CreateStudentAsync(Student dto);
    Task UpdateStudentAsync(Guid studentId, Student dto);
    Task DeleteStudentAsync(Guid studentId);
}
