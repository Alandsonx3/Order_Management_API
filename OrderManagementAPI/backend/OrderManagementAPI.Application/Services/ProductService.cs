using Mapster;
using FluentValidation.Results;
using OrderManagementAPI.Application.DTOs;
using OrderManagementAPI.Application.Interfaces.Repositories;
using OrderManagementAPI.Application.Interfaces.Services;
using OrderManagementAPI.Domain.Entities;
using FluentValidation;

namespace OrderManagementAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private protected IProductRepository _repository;
        private protected IValidator<ProductDTO> _validate;
        public ProductService(IProductRepository repository, IValidator<ProductDTO> validate)
        {
            _repository = repository;
            _validate = validate;
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            var products = await _repository.GetProductsAsync();

            if (products == null || !products.Any())
                return new List<ProductDTO>();

            return products.Adapt<List<ProductDTO>>();
        }

        public async Task<ProductDTO?> GetProductAsync(int id)
        {
            var product = await _repository.GetProductAsync(id);

            if (product == null) return null;

            return product.Adapt<ProductDTO>();
        }

        public async Task<ProductDTO?> CreateProductAsync(ProductDTO productDTO)
        { 
            var result = await _validate.ValidateAsync(productDTO);

            if (!result.IsValid)
                throw new ValidationException(result.Errors); 

            var product = productDTO.Adapt<Product>();

            product.IsActive = true;
            product.CreatedAt = DateTime.UtcNow;

            var created = await _repository.CreateProductAsync(product);

            return created.Adapt<ProductDTO>();
        }

        public async Task<ProductDTO?> UpdateProductAsync(ProductDTO productDTO)
        {
            var result = await _validate.ValidateAsync(productDTO);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var product = productDTO.Adapt<Product>();

            var updated = await _repository.UpdateProductAsync(product);

            return updated.Adapt<ProductDTO>();
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            return await _repository.RemoveProductAsync(id);
        }

    }
}
