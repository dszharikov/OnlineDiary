using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class TermService : ITermService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPaginationService _paginationService;

    public TermService(
        IUnitOfWork unitOfWork,
        IMapper mapper, 
        IPaginationService paginationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _paginationService = paginationService;
    }

    public async Task<Term> GetTermByIdAsync(Guid termId)
    {
        var term = await _unitOfWork.Terms.GetByIdAsync(termId);
        if (term == null)
        {
            throw new NotFoundException($"Термин с ID {termId} не найден.");
        }

        return term;
    }

    public async Task<PaginationResponseDto<Term>> GetTermsAsync(PaginationRequestDto paginationRequest)
    {
        var terms = _unitOfWork.Terms.GetAllAsync();

        return await _paginationService.PaginateAsync(terms, paginationRequest);
    }

    public async Task CreateTermAsync(Term term)
    {
        await EnsureTermDoesNotExistAsync(term.Name);

        await _unitOfWork.Terms.AddAsync(term);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateTermAsync(Guid termId, Term updatedTerm)
    {
        var term = await _unitOfWork.Terms.GetByIdAsync(termId);
        if (term == null)
        {
            throw new NotFoundException($"Термин с ID {termId} не найден.");
        }

        if (term.Name != updatedTerm.Name)
        {
            await EnsureTermDoesNotExistAsync(updatedTerm.Name);
        }

        _mapper.Map(updatedTerm, term); // Обновляем сущность через маппинг
        _unitOfWork.Terms.Update(term);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTermAsync(Guid termId)
    {
        var term = await _unitOfWork.Terms.GetByIdAsync(termId);
        if (term == null)
        {
            throw new NotFoundException($"Термин с ID {termId} не найден.");
        }

        _unitOfWork.Terms.Remove(term);

        await _unitOfWork.SaveChangesAsync();
    }

    private async Task EnsureTermDoesNotExistAsync(string termName)
    {
        var terms = await _unitOfWork.Terms.FindAsync(t => t.Name == termName);
        if (terms.Any())
        {
            throw new DuplicateException("Термин с таким названием уже существует.");
        }
    }
}
