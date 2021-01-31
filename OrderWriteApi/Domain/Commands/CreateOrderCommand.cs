using System;

namespace OrderWriteApi.Domain.Commands
{
    public class CreateOrderCommand
    {
        public Guid Id {get;set;}
        public string Code { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}