using MediatR;
using ECommerce.Application.DTOs;

namespace ECommerce.Application.Features.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<List<ProductDto>> { }
