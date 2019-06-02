using FluentNHibernate.Mapping;
using OrderService.Domain.AggregatesModel.OrderAggregate;

namespace OrderService.Infrastructure.Maps
{
    public class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Table("OrderItem");

            Map(oi => oi.OrderID);
            Map(oi => oi.SKU);
            Map(oi => oi.ProductName);
            Map(oi => oi.Price);
            Map(oi => oi.ExtendedPrice);
            Map(oi => oi.Quantity);
        }
    }
}
