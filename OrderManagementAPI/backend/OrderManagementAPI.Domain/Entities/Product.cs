using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public decimal Price { get; private set; } 
        public int Quantify { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Product(string description, string category, decimal price, int quantify) {
            Description = description; 
            Category = category;
            Price = price;
            Quantify = quantify;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

    }
}
