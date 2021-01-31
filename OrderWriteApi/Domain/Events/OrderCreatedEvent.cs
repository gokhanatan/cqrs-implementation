using System;

namespace OrderWriteApi.Domain.Events
{
    public class OrderCreatedEvent
    {
        public OrderCreatedEvent(Guid id,
            string orderCode,
            DateTime orderDate,
            int userId,
            decimal totalPrice,
            string status)
        {
            Id = id;
            OrderCode = orderCode;
            OrderDate = orderDate;
            UserId = userId;
            TotalPrice = totalPrice;
            Status = status;
        }
        public Guid Id { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } 
    }
}