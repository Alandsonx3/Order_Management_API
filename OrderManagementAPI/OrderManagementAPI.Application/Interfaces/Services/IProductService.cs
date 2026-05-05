using OrderManagementAPI.Application.DTOs;

namespace OrderManagementAPI.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetProductsAsync();
        Task<ProductResponseDto> GetProductAsync(int Id);
        Task<ProductResponseDto> CreateProductAsync(ProductResponseDto product);
        Task<ProductResponseDto> UpdateProductAsync(ProductResponseDto product);
        Task RemoveProductAsync(int Id);
    }
}
