using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementAPI.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantify {  get; set; }
        public decimal PriceActual { get; set; }
        public Product Product { get; set; } = new Product();
        public Order Order { get; set; } = new Order();

    }
}
