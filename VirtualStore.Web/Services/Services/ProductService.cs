using System.Text.Json;
using VirtualStore.Web.Models;
using VirtualStore.Web.Services.Interfaces;

namespace VirtualStore.Web.Services.Services
{
    public class ProductService : IProductService
    {
        
        private readonly IHttpClientFactory _httpClientFactory;
        private const string endpoint = "api/product";
        private readonly JsonSerializerOptions _options;
        private ProductsViewModel productVm;
        private IEnumerable<ProductsViewModel> productsVm;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<ProductsViewModel> CreateAsync(ProductsViewModel productsViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductsViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductsViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductsViewModel> UpdateAsync(ProductsViewModel productsViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
