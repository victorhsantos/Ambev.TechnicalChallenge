using DeveloperStore.Domain.Validation;
using FluentValidation;

namespace DeveloperStore.Domain.Entities
{
    public class Customer
    {
        public Customer(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;

            new CustomerValidator().ValidateAndThrow(this);
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
