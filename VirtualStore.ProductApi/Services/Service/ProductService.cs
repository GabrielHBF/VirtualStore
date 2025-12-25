using AutoMapper;
using VirtualStore.ProductApi.DTOs;
using VirtualStore.ProductApi.Entities;
using VirtualStore.ProductApi.Repositories.Products;
using VirtualStore.ProductApi.Services.Interfaces;

namespace VirtualStore.ProductApi.Services.Service
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductDTO> CreateAsync(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);

            productEntity.CategoryId = productDto.CategoryId;

            var createdProduct = await _productRepository.CreateProductAsync(productEntity);

            return _mapper.Map<ProductDTO>(createdProduct);

        }

        public async Task<ProductDTO> DeleteAsync(int id)
        {
            var deletedProduct =await  _productRepository.DeleteProductAsync(id);
            return _mapper.Map<ProductDTO>(deletedProduct);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);

        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product =  await _productRepository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            var updatedProduct = await _productRepository.UpdateProductAsync(productEntity);
            return _mapper.Map<ProductDTO>(updatedProduct);
        }
    }
}
