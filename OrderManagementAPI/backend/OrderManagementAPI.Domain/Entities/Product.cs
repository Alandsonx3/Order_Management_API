using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public int Quantify { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
