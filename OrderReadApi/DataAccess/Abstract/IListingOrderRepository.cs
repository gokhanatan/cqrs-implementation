using System.Threading.Tasks;
using OrderReadApi.Models;

namespace OrderReadApi.DataAccess.Abstract
{
    public interface IListingOrderRepository
    {
        Task Insert(ListingOrder listingOrderDocument);
        Task UpdateStatus(string code, string status);
        Task<ListingOrder> GetByCode(string code);
    }
}