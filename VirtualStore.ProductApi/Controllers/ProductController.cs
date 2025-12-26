using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.ProductApi.DTOs;
using VirtualStore.ProductApi.Services.Interfaces;
using VirtualStore.ProductApi.Services.Service;

namespace VirtualStore.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        public readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var result = await _productService.GetAllAsync();
            if (result is null)
            {
                return NotFound("Products not found");
            }
            return Ok(result);
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if(result is null)
            {
                return NotFound("Product not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] ProductDTO productDTO)
        {
            if(productDTO is null)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.CreateAsync(productDTO);
            return new CreatedAtRouteResult("GetProductById", new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromBody] ProductDTO productDTO)
        { 
            var result = await _productService.UpdateAsync(productDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if(result is null)
            {
                return NotFound("Product not found");
            }
            return Ok(result);
        }
    }
}
