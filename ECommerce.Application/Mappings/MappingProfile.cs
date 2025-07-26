using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Product mappings
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name));

        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();

        // Category mappings
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
}
