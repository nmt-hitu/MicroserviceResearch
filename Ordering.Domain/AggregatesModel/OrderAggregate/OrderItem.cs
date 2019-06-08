using System;

namespace Ordering.Domain.AggregatesModel.OrderAggregate
{
    public class OrderItem : Entity
    {
        public virtual string ProductName { get; set; }
        public virtual string SKU { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual int Quantity { get; set; }

        protected OrderItem() { }

        public OrderItem(string sku, decimal unitPrice, string productName, int quantity = 1)
        {
            SKU = sku;
            UnitPrice = unitPrice;
            Quantity = quantity;
            ProductName = productName;
        }

        public virtual void InscreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
