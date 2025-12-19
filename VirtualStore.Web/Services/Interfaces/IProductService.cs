using VirtualStore.Web.Models;

namespace VirtualStore.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductsViewModel>> GetAllAsync();
        Task<ProductsViewModel> GetByIdAsync(int id);
        Task<ProductsViewModel> CreateAsync(ProductsViewModel productsViewModel);
        Task<ProductsViewModel> UpdateAsync(ProductsViewModel productsViewModel);
        Task<bool> DeleteAsync(int id);
    }
}
