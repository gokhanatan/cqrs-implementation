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
            var order = Order.Create(context.Message.Id, context.Message.Code, context.Message.UserId, context.Message.TotalPrice);

            await _orderRepository.Create(order);
        }
    }
}