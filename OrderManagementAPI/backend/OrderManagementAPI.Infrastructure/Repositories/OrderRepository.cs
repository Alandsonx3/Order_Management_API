using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Application.Interfaces.Repositories;
using OrderManagementAPI.Domain.Entities;
using OrderManagementAPI.Infrastructure.Persistence;

namespace OrderManagementAPI.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(order => order.Items)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(order => order.Items)
                .ThenInclude(item => item.Product)
                .FirstOrDefaultAsync(order => order.Id == id);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
