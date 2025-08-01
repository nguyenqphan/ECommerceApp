﻿using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IReadOnlyList<Product>> GetProductsWithCategoryAsync();
    Task<Product?> GetByIdWithCategoryAsync(Guid id);
}
