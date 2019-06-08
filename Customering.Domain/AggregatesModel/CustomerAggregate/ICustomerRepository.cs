using System;
using System.Collections.Generic;
using System.Text;

namespace Customering.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
    }
}
