using System;
using System.Collections.Generic;
using System.Linq;
using CustomerApi.Models;
using CustomerApi.Models.Request;
using CustomerApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpPost("")]
        public ActionResult<Guid> CreateCustomer(CustomerCreateRequestModel customerRequestModel)
        {
            var customerModel = _customerServices.Create(new CustomerModel(customerRequestModel));

            return customerModel.Id;
        }
        
        [HttpPut("")]
        public ActionResult<bool> UpdateCustomer(CustomerUpdateRequestModel customerRequestModel)
        {
            var customerModel = _customerServices.GetById(customerRequestModel.Id);
            customerModel.Update(customerRequestModel);
            return _customerServices.Update(customerRequestModel.Id, customerModel);
        }
        
        [HttpDelete("")]
        public ActionResult<bool> DeleteCustomer(Guid id)
        {
            return _customerServices.Remove(id);
        }
        
        [HttpGet("all")]
        public ActionResult<List<CustomerResponseModel>> GetCustomers()
        {
            var customers = _customerServices.GetAll();

            return customers.Select(customer => new CustomerResponseModel(customer)).ToList();
        }
        
        [HttpGet("")]
        public ActionResult<CustomerResponseModel> GetCustomer(Guid id)
        {
            var customerModel = _customerServices.GetById(id);
            return new CustomerResponseModel(customerModel);
        }
        
        [HttpGet("valid")]
        public ActionResult<bool> IsValid(Guid id)
        {
            return _customerServices.IsValid(id);
        }

    }
}