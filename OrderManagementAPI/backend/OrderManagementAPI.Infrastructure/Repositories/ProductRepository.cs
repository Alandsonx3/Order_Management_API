using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Application.Interfaces.Repositories;
using OrderManagementAPI.Domain.Entities;
using OrderManagementAPI.Infrastructure.Persistence;

namespace OrderManagementAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            var existing = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == product.Id);

            if (existing == null) return null;

            _context.Products.Entry(existing).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            var existing = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null) return false;

            _context.Products.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
