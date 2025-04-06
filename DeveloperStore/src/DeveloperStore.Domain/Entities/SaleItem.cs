using DeveloperStore.Domain.Validation;
using FluentValidation;

namespace DeveloperStore.Domain.Entities
{
    public class SaleItem
    {
        public SaleItem(Guid productId, int quantity, decimal unitPrice)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;

            ApplyDiscount();

            new SaleItemValidator().ValidateAndThrow(this);
        }

        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalAmount => (UnitPrice * Quantity) - Discount;

        private void ApplyDiscount()
        {
            if (Quantity >= 10 && Quantity <= 20)
                Discount = Quantity * UnitPrice * 0.20m;
            else if (Quantity >= 4)
                Discount = Quantity * UnitPrice * 0.10m;
            else
                Discount = 0;
        }
    }
}
