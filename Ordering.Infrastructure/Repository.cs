using NHibernate;
using Ordering.Domain;
using System.Linq;

namespace Ordering.Infrastructure
{
    //public class Repository<T> : IRepository<T> where T : IEntity
    //{
    //    private UnitOfWork _unitOfWork;
    //    public Repository(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = (UnitOfWork)unitOfWork;
    //    }

    //    protected ISession Session { get { return _unitOfWork.Session; } }

    //    public void Add(T entity)
    //    {
    //        Session.Save(entity);
    //    }
    //}
}
