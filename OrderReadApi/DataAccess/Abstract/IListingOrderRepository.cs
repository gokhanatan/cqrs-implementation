using System.Threading.Tasks;
using OrderReadApi.Models.Projections;

namespace OrderReadApi.DataAccess.Abstract
{
    public interface IListingOrderRepository
    {
        Task Insert(ListingOrder listingOrderDocument);
        Task<ListingOrder> GetByCode(string code);
    }
}