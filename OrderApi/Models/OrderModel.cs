using System;
using OrderApi.Models.Child;
using OrderApi.Models.Request;

namespace OrderApi.Models
{
    public class OrderModel : BaseModel
    {
        public OrderModel(OrderCreateRequestModel customerRequestModel)
        {
            CustomerId = customerRequestModel.CustomerId;
            Quantity = customerRequestModel.Quantity;
            Price = customerRequestModel.Price;
            Status = customerRequestModel.Status;
            Product = customerRequestModel.Product;
            Address = customerRequestModel.Address;
        }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }

        public void Update(OrderUpdateRequestModel customerUpdateRequestModel)
        {
            customerUpdateRequestModel.Address.AddressLine ??= "";
            Id = customerUpdateRequestModel.Id;
            CustomerId = customerUpdateRequestModel.CustomerId;
            Quantity = customerUpdateRequestModel.Quantity;
            Price = customerUpdateRequestModel.Price;
            Status = customerUpdateRequestModel.Status;
            Product = customerUpdateRequestModel.Product;
            Address = customerUpdateRequestModel.Address;
        }
    }
}