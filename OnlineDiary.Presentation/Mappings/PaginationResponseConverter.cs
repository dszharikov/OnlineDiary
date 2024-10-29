using AutoMapper;
using OnlineDiary.Application.Pagination;

namespace OnlineDiary.Presentation.Mappings;

public class PaginationResponseConverter<TSource, TDestination> : ITypeConverter<PaginationResponseDto<TSource>, PaginationResponseDto<TDestination>>
{
    private readonly IMapper _mapper;

    public PaginationResponseConverter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public PaginationResponseDto<TDestination> Convert(PaginationResponseDto<TSource> source, PaginationResponseDto<TDestination> destination, ResolutionContext context)
    {
        return new PaginationResponseDto<TDestination>
        {
            PageNumber = source.PageNumber,
            PageSize = source.PageSize,
            TotalItems = source.TotalItems,
            TotalPages = source.TotalPages,
            Items = _mapper.Map<IEnumerable<TDestination>>(source.Items).ToList()
        };
    }
}