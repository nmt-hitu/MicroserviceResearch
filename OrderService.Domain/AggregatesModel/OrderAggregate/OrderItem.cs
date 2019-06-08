using OrderService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Domain.AggregatesModel.OrderAggregate
{
    public class OrderItem : Entity
    {
        #region Constructors
        public OrderItem()
        {
        }
        #endregion

        #region Propertises

        public int OrderID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal ExtendedPrice { get; set; }
        public int Quantity { get; set; }

        #endregion
    }
}
