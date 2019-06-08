using NHibernate;
using Customering.Domain.AggregatesModel.CustomerAggregate;

namespace Customering.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ISession session;

        public CustomerRepository(ISession session)
        {
            this.session = session;
        }

        public void Add(Domain.AggregatesModel.CustomerAggregate.Customer customer)
        {
            session.Save(customer);
        }
    }
}
