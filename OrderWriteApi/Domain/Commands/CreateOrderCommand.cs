namespace OrderWriteApi.Domain.Commands
{
    public class CreateOrderCommand
    {
        public string Code { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}