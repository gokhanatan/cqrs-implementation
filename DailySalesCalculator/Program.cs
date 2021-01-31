using System;
using GreenPipes;
using MassTransit;

namespace DailySalesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost/cqrs"), hst =>
                  {
                      hst.Username("guest");
                      hst.Password("guest");
                  });

                cfg.ReceiveEndpoint("daily-total-sales-queue", e =>
                {
                    e.PrefetchCount = 1;
                    e.UseMessageRetry(r => r.Interval(3, 500));
                    e.Consumer<CalculateDailyTotalSalesHandler>();
                });
            });

            busControl.Start();

            Console.WriteLine("Projection.DailySalesCalculator is running...");
            Console.ReadLine();
        }
    }
}
