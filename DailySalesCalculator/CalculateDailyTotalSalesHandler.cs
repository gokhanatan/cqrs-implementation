using System.Threading.Tasks;
using MassTransit;
using OrderWriteApi.Domain.Events;

namespace DailySalesCalculator
{
    public class CalculateDailyTotalSalesHandler : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {

            ElkRepository elkRepository = new ElkRepository();

            await elkRepository.InsertOrUpdate(context.Message.OrderDate, context.Message.TotalPrice);
        }
    }
}
