using System.Threading.Tasks;
using OrderWriteApi.Models;

namespace OrderWriteApi.Services.Abstract
{
    public interface IOrderService
    {
         Task CreateOrder(CreateOrderRequest createOrderRequest);
    }
}