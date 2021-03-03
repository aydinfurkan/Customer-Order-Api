namespace CustomerApi.Models
{
    public class CustomerResponseModel : BaseModel
    {
        public CustomerResponseModel(CustomerModel customerModel)
        {
            Id = customerModel.Id;
            CreatedTime = customerModel.CreatedTime;
            UpdatedTime = customerModel.UpdatedTime;
            Name = customerModel.Name;
            Email = customerModel.Email;
            Address = customerModel.Address;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        
    }
}