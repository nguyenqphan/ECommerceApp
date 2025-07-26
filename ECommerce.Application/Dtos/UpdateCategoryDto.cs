namespace ECommerce.Application.DTOs;

public class UpdateCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
