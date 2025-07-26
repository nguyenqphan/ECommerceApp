using AutoMapper;
using MediatR;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.DTOs;

namespace ECommerce.Application.Features.Categories.Queries.GetCategoryList;

public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.ListAllAsync();
        return _mapper.Map<List<CategoryDto>>(categories);
    }
}
