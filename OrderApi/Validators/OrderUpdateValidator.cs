using FluentValidation;
using OrderApi.Http;
using OrderApi.Models.Request;

namespace OrderApi.Validators
{
    public class OrderUpdateValidator : AbstractValidator<OrderUpdateRequestModel>
    {
        public OrderUpdateValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Id is required"));
            RuleFor(x => x.CustomerId)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("CustomerId is required"));
            RuleFor(x => x.Quantity)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Quantity is required"));
            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Price is required"));
            RuleFor(x => x.Status)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Status is required"));
            RuleFor(x => x.Address.Country)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Country is required"));
            RuleFor(x => x.Address.CityCode)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("CityCode is required"));
            RuleFor(x => x.Address.City)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("City is required"));
            RuleFor(x => x.ProductRequest.ImageUrl)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("ImageUrl is required"));
            RuleFor(x => x.ProductRequest.Name)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Product name is required"));
        }

    }
}