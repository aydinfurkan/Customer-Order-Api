using System;
using System.Collections.Generic;
using OrderApi.Models;

namespace OrderApi.Services.Interfaces
{
    public interface IOrderServices : IBaseService<OrderModel>
    {
        public List<OrderModel> GetByCustomerId(Guid customerId);
    }
}