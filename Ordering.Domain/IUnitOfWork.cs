using Ordering.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Threading.Tasks;

namespace Ordering.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }

        Task CommitChanges();
    }

    public interface IUnitOfWorkProvider
    {
        IUnitOfWork Create();
    }
}
