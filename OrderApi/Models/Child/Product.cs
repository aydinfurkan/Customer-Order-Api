using System;
using OrderApi.Models.Request.Child;

namespace OrderApi.Models.Child
{
    public class Product
    {
        public Product(ProductRequest productRequest)
        {
            Id = Guid.NewGuid();
            Name = productRequest.Name;
            ImageUrl = productRequest.ImageUrl;
        }
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}