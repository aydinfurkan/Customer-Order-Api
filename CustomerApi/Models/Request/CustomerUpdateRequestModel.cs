using System;
using CustomerApi.Models.Child;

namespace CustomerApi.Models.Request
{
    public class CustomerUpdateRequestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Password { get; set; }
    }
}