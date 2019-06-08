using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
