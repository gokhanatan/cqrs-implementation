namespace OrderWriteApi.Models
{
    public class CreateOrderRequest
    {
        public string Code { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}