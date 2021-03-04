using System;
using System.Collections.Generic;
using System.Linq;
using OrderApi.DatabaseSettings;
using OrderApi.Http;
using OrderApi.Models;
using OrderApi.Repository;
using OrderApi.Repository.Interfaces;
using OrderApi.Services.Interfaces;

namespace OrderApi.Services
{
    public class CustomerServices : BaseServices<OrderModel>, IOrderServices
    {
        public CustomerServices(IMongoContext mongoContext, OrderDatabaseSettings databaseSettings)
        {
            Repository = new OrderRepository(mongoContext, databaseSettings.OrderCollectionName);
        }
        public sealed override IBaseRepository<OrderModel> Repository { get; set; }

        public List<OrderModel> GetByCustomerId(Guid customerId)
        {
            var orderModels = Repository.FindMany(x => x.CustomerId == customerId);

            if(orderModels == null || !orderModels.Any())
                throw new HttpNotFound(customerId.ToString());

            return orderModels;
        }
        
    }
}