using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using OrderApi.Client;
using OrderApi.Client.Interfaces;
using OrderApi.DatabaseSettings;
using OrderApi.Http;
using OrderApi.Models;
using OrderApi.Repository;
using OrderApi.Repository.Interfaces;
using OrderApi.Services.Interfaces;

namespace OrderApi.Services
{
    public class OrderServices : BaseServices<OrderModel>, IOrderServices
    {
        public OrderServices(IMongoContext mongoContext, OrderDatabaseSettings databaseSettings)
        {
            Repository = new OrderRepository(mongoContext, databaseSettings.OrderCollectionName);
            MyHttpClient = new MyHttpClient(databaseSettings.CustomerBaseAddress);
        }
        public sealed override IBaseRepository<OrderModel> Repository { get; set; }
        public sealed override IMyHttpClient MyHttpClient { get; set; }

        public new OrderModel Create(OrderModel document)
        {
            var response = GetIsCustomerValid(document.CustomerId);
            
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result == "true")
                {
                    return Repository.Insert(document);
                }
            }

            throw new HttpNotFound(document.CustomerId.ToString());

        }
        public List<OrderModel> GetByCustomerId(Guid customerId)
        {
            var orderModels = Repository.FindMany(x => x.CustomerId == customerId);

            if(orderModels == null || !orderModels.Any())
                throw new HttpNotFound(customerId.ToString());

            return orderModels;
        }
        private HttpResponseMessage GetIsCustomerValid(Guid customerId)
        {
            try
            {
                return MyHttpClient.GetAsync("api/customer/valid?id=" + customerId ).Result;
            }
            catch (Exception e)
            {
                throw new HttpServiceUnavailable();
            }
            
        }
        
    }
}