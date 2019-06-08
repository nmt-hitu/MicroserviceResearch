using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T entity);
    }
}
