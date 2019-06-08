using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using Customering.Domain;
using Customering.Domain.AggregatesModel.CustomerAggregate;
using System;
using System.Threading.Tasks;

namespace Customering.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        private readonly ITransaction tx;
        private readonly CustomerRepository customerRepository;

        public ICustomerRepository Customers => customerRepository;

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            session = sessionFactory.OpenSession();
            tx = session.BeginTransaction();
            customerRepository = new CustomerRepository(session);
        }

        public async Task CommitChanges()
        {

            // Dispatch Domain Events collection.         
            // Choices:         
            // A) Right BEFORE committing data (EF SaveChanges) into the DB. This makes         
            // a single transaction including side effects from the domain event         
            // handlers that are using the same DbContext with Scope lifetime         
            // B) Right AFTER committing data (EF SaveChanges) into the DB. This makes         
            // multiple transactions. You will need to handle eventual consistency and         
            // compensatory actions in case of failures.                 
            //await _mediator.DispatchDomainEventsAsync(this);

            await tx.CommitAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && session != null)
            {
                tx.Dispose();
                session.Dispose();
            }

        }
    }

    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        private readonly ISessionFactory sessionFactory;

        public UnitOfWorkProvider(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(sessionFactory);
        }
    }
}
