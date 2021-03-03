using CustomerApi.Models;
using CustomerApi.Repository.Interfaces;

namespace CustomerApi.Repository
{
    public class CustomerRepository : MongoRepository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(IMongoContext mongoContext, string collectionName) : base(mongoContext, collectionName)
        {
        }
    }
}