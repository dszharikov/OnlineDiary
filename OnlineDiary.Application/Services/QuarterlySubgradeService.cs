using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class QuarterlySubgradeService : IQuarterlySubgradeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuarterlySubgradeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<QuarterlySubgrade> GetQuarterlySubgradeByIdAsync(Guid quarterlySubgradeId)
    {
        var quarterlySubgrade = await _unitOfWork.QuarterlySubgrades.GetByIdAsync(quarterlySubgradeId);

        if (quarterlySubgrade == null)
        {
            throw new NotFoundException($"Оценка c ID {quarterlySubgradeId} не найдена.");
        }

        return quarterlySubgrade;
    }
    
    public async Task<IEnumerable<QuarterlySubgrade>> GetQuarterlySubgradesByTermClassSubjectSubcategoryAsync
        (Guid termId, Guid classSubjectId, Guid subcategoryId)
    {
        var quarterlySubgrades = await _unitOfWork.QuarterlySubgrades
            .GetByTermStudentClassSubjectAsync(termId, classSubjectId, subcategoryId);
        
        return quarterlySubgrades;
    }

    public async Task<IEnumerable<QuarterlySubgrade>> GetQuarterlySubgradesByTermStudentClassSubjectAsync
        (Guid termId, Guid studentId, Guid classSubjectId)
    {
        var quarterlySubgrades = await _unitOfWork.QuarterlySubgrades
            .GetByTermStudentClassSubjectIdAsync(termId, studentId, classSubjectId);

        return quarterlySubgrades;
    }

    public async Task<IEnumerable<QuarterlySubgrade>> GetQuarterlySubgradesByTermClassSubjectIdAsync
        (Guid termId, Guid classSubjectId)
    {
        var quarterlySubgrades = await _unitOfWork.QuarterlySubgrades
            .GetByTermClassSubjectIdAsync(termId, classSubjectId);
        
        return quarterlySubgrades;
    }

    public async Task CreateQuarterlySubgradeAsync(QuarterlySubgrade quarterlySubgrade)
    {
        var quarterlySubgradeEntity = await _unitOfWork.QuarterlySubgrades
            .GetByTermStudentSubcategoryAsync(quarterlySubgrade.TermId, quarterlySubgrade.StudentId,
                quarterlySubgrade.SubcategoryId);
        
        if (quarterlySubgradeEntity != null)
        {
            throw new DuplicateException("Оценка уже существует");
        }

        await _unitOfWork.QuarterlySubgrades.AddAsync(quarterlySubgrade);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateQuarterlySubgradeAsync(Guid quarterlySubgradeId, QuarterlySubgrade updatedQuarterlySubgrade)
    {
        var quarterlySubgradeEntity = await _unitOfWork.QuarterlySubgrades.GetByIdAsync(quarterlySubgradeId);

        if (quarterlySubgradeEntity == null)
        {
            throw new NotFoundException($"Оценка с ID {quarterlySubgradeId} не найдена.");
        }

        _mapper.Map(updatedQuarterlySubgrade, quarterlySubgradeEntity);

        _unitOfWork.QuarterlySubgrades.Update(quarterlySubgradeEntity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteQuarterlySubgradeAsync(Guid quarterlySubgradeId)
    {
        var quarterlySubgrade = await _unitOfWork.QuarterlySubgrades.GetByIdAsync(quarterlySubgradeId);

        if (quarterlySubgrade == null)
        {
            throw new NotFoundException($"Оценка с ID {quarterlySubgradeId} не найдена.");
        }

        _unitOfWork.QuarterlySubgrades.Remove(quarterlySubgrade);
        await _unitOfWork.SaveChangesAsync();
    }

    
}