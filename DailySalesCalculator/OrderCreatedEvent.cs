using System;

namespace OrderWriteApi.Domain.Events
{
    public class OrderCreatedEvent
    {
        public Guid Id { get; private set; }
        public string OrderCode { get; private set; }
        public DateTime OrderDate { get; private set; }
        public int UserId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string Status { get; private set; }
    }
}