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

        public async Task<CategoryDTO> Create(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Model.Category>(categoryDto);
            var createdCategory = await _categoryRepository.CreateCategoryAsync(categoryEntity);
            return _mapper.Map<CategoryDTO>(createdCategory);

        }

        public async Task<CategoryDTO> Delete(int id)
        {
            var deletedCategory = await _categoryRepository.DeleteCategoryAsync(id);
            return _mapper.Map<CategoryDTO>(deletedCategory);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
           var category = await _categoryRepository.GetCategoryById(id);
              return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDto)
        { 
            var categoryEntity = _mapper.Map<Model.Category>(categoryDto);
            var updatedCategory = await _categoryRepository.UpdateCategoryAsync(categoryEntity);
            return _mapper.Map<CategoryDTO>(updatedCategory);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoryProduct()
        {
            var categoriesWithProducts = await _categoryRepository.GetCategoryProductsAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesWithProducts);
        }
    }
}
