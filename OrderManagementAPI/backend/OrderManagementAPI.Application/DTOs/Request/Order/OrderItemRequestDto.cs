using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementAPI.Application.DTOs.Request.Order
{
    public class OrderItemRequestDto
    {
        public int ProductId { get; set; }
        public int Quantify { get; set; }
    }
}
