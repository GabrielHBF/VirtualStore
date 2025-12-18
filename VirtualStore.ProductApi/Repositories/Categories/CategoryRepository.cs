using VirtualStore.ProductApi.Model;
using VirtualStore.ProductApi.Context;
using Microsoft.EntityFrameworkCore;

namespace VirtualStore.ProductApi.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
             _context.Categories.AddAsync(category);
             await _context.SaveChangesAsync();
              return category;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryById(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
           return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Category>> GetCategoryProductsAsync()
        {
           return await _context.Categories
                .Include(c => c.Products)
                .ToListAsync();
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
