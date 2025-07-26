using MediatR;
using ECommerce.Application.DTOs;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<bool>
{
    public UpdateCategoryDto CategoryDto { get; set; }

    public UpdateCategoryCommand(UpdateCategoryDto categoryDto)
    {
        CategoryDto = categoryDto;
    }
}
