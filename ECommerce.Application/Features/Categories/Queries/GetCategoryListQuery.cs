using MediatR;
using ECommerce.Application.DTOs;

namespace ECommerce.Application.Features.Categories.Queries.GetCategoryList;

public class GetCategoryListQuery : IRequest<List<CategoryDto>> { }
