using Microsoft.EntityFrameworkCore;
using ShopCore;
using ShopCore.Domain;
using ShopRepository.ShopContext;
using System;
using System.Linq;


namespace ShopServices.ShopRepoServices
{
    public class RepositoryService<T> : IRepository<T> where T : BaseObject
    {
        private readonly ShopDbContext _shopContext;
        private DbSet<T> _entities;
        public RepositoryService(ShopDbContext shopContext)
        {
            _shopContext = shopContext;
            _entities = shopContext.Set<T>();
        }
        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Where(predicate);
            return query;
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
          _entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _shopContext.Entry(entity).State = EntityState.Modified;
        }
        public  void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
        }

        public T getById(int id)
        {
            return  _entities.SingleOrDefault(s => s.BaseId == id);
        }
        public void SaveChanges()
        {
            _shopContext.SaveChanges();
        }
    
        public IQueryable<T> GetAll()
        {
            return  _entities.AsQueryable();
        }

    

    }
}
