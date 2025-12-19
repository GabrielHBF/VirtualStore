using Microsoft.EntityFrameworkCore;
using VirtualStore.ProductApi.Context;
using VirtualStore.ProductApi.Entities;

namespace VirtualStore.ProductApi.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {

        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var prduct = await GetProductByIdAsync(id);
            _context.Products.Remove(prduct);
            await _context.SaveChangesAsync();
            return prduct;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Include(c => c.Category).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await _context.Products.Include(c => c.Category).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
