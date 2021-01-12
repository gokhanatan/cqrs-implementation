using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderWriteApi.DataAccess.Abstract;
using OrderWriteApi.DataAccess.Concrete.EntityFramework.Context;
using OrderWriteApi.DataAccess.Entities;

namespace OrderWriteApi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceContext _context;

        public OrderRepository(ECommerceContext context)
        {
            _context = context;

        }
        public async Task Create(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetByCode(string code)
        {
            return await _context.Orders.SingleOrDefaultAsync(o => o.Code == code);
        }
    }
}