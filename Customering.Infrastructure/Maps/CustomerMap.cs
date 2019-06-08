using FluentNHibernate.Mapping;
using Customering.Domain.AggregatesModel.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customering.Infrastructure.Maps
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);
            Map(x => x.Email);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}
