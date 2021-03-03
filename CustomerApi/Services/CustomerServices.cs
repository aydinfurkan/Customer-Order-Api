using CustomerApi.DatabaseSettings;
using CustomerApi.Models;
using CustomerApi.Repository;
using CustomerApi.Repository.Interfaces;
using CustomerApi.Services.Interfaces;

namespace CustomerApi.Services
{
    public class CustomerServices : BaseServices<CustomerModel>, ICustomerServices
    {
        public CustomerServices(IMongoContext mongoContext, CustomerDatabaseSettings databaseSettings)
        {
            Repository = new CustomerRepository(mongoContext, databaseSettings.CustomerCollectionName);
        }

        public sealed override IBaseRepository<CustomerModel> Repository { get; set; }
    }
}