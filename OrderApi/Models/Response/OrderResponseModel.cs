using System;
using OrderApi.Models.Child;

namespace OrderApi.Models.Response
{
    public class OrderResponseModel : BaseModel
    {
        public OrderResponseModel(OrderModel orderModel)
        {
            Id = orderModel.Id;
            CreatedTime = orderModel.CreatedTime;
            UpdatedTime = orderModel.UpdatedTime;
            CustomerId = orderModel.CustomerId;
            Quantity = orderModel.Quantity;
            Price = orderModel.Price;
            Status = orderModel.Status;
            Product = orderModel.Product;
            Address = orderModel.Address;
        }

        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }
        
    }
}