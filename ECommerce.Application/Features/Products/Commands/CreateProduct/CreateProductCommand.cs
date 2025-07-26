using MediatR;
using ECommerce.Application.DTOs;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct;

/// <summary>
/// Command to create a new product in the system.
/// Encapsulates the data required to create a product, including its name, price, quantity, image URL, and category.
/// Implements <see cref="IRequest{TResponse}"/> to support MediatR request/response pattern, returning the unique identifier (Guid) of the created product.
/// </summary>
    public class CreateProductCommand : IRequest<Guid>
    {
        /// <summary>
        /// Gets or sets the data transfer object containing product creation details.
        /// </summary>
        public CreateProductDto ProductDto { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductCommand"/> class with the specified product details.
        /// </summary>
        /// <param name="productDto">The DTO containing the product information to be created.</param>
        public CreateProductCommand(CreateProductDto productDto)
        {
            ProductDto = productDto;
        }
    }
