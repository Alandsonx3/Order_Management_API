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

        public async Task<Product> GetProductAsync(int Id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (product is null) throw new ArgumentNullException();

            return product;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var existing = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == product.Id);

            if (existing != null)
                throw new InvalidOperationException("Já existe um produto cadastrado");

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var existing = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == product.Id);

            if (existing == null)
                throw new Exception("Product not found");

            _context.Entry(existing).CurrentValues.SetValues(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task RemoveProductAsync(int Id)
        {
            var existing = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == Id);

            if(existing == null)
                throw new Exception("Product not found");

            _context.Products.Remove(existing);
        }
    }
}
