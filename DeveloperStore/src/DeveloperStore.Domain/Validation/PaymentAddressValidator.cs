using DeveloperStore.Domain.ValueObjects;
using FluentValidation;

namespace DeveloperStore.Domain.Validation
{
    public class PaymentAddressValidator : AbstractValidator<PaymentAddress>
    {
        public PaymentAddressValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.")
                .Length(5, 100).WithMessage("Street must be between 5 and 100 characters.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .Length(2, 50).WithMessage("City must be between 2 and 50 characters.");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State is required.")
                .Length(2, 50).WithMessage("State must be between 2 and 50 characters.");
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Postal Code is required.")
                .Matches(@"^\d{5}-\d{3}$").WithMessage("Invalid zip code format.");
        }
    }
}
