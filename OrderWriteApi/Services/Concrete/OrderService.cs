using System.Threading.Tasks;
using MassTransit;
using OrderWriteApi.Domain.Commands;
using OrderWriteApi.Models;
using OrderWriteApi.Services.Abstract;
using OrderWriteApi.Extensions;

namespace OrderWriteApi.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IBusControl _busControl;
        public OrderService(IBusControl busControl)
        {
            _busControl = busControl;
        }
        public async Task CreateOrder(CreateOrderRequest createOrderRequest)
        {
            var createOrderCommand = new CreateOrderCommand()
            {
                Id = createOrderRequest.Id,
                Code = createOrderRequest.Code,
                UserId = createOrderRequest.UserId,
                TotalPrice = createOrderRequest.TotalPrice
            };

            await _busControl.Send(createOrderCommand, "create-order-command-queue");
        }
    }
}