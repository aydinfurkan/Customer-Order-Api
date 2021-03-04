using System;
using CustomerApi.Http;
using CustomerApi.Models.Request;
using FluentValidation;

namespace CustomerApi.Validators
{
    public class CustomerCreateValidator : AbstractValidator<CustomerCreateRequestModel>
    {
        public CustomerCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Name is required"));
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Email is required"));
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Password is required"));
            RuleFor(x => x.Address.City)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("City is required"));
            RuleFor(x => x.Address.Country)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("Country is required"));
            RuleFor(x => x.Address.CityCode)
                .NotNull()
                .NotEmpty()
                .OnFailure(x => throw new HttpBadRequest("CityCode is required"));
        }

    }
}