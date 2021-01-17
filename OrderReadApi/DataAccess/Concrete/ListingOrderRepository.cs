using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using OrderReadApi.DataAccess.Abstract;
using OrderReadApi.Models.Projections;

namespace OrderReadApi.DataAccess.Concrete
{
    public class ListingOrderRepository : IListingOrderRepository
    {
        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabase;
        private readonly IMongoCollection<ListingOrder> mongoCollection;

        public ListingOrderRepository(IConfiguration configuration)
        {
            mongoClient = new MongoClient(configuration.GetConnectionString("OrderListMongo"));
            mongoDatabase = mongoClient.GetDatabase("ECommerce");
            mongoCollection = mongoDatabase.GetCollection<ListingOrder>("ListingOrder");
        }

        public async Task Insert(ListingOrder listingOrderDocument)
        {
            await mongoCollection.InsertOneAsync(listingOrderDocument);
        }

        public async Task<ListingOrder> GetByCode(string code)
        {
            var filter = Builders<ListingOrder>.Filter.Eq("Code", code);
            var entity = mongoCollection.Find(filter);
            return await entity.SingleOrDefaultAsync();
        }
    }
}