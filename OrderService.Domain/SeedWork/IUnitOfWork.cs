﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Domain.SeedWork
{
    //Ensure your work is working well
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
