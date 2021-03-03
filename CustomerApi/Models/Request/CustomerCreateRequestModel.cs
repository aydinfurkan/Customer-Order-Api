namespace CustomerApi.Models.Request
{
    public class CustomerCreateRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Password { get; set; }
    }
}