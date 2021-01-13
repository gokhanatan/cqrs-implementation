using System;
using System.Threading.Tasks;
using MassTransit;
using OrderWriteApi.DataAccess.Abstract;
using OrderWriteApi.DataAccess.Entities;
using OrderWriteApi.Domain.Commands;
using OrderWriteApi.Domain.Events;

namespace OrderWriteApi.Consumers.CommandHandlers
{
    public class CreateOrderCommandHandler : IConsumer<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task Consume(ConsumeContext<CreateOrderCommand> context)
        {
            var order = new Order()
            {
                Code = context.Message.Code,
                CreateDate = DateTime.Now,
                UserId = context.Message.UserId,
                TotalPrice = context.Message.TotalPrice,
                Status = "Created"
            };

            await _orderRepository.Create(order);

            //publish event
            var orderCreatedEvent = new OrderCreatedEvent()
            {
                Id = order.Id,
                OrderCode = order.Code,
                OrderDate = order.CreateDate,
                UserId = order.UserId,
                TotalPrice = order.TotalPrice,
                Status = order.Status
            };

            await context.Publish(orderCreatedEvent);
        }
    }
}