using NHibernate;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ISession session;

        public OrderRepository(ISession session)
        {
            this.session = session;
        }

        public void Add(Order order)
        {
            session.Save(order);
        }
    }
}
