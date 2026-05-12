using FluentValidation;
using Mapster;
using OrderManagementAPI.Application.DTOs.Request.Product;
using OrderManagementAPI.Application.DTOs.Response.Product;
using OrderManagementAPI.Application.Interfaces.Repositories;
using OrderManagementAPI.Application.Interfaces.Services;
using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private protected IProductRepository _repository;
        private protected IValidator<CreateProductRequestDto> _createValidate;
        private protected IValidator<UpdateProductRequestDto> _updateValidate;
        public ProductService(
            IProductRepository repository, 
            IValidator<CreateProductRequestDto> createValidate,
            IValidator<UpdateProductRequestDto> updateValidate)
        {
            _repository = repository;
            _createValidate = createValidate;
            _updateValidate = updateValidate;
        }

        public async Task<List<ProductResponseDto>> GetProductsAsync()
        {
            var products = await _repository.GetProductsAsync();

            if (products == null || !products.Any())
                return new List<ProductResponseDto>();

            return products.Adapt<List<ProductResponseDto>>();
        }

        public async Task<ProductResponseDto?> GetProductAsync(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            if (product == null) return null;

            return product.Adapt<ProductResponseDto>();
        }

        public async Task<ProductResponseDto> CreateProductAsync(CreateProductRequestDto request)
        { 
            var validationResult = await _createValidate.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var product = new Product(
                request.Description,
                request.Category,
                request.Price,
                request.Quantify
                );

            var created = await _repository.CreateProductAsync(product);

            return created.Adapt<ProductResponseDto>();
        }

        public async Task<ProductResponseDto?> UpdateProductAsync(UpdateProductRequestDto request)
        {
            var validationResult = await _updateValidate.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var product = request.Adapt<Product>();

            var updated = await _repository.UpdateProductAsync(product);

            return updated.Adapt<ProductResponseDto>();
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            return await _repository.RemoveProductAsync(id);
        }

    }
}
