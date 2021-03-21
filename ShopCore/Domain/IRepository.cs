using System;
using System.Linq;

namespace ShopCore.Domain
{
    public interface IRepository<T> where T : BaseObject
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T getById(int id);
        void SaveChanges();
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        int GetMaxId();

    }
}
