using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ApartmentApps.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
      
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            
            //_dbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            
            //_dbContext.SaveChanges();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return WithIncludes.Where(predicate);
        }

        public IQueryable<TEntity> WithIncludes => this.Includes(_dbContext.Set<TEntity>());
        public virtual IQueryable<TEntity> Includes(IDbSet<TEntity> set)
        {
            return set;
        }
        public IQueryable<TEntity> GetAll()
        {
            return WithIncludes;
        }

        public TEntity Find(object id)
        {
            if (id is string)
            {
                int result;
                if (int.TryParse((string)id, out result))
                {
                    return _dbContext.Set<TEntity>().Find(result);
                }
            }
            return _dbContext.Set<TEntity>().Find(id);
        }

        public int Count()
        {
            return GetAll().Count();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

  
}
