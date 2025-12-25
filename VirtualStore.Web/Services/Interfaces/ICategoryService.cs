using VirtualStore.Web.Models;

namespace VirtualStore.Web.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();
    }
}
