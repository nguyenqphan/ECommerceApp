using MediatR;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null) return false;

        var hasProducts = (await _productRepository.GetProductsWithCategoryAsync())
            .Any(p => p.CategoryId == request.Id);

        if (hasProducts)
            return false;

        await _categoryRepository.DeleteAsync(category);
        return true;
    }
}
