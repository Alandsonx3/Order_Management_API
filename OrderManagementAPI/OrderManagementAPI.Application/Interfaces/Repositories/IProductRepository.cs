using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductAsync(int Id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<bool> RemoveProductAsync(int Id);
    }
}
