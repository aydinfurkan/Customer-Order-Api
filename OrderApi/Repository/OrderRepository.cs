using OrderApi.Models;
using OrderApi.Repository.Interfaces;

namespace OrderApi.Repository
{
    public class OrderRepository : MongoRepository<OrderModel>, IOrderRepository
    {
        public OrderRepository(IMongoContext mongoContext, string collectionName) : base(mongoContext, collectionName)
        {
        }
    }
}