using System.Net.Http.Json;
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

        public async Task<ProductsViewModel> CreateAsync(ProductsViewModel productsViewModel)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            StringContent content = new StringContent(JsonSerializer.Serialize(productsViewModel)
                                        , System.Text.Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync(endpoint, content))
            {
                if(response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productVm = await JsonSerializer.DeserializeAsync<ProductsViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productVm;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using (var response = await client.DeleteAsync($"{endpoint}/{id}"))
            {
                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<IEnumerable<ProductsViewModel>> GetAllAsync()
        {

            var client = _httpClientFactory.CreateClient("ProductApi");

            using (var response = await client.GetAsync(endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productsVm = await JsonSerializer.DeserializeAsync<IEnumerable<ProductsViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }

            }
            return productsVm;
        }

        public async Task<ProductsViewModel> GetByIdAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using(var response = await client.GetAsync($"{endpoint}/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productVm = await JsonSerializer.DeserializeAsync<ProductsViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productVm;
        }

        public async Task<ProductsViewModel> UpdateAsync(ProductsViewModel productsViewModel)
        {
           var client = _httpClientFactory.CreateClient("ProductApi");
           ProductsViewModel productUpdate = new ProductsViewModel();

            using (var response =  await client.PutAsJsonAsync($"{endpoint}", productsViewModel))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productUpdate = await JsonSerializer.DeserializeAsync<ProductsViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productUpdate;
        }
    }
}
