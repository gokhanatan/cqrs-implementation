using System;

namespace OrderWriteApi.Models
{
    public class CreateOrderRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}