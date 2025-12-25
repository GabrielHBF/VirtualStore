using AutoMapper;
using VirtualStore.ProductApi.Entities;

namespace VirtualStore.ProductApi.DTOs.Mappers;

public class MappingPorfile : Profile
{
    public MappingPorfile()
    {
        CreateMap<Product, ProductDTO>()
        .ForMember(dest => dest.CategoryName,
        opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<ProductDTO, Product>()
        .ForMember(dest => dest.Category, opt => opt.Ignore());

        CreateMap<Model.Category, CategoryDTO>().ReverseMap();
    }
}
