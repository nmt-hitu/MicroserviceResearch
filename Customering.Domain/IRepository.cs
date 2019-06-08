using System;
using System.Collections.Generic;
using System.Text;

namespace Customering.Domain
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T entity);
    }
}
