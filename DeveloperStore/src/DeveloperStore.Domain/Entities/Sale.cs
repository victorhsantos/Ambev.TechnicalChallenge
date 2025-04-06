using DeveloperStore.Domain.Enums;
using DeveloperStore.Domain.Validation;
using DeveloperStore.Domain.ValueObjects;
using FluentValidation;

namespace DeveloperStore.Domain.Entities
{
    public class Sale
    {
        public Sale(Customer customer, PaymentAddress paymentAddress, List<SaleItem> items)
        {
            SaleNumber = Guid.NewGuid();
            SaleDate = DateTime.Now;
            Customer = customer;
            TotalAmount = items.Sum(i => i.TotalAmount);
            PaymentAddress = paymentAddress;
            Items = items;

            SetAsNotCancelled();

            new SaleValidator().ValidateAndThrow(this);
        }

        public Guid SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentAddress PaymentAddress { get; set; }
        public List<SaleItem> Items { get; set; }
        public SaleStatus Status { get; private set; }

        public void SetAsCancelled() => Status = SaleStatus.Cancelled;
        public void SetAsNotCancelled() => Status = SaleStatus.NotCancelled;
    }
}
