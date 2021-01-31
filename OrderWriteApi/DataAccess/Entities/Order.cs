using System;

namespace OrderWriteApi.DataAccess.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

    }
}