using AutoMapper;

namespace VirtualStore.ProductApi.DTOs.Mappers;

public class MappingPorfile : Profile
{
    public MappingPorfile()
    {
        CreateMap<Model.Product, ProductDTO>().ReverseMap();
        CreateMap<Model.Category, CategoryDTO>().ReverseMap();
    }
}
