using System.Threading.Tasks;
using MassTransit;
using OrderWriteApi.Domain.Events;
using OrderReadApi.Models.Projections;
using OrderReadApi.Services.Abstract;

namespace OrderReadApi.Projections.EventHandlers
{
    public class OrderCreatedEventHandler : IConsumer<OrderCreatedEvent>
    {
        private readonly IOrderService _orderService;

        public OrderCreatedEventHandler(IOrderService orderService)
        {
            _orderService = orderService;

        }
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var listingOrderDocument = new ListingOrder()
            {
                OrderId = context.Message.Id.ToString(),
                Code = context.Message.OrderCode,
                OrderDate = context.Message.OrderDate,
                UserId = context.Message.UserId,
                TotalPrice = context.Message.TotalPrice,
                Status = context.Message.Status
            };

            await _orderService.Insert(listingOrderDocument);
        }
    }
}