using System;
using CustomerApi.Models.Request;

namespace CustomerApi.Models
{
    public class CustomerModel : BaseModel
    {
        public CustomerModel(string name, string email, Address address, string password)
        {
            Name = name;
            Email = email;
            Address = address;
            Password = password;
        }

        public CustomerModel(CustomerCreateRequestModel customerRequestModel)
        {
            Name = customerRequestModel.Name;
            Email = customerRequestModel.Email;
            Address = customerRequestModel.Address;
            Password = customerRequestModel.Password;
        }

        public CustomerModel(CustomerUpdateRequestModel customerRequestModel)
        {
            Id = customerRequestModel.Id;
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