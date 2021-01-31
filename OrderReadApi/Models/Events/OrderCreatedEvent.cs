using System;

namespace OrderWriteApi.Domain.Events
{
    public class OrderCreatedEvent
    {
        public Guid Id { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}