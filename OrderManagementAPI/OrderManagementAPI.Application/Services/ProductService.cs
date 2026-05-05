using OrderManagementAPI.Application.DTOs;
using OrderManagementAPI.Application.Interfaces.Repositories;
using OrderManagementAPI.Application.Interfaces.Services;

namespace OrderManagementAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private protected IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public Task<ProductResponseDto> CreateProductAsync(ProductResponseDto product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseDto> GetProductAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductResponseDto>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseDto> UpdateProductAsync(ProductResponseDto product)
        {
            throw new NotImplementedException();
        }
    }
}
