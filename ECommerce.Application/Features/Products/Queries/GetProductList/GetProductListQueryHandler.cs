using AutoMapper;
using MediatR;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.DTOs;

namespace ECommerce.Application.Features.Products.Queries.GetProductList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsWithCategoryAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }
}
