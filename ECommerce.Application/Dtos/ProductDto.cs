namespace ECommerce.Application.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; } // Used for display if needed
}
