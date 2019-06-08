using Customering.Domain.AggregatesModel.CustomerAggregate;
using System;
using System.Threading.Tasks;

namespace Customering.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }

        Task CommitChanges();
    }

    public interface IUnitOfWorkProvider
    {
        IUnitOfWork Create();
    }
}
