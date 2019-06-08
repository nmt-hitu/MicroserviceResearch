using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ordering.Domain.AggregatesModel.OrderAggregate
{
    public class Order : Entity
    {
        public virtual int CustomerId { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        //public Order(string emailAddress) : this()
        //{
        //    // Add the OrderStarterDomainEvent to the domain events collection 
        //    // to be raised/dispatched when comitting changes into the Database [ After DbContext.SaveChanges() ]
        //    AddOrderStartedDomainEvent(emailAddress);
        //}

        public virtual void AddOrderItem(string sku, decimal unitPrice, string productName, int quantity = 1)
        {
            var existingOrderForProduct = OrderItems.Where(o => o.SKU == sku)
                .SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                existingOrderForProduct.InscreaseQuantity(quantity);
            }
            else
            {
                //add validated new order item

                var orderItem = new OrderItem(sku, unitPrice, productName, quantity);
                OrderItems.Add(orderItem);
            }
        }

        //private void AddOrderStartedDomainEvent(string emailAddress)
        //{
        //    var orderStartedDomainEvent = new OrderStartedDomainEvent(emailAddress);

        //    this.AddDomainEvent(orderStartedDomainEvent);
        //}
    }
}
