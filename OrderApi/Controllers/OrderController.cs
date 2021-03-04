using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using OrderApi.Models.Request;
using OrderApi.Models.Response;
using OrderApi.Services.Interfaces;

namespace OrderApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost("")]
        public ActionResult<Guid> CreateOrder(OrderCreateRequestModel orderRequestModel)
        {
            var orderModel = _orderServices.Create(new OrderModel(orderRequestModel));

            return orderModel.Id;
        }
        
        [HttpPut("")]
        public ActionResult<bool> UpdateOrder(OrderUpdateRequestModel orderRequestModel)
        {
            var orderModel = _orderServices.GetById(orderRequestModel.Id);
            orderModel.Update(orderRequestModel);
            return _orderServices.Update(orderRequestModel.Id, orderModel);
        }
        
        [HttpDelete("")]
        public ActionResult<bool> DeleteOrder(Guid id)
        {
            return _orderServices.Remove(id);
        }
        
        [HttpGet("all")]
        public ActionResult<List<OrderResponseModel>> GetOrders()
        {
            var orderModels = _orderServices.GetAll();

            return orderModels.Select(order => new OrderResponseModel(order)).ToList();
        }
        
        [HttpGet("")]
        public ActionResult<OrderResponseModel> GetOrder(Guid id)
        {
            var orderModel = _orderServices.GetById(id);
            return new OrderResponseModel(orderModel);
        }
        
        [HttpGet("customer")]
        public ActionResult<List<OrderResponseModel>> GetOrdersByCustomerId(Guid customerId)
        {
            var orderModels = _orderServices.GetByCustomerId(customerId);
            
            return orderModels.Select(order => new OrderResponseModel(order)).ToList();
        }
        
        [HttpPut("status")]
        public ActionResult<bool> ChangeStatus(Guid id, string status)
        {
            return _orderServices.UpdateField(id, order => order.Status, status);
        }

    }
}