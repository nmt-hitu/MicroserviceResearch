using FluentNHibernate.Mapping;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Infrastructure.Maps
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id);
            Map(x => x.CustomerId);
            HasMany(x => x.OrderItems).Cascade.All();
        }
    }
}
