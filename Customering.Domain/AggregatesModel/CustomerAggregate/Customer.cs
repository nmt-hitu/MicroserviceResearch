using Customering.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Customering.Domain.AggregatesModel.CustomerAggregate
{
    public class Customer : Entity
    {
        public virtual string Email  { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }
    }
}
