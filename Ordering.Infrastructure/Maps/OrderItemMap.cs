using FluentNHibernate.Mapping;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Infrastructure.Maps
{
    public class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Id(x => x.Id);
            Map(x => x.ProductName);
            Map(x => x.SKU);
            Map(x => x.UnitPrice, "Price");
            Map(x => x.Quantity);
        }
    }
}
