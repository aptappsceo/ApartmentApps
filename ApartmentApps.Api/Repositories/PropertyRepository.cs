using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ApartmentApps.Api
{
    public interface IEntityAdded<TEntityType>
    {
        void EntityAdded(TEntityType entity);
    }

    public interface IEntityRemoved<TEntityType>
    {
        void EntityRemoved(TEntityType entity);
    }

    public class PropertyRepository<TEntity> : IRepository<TEntity> where TEntity : class, IPropertyEntity
    {
        private readonly IModuleHelper _moduleHelper;

        public PropertyRepository(IModuleHelper moduleHelper, Func<IQueryable<TEntity>, IDbSet<TEntity>> includes, DbContext context, IUserContext userContext)
        {
            _moduleHelper = moduleHelper;
            Context = context;
            UserContext = userContext;
            IncludesFunc = includes;
        }

        public PropertyRepository(IModuleHelper moduleHelper, DbContext context, IUserContext userContext)
        {
            Context = context;
            UserContext = userContext;
            _moduleHelper = moduleHelper;
        }

        public DbContext Context { get; set; }
        public Func<IQueryable<TEntity>, IDbSet<TEntity>> IncludesFunc { get; set; }
        public IUserContext UserContext { get; set; }
        public IQueryable<TEntity> WithIncludes => this.Includes(Context.Set<TEntity>());

        public virtual void Add(TEntity entity)
        {
            entity.PropertyId = UserContext.PropertyId;
            Context.Set<TEntity>().Add(entity);
            _moduleHelper.SignalToAll<IEntityAdded<TEntity>>(_ => _.EntityAdded(entity));
        }

        public int Count()
        {
            return GetAll().Count();
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

        public virtual IQueryable<TEntity> GetAll()
        {
            var propertyId = UserContext.PropertyId;
            return WithIncludes.Where(p => p.PropertyId == null || p.PropertyId == propertyId);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        public IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> path)
        {
            return WithIncludes.Include(path);
        }

        public virtual IQueryable<TEntity> Includes(IDbSet<TEntity> set)
        {
            if (IncludesFunc != null)
            {
                return Includes(set);
            }
            return set;
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity.PropertyId == UserContext.PropertyId)
            {
                Context.Set<TEntity>().Remove(entity);
               _moduleHelper.SignalToAll<IEntityRemoved<TEntity>>(_ => _.EntityRemoved(entity));
            }
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        sb.AppendFormat("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new Exception(sb.ToString(), ex);
            }
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null) return GetAll();
            return GetAll().Where(predicate);
        }
    }

    [Persistant]
    public class ServiceQuery : PropertyEntity
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string QueryId { get; set; }
        public string QueryJson { get; set; }
        public string Service { get; set; }
    }

    public class UserRepository<TEntity> : PropertyRepository<TEntity> where TEntity : class, IUserEntity
    {
        //public UserRepository(Func<IQueryable<TEntity>, IDbSet<TEntity>> includes, DbContext context, IUserContext userContext) : base(includes, context, userContext)
        //{
        //}

        public UserRepository(IModuleHelper moduleHelper, DbContext context, IUserContext userContext) : base(moduleHelper,context, userContext)
        {
        }

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
}