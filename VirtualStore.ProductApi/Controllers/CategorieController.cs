using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.ProductApi.DTOs;
using VirtualStore.ProductApi.Repositories.Categories;
using VirtualStore.ProductApi.Services.Interfaces;

namespace VirtualStore.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var result = await _categoryService.GetAll();
            if (result is null)
            {
                return NotFound("Categories not fond");
            }
            return Ok(result);
        }

        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryProduct()
        {
            var result = await _categoryService.GetCategoryProduct();
            if (result is null)
            {
                return NotFound("Categories not fond");
            }
            return Ok(result);
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var result = await _categoryService.GetById(id);
            if (result is null)
            {
                return NotFound("Category not fond");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto is null)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryService.Create(categoryDto);
            return new CreatedAtRouteResult("GetCategory", new { id = result.CategoryId }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory([FromBody] CategoryDTO categoryDto, int id)
        {
            if(categoryDto is null || categoryDto.CategoryId != id)
            {
                return BadRequest();
            }
            var result = await _categoryService.Update(categoryDto);
           
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
        {
            var result = await _categoryService.Delete(id);
            if (result is null)
            {
                return NotFound("Category not fond");
            }
            return Ok(result);
        }
    }
}
