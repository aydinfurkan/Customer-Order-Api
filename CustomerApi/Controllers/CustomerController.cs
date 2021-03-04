using System;
using System.Collections.Generic;
using CustomerApi.Models;
using CustomerApi.Models.Request;
using CustomerApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
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
            var customer = _customerServices.GetById(customerRequestModel.Id);
            customer.Update(customerRequestModel);
            return _customerServices.Update(customerRequestModel.Id, customer);
        }
        
        [HttpDelete("")]
        public ActionResult<bool> DeleteCustomer(Guid id)
        {
            _customerServices.Remove(id);
            return Ok();
        }
        
        [HttpGet("all")]
        public ActionResult<List<CustomerResponseModel>> GetCustomers()
        {
            var customers = _customerServices.GetAll();
            
            List<CustomerResponseModel> customersResponse = new List<CustomerResponseModel>();
            foreach (var customer in customers)
            {
                customersResponse.Add(new CustomerResponseModel(customer));
            }

            return customersResponse;
        }
        
        [HttpGet("")]
        public ActionResult<CustomerResponseModel> GetCustomer(Guid id)
        {
            var customer = _customerServices.GetById(id);
            return new CustomerResponseModel(customer);
        }
        
        [HttpGet("valid")]
        public ActionResult<bool> IsValid(Guid id)
        {
            return _customerServices.IsValid(id);
        }

    }
}