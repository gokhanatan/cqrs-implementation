using System.Threading.Tasks;
using OrderReadApi.Models.Projections;

namespace OrderReadApi.Services.Abstract
{
    public interface IOrderService
    {
         Task Insert(ListingOrder listingOrderDocument);
         Task<ListingOrder> GetByCode(string code);
    }
}