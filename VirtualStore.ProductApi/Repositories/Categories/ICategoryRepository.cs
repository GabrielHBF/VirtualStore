using VirtualStore.ProductApi.Model;

namespace VirtualStore.ProductApi.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoryProductsAsync();
        Task<Category> GetCategoryById(int id);

        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<Category> DeleteCategoryAsync(int id);

    }
}
