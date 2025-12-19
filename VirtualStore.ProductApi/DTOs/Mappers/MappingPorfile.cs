using AutoMapper;
using VirtualStore.ProductApi.Entities;

namespace VirtualStore.ProductApi.DTOs.Mappers;

public class MappingPorfile : Profile
{
    public MappingPorfile()
    {
        CreateMap<Product, ProductDTO>();

        CreateMap<Product, ProductDTO>().ForMember(X => X.CategoryName, opt => opt.MapFrom(x => x.Category!.Name));

        CreateMap<Model.Category, CategoryDTO>().ReverseMap();
    }
}
