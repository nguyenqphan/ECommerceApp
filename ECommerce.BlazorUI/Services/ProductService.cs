using System.Net.Http.Json;
using ECommerce.Application.DTOs;

namespace ECommerce.BlazorUI.Services;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient httpClient)
    {
        _http = httpClient;
    }

    public async Task<List<ProductDto>> GetAllAsync() =>
        await _http.GetFromJsonAsync<List<ProductDto>>("products");

    public async Task<ProductDto?> GetByIdAsync(Guid id) =>
        await _http.GetFromJsonAsync<ProductDto>($"products/{id}");

    public async Task<Guid> CreateAsync(CreateProductDto dto)
    {
        var response = await _http.PostAsJsonAsync("products", dto);
        return await response.Content.ReadFromJsonAsync<Guid>();
    }

    public async Task UpdateAsync(Guid id, UpdateProductDto dto) =>
        await _http.PutAsJsonAsync($"products/{id}", dto);

    public async Task DeleteAsync(Guid id) =>
        await _http.DeleteAsync($"products/{id}");
}
