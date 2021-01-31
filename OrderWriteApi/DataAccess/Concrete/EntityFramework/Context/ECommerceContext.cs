using System.Threading.Tasks;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderWriteApi.DataAccess.Concrete.EntityFramework.Mappings;
using OrderWriteApi.DataAccess.Entities;
using OrderWriteApi.Domain.Core;

namespace OrderWriteApi.DataAccess.Concrete.EntityFramework.Context
{
    public class ECommerceContext : DbContext
    {
        private readonly IBusControl _busControl;
        public DbSet<Order> Orders { get; set; }
        public ECommerceContext(DbContextOptions<ECommerceContext> options, IBusControl busControl)
            : base(options)
        {
            _busControl = busControl;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMapping());

            base.OnModelCreating(modelBuilder);
        }


        public async Task AddAndSaveAsync(AggregateRoot aggregate)
        {
            Add(aggregate);
            await base.SaveChangesAsync();

            await PublishEvents(aggregate);
        }

        public async Task UpdateAndSaveAsync(AggregateRoot aggregate)
        {
            Update(aggregate);
            await base.SaveChangesAsync();

            await PublishEvents(aggregate);
        }

        public async Task PublishEvents(AggregateRoot aggregate)
        {
            var events = aggregate.GetUncommittedChanges();
            foreach (var @event in events)
            {
                await _busControl.Publish(@event);
            }

            aggregate.MarkChangesAsCommitted();
        }
    }
}