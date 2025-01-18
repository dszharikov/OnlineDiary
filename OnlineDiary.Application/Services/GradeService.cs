using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class GradeService : IGradeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GradeService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Grade> GetGradeByIdAsync(Guid gradeId)
    {
        var grade = await _unitOfWork.Grades.GetByIdAsync(gradeId);
        if (grade == null)
        {
            throw new NotFoundException($"Оценка с ID {gradeId} не найдена.");
        }

        return grade;
    }

    public async Task<IEnumerable<Grade>> GetGradesForStudentByTermIdAsync(Guid studentId, Guid termId)
    {
        var grades = await _unitOfWork.Grades.GetGradesForStudentByTermAsync(studentId, termId);

        return grades;
    }

    public async Task<IEnumerable<Grade>> GetGradesByClassSubjectAndTermAsync(Guid classSubjectId, Guid termId)
    {
        var grades = await _unitOfWork.Grades.GetGradesByClassSubjectAndTermAsync(classSubjectId, termId);

        return grades;
    }

    public async Task CreateGradeAsync(Grade grade)
    {
        await _unitOfWork.Grades.AddAsync(grade);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateGradeAsync(Grade updatedGrade)
    {
        _unitOfWork.Grades.Update(updatedGrade);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteGradeAsync(Guid gradeId)
    {
        var grade = await _unitOfWork.Grades.GetByIdAsync(gradeId);
        if (grade == null)
        {
            throw new NotFoundException($"Оценка с ID {gradeId} не найдена.");
        }

        _unitOfWork.Grades.Remove(grade);
        await _unitOfWork.SaveChangesAsync();
    }
}
