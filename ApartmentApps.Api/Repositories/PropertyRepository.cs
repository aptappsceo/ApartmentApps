using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api
{
    public class UserRepository<TEntity> : PropertyRepository<TEntity> where TEntity : class, IUserEntity
    {
        //public UserRepository(Func<IQueryable<TEntity>, IDbSet<TEntity>> includes, DbContext context, IUserContext userContext) : base(includes, context, userContext)
        //{
        //}

        public override void Add(TEntity entity)
        {
            entity.UserId = UserContext.UserId;
            base.Add(entity);
        }

        public override TEntity Find(object id)
        {
            var propertyId = UserContext.PropertyId;
            if (id != null)
            {
                int v;
                if (int.TryParse(id.ToString(), out v))
                {
                    var result = Context.Set<TEntity>().Find(v);

                    if (propertyId != result.PropertyId || UserContext.UserId != result.UserId) return null;
                    return result;

                }
                else
                {
                    var result = Context.Set<TEntity>().Find(id);

                    if (propertyId != result.PropertyId || UserContext.UserId != result.UserId) return null;
                    return result;
                }
            }
            return null;
            //return base.Find(id);
        }

        public UserRepository(DbContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public override IQueryable<TEntity> GetAll()
        {
            var propertyId = UserContext.PropertyId;
            var userId = UserContext.UserId;
            return WithIncludes.Where(p => p.PropertyId == propertyId && p.UserId == userId);
        }

        public override void Remove(TEntity entity)
        {
          
            if (entity.UserId == UserContext.UserId)
            {
                base.Remove(entity);
            }
        }
    }
    public interface IEntityAdded<TEntityType>
    {
        void EntityAdded(TEntityType entity);
    }
    public interface IEntityRemoved<TEntityType>
    {
        void EntityRemoved(TEntityType entity);
    }

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

        public virtual void Add(TEntity entity)
        {
            entity.PropertyId = UserContext.PropertyId;
            Context.Set<TEntity>().Add(entity);
            Modules.Modules.AllModules.Signal<IEntityAdded<TEntity>>(_ => _.EntityAdded(entity));
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity.PropertyId == UserContext.PropertyId)
            {
                Context.Set<TEntity>().Remove(entity);
                Modules.Modules.AllModules.Signal<IEntityRemoved<TEntity>>(_ => _.EntityRemoved(entity));
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual IQueryable<TEntity> GetAll()
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

        public virtual TEntity Find(object id)
        {
            var propertyId = UserContext.PropertyId;
            if (id != null)
            {
                int v;
                if (int.TryParse(id.ToString(), out v))
                {
                    var result = Context.Set<TEntity>().Find(v);

                    if (propertyId != result.PropertyId) return null;
                    return result;

                }
                else
                {
                    var result = Context.Set<TEntity>().Find(id);

                    if (propertyId != result.PropertyId) return null;
                    return result;
                }
            }
            return null;
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