using VirtualStore.ProductApi.DTOs;

namespace VirtualStore.ProductApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> Create(CategoryDTO categoryDto);
        Task<CategoryDTO> Update(CategoryDTO categoryDto);
        Task<CategoryDTO> Delete(int id);
        Task<IEnumerable<CategoryDTO>> GetCategoryProduct();

    }
}
