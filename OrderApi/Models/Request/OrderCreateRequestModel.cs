using System;
using OrderApi.Models.Child;

namespace OrderApi.Models.Request
{
    public class OrderCreateRequestModel
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }
    }
}