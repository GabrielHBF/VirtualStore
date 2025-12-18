using VirtualStore.ProductApi.DTOs;
using VirtualStore.ProductApi.Services.Interfaces;
using AutoMapper;
using VirtualStore.ProductApi.Repositories.Categories;

namespace VirtualStore.ProductApi.Services.Service
{
    public class CategoryServices(IMapper mapper, ICategoryRepository categoryRepository) : ICategoryService
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public Task<CategoryDTO> Create(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Model.Category>(categoryDto);
            var createdCategory = _categoryRepository.CreateCategoryAsync(categoryEntity);
            return _mapper.Map<Task<CategoryDTO>>(createdCategory);

        }

        public Task<CategoryDTO> Delete(int id)
        {
            var deletedCategory = _categoryRepository.DeleteCategoryAsync(id);
            return _mapper.Map<Task<CategoryDTO>>(deletedCategory);
        }

        public Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories =  _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<Task<IEnumerable<CategoryDTO>>>(categories);
        }

        public Task<CategoryDTO> GetById(int id)
        {
           var category =  _categoryRepository.GetCategoryById(id);
              return _mapper.Map<Task<CategoryDTO>>(category);
        }

        public Task<CategoryDTO> Update(CategoryDTO categoryDto)
        { 
            var categoryEntity = _mapper.Map<Model.Category>(categoryDto);
            var updatedCategory = _categoryRepository.UpdateCategoryAsync(categoryEntity);
            return _mapper.Map<Task<CategoryDTO>>(updatedCategory);
        }

        public Task<IEnumerable<CategoryDTO>> GetCategoryProduct()
        {
            var categoriesWithProducts = _categoryRepository.GetCategoryProductsAsync();
            return _mapper.Map<Task<IEnumerable<CategoryDTO>>>(categoriesWithProducts);
        }
    }
}
