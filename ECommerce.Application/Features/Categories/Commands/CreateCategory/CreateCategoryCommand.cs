using MediatR;
using ECommerce.Application.DTOs;

namespace ECommerce.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public CreateCategoryDto CategoryDto { get; set; }

    public CreateCategoryCommand(CreateCategoryDto categoryDto)
    {
        CategoryDto = categoryDto;
    }
}
