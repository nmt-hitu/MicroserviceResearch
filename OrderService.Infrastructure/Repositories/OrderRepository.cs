using NHibernate;
using OrderService.Domain.AggregatesModel.OrderAggregate;
using OrderService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repositories
{
    public class OrderRepository
        : IOrderRepository
    {
        protected readonly ISession _session;

        //public IUnitOfWork UnitOfWork
        //{
        //    get
        //    {
        //        return _session;
        //    }
        //}

        public OrderRepository(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public OrderItem Add(OrderItem order)
        {
            using (var transaction = this._session.BeginTransaction())
            {
                this._session.Save(order);

                transaction.Commit();

                return order;
            }
        }

        public async Task<OrderItem> GetAsync(int orderId)
        {
            var order = await _session.GetAsync<OrderItem>(orderId);
            //if (order != null)
            //{
            //    await _session.Entry(order)
            //        .Collection(i => i.OrderItems).LoadAsync();
            //    await _session.Entry(order)
            //        .Reference(i => i.OrderStatus).LoadAsync();
            //    await _session.Entry(order)
            //        .Reference(i => i.Address).LoadAsync();
            //}

            return order;
        }

        public void Update(OrderItem order)
        {
            using (var transaction = this._session.BeginTransaction())
            {
                if (this._session.Contains(order))
                {
                    order = this._session.Merge(order);
                }

                this._session.Update(order);

                transaction.Commit();
            }
        }
    }
}
