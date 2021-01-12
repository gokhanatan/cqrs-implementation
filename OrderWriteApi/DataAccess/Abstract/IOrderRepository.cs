using System.Threading.Tasks;
using OrderWriteApi.DataAccess.Entities;

namespace OrderWriteApi.DataAccess.Abstract
{
    public interface IOrderRepository
    {
        Task Create(Order order);
        Task<Order> GetByCode(string code);
    }
}