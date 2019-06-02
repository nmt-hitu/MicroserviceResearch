using FluentNHibernate.Mapping;
using OrderService.Domain.AggregatesModel.OrderAggregate;

namespace OrderService.Infrastructure.Maps
{
    public class OrderMap:  ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Order");

            Map(o => o.CustomerID);
        }
    }
}
