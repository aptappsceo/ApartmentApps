using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api
{
    public class PropertyRepository<TEntity> : IRepository<TEntity> where TEntity : class,IPropertyEntity
    {
        public DbContext Context { get; set; }
        public IUserContext UserContext { get; set; }
        public PropertyRepository(Func<IQueryable<TEntity>, IDbSet<TEntity>> includes, DbContext context, IUserContext userContext)
        {
            Context = context;
            UserContext = userContext;
            IncludesFunc = includes;
        }

        public Func<IQueryable<TEntity>, IDbSet<TEntity>> IncludesFunc { get; set; }

        public PropertyRepository(DbContext context, IUserContext userContext)
        {
            Context = context;
            UserContext = userContext;
        }

        public void Add(TEntity entity)
        {
            entity.PropertyId = UserContext.PropertyId;
            Context.Set<TEntity>().Add(entity);
           
        }

        public void Remove(TEntity entity)
        {
            if (entity.PropertyId == UserContext.PropertyId)
            {
                Context.Set<TEntity>().Remove(entity);
            
            }
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            var propertyId = UserContext.PropertyId;
            return WithIncludes.Where(p => p.PropertyId == propertyId);
        }
        public IQueryable<TEntity> WithIncludes => this.Includes(Context.Set<TEntity>());

        public virtual IQueryable<TEntity> Includes(IDbSet<TEntity> set)
        {
            if (IncludesFunc != null)
            {
                return Includes(set);
            }
            return set;
        }

        public TEntity Find(object id)
        {
            var propertyId = UserContext.PropertyId;
            var result = Context.Set<TEntity>().Find(id);
            if (propertyId != result.PropertyId) return null;
            return result;
        }

        public int Count()
        {
            return GetAll().Count();
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