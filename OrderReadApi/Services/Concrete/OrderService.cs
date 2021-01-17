using System.Threading.Tasks;
using OrderReadApi.DataAccess.Abstract;
using OrderReadApi.Models.Projections;
using OrderReadApi.Services.Abstract;

namespace OrderReadApi.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IListingOrderRepository _orderRepository;

        public OrderService(IListingOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<ListingOrder> GetByCode(string code)
        {
            return await _orderRepository.GetByCode(code);
        }

        public async Task Insert(ListingOrder listingOrderDocument)
        {
            await _orderRepository.Insert(listingOrderDocument);
        }
    }
}