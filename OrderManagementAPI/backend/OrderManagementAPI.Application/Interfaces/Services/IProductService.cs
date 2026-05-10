using OrderManagementAPI.Application.DTOs.Request;
using OrderManagementAPI.Application.DTOs.Response;

namespace OrderManagementAPI.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetProductsAsync();
        Task<ProductResponseDto?> GetProductAsync(int Id);
        Task<ProductResponseDto> CreateProductAsync(CreateProductRequestDto product);
        Task<ProductResponseDto?> UpdateProductAsync(UpdateProductRequestDto product);
        Task<bool> RemoveProductAsync(int Id);
    }
}
