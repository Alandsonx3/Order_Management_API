using OrderManagementAPI.Application.DTOs;

namespace OrderManagementAPI.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProductsAsync();
        Task<ProductDTO?> GetProductAsync(int Id);
        Task<ProductDTO?> CreateProductAsync(ProductDTO product);
        Task<ProductDTO?> UpdateProductAsync(ProductDTO product);
        Task<bool> RemoveProductAsync(int Id);
    }
}
