using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasMany(order => order.Items)
                .WithOne(item => item.Order)
                .HasForeignKey(item => item.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);


            modelBuilder.Entity<OrderItem>()
                .Property(x => x.PriceActual)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
