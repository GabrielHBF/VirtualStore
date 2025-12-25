using System.Text.Json;
using VirtualStore.Web.Models;
using VirtualStore.Web.Services.Interfaces;

namespace VirtualStore.Web.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string endpoint = "api/categorie";
        private readonly JsonSerializerOptions _options;
        private IEnumerable<CategoryViewModel> categoriesVm;
        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using (var response = await client.GetAsync(endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                     return categoriesVm = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
