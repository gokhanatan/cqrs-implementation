using Microsoft.EntityFrameworkCore;
using OrderWriteApi.DataAccess.Concrete.EntityFramework.Mappings;
using OrderWriteApi.DataAccess.Entities;

namespace OrderWriteApi.DataAccess.Concrete.EntityFramework.Context
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Order> Orders { get; set; }
    }
}