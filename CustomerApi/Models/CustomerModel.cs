using System;
using CustomerApi.Models.Child;
using CustomerApi.Models.Request;

namespace CustomerApi.Models
{
    public class CustomerModel : BaseModel
    {
        public CustomerModel(CustomerCreateRequestModel customerRequestModel)
        {
            Name = customerRequestModel.Name;
            Email = customerRequestModel.Email;
            Address = customerRequestModel.Address;
            Password = customerRequestModel.Password;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Password { get; set; }

        public void Update(CustomerUpdateRequestModel customerUpdateRequestModel)
        {
            customerUpdateRequestModel.Address.AddressLine ??= "";
            Name = customerUpdateRequestModel.Name;
            Email = customerUpdateRequestModel.Email;
            Address = customerUpdateRequestModel.Address;
            Password = customerUpdateRequestModel.Password;
        }
    }
}