using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Korzh.EasyQuery.Db;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class UserService : StandardCrudService<ApplicationUser>
    {
        private readonly ApplicationDbContext _ctx;

        

        public override string DefaultOrderBy => "LastName";
        
        public UserService(IKernel kernel, IRepository<ApplicationUser> repository, ApplicationDbContext ctx) : base(kernel, repository)
        {
            _ctx = ctx;
        }

        public IQueryable<ApplicationUser> GetUsersInRole(string roleName)
        {
          if (_ctx != null && roleName != null)
          {
            var roles = _ctx.Roles.Where(r => r.Name == roleName);
            if (roles.Any())
            {
              var roleId = roles.First().Id;
              return Repository.Where(user => user.Roles.Any(r => r.RoleId == roleId));
            }
          }
          return null;
        }

        public IEnumerable<TViewModel> GetActive<TViewModel>(DbQuery query, out int count, string orderBy, bool orderByDesc, int page = 1, int resultsPerPage = 20)
        {
            return GetAll<TViewModel>(Repository.Where(p=>!p.Archived), query, out count, orderBy, orderByDesc, page, resultsPerPage);
        }

        public DbQuery All()
        {
            return this.CreateQuery("All");
        }
        public DbQuery Archived()
        {
            return this.CreateQuery("Archived",new ConditionItem("ApplicationUser.Archived","Equal","true"));
        }
        public List<TViewModel> GetUsersInRole<TViewModel>(string roleName)
        {
            var transform = _kernel.Get<IMapper<ApplicationUser, TViewModel>>();
            var users = GetUsersInRole(roleName);
            return users?.ToArray().Select(s => transform.ToViewModel(s)).ToList();
        }

        public override void Remove(string id)
        {
            //base.Remove(id);
            Repository.Find(id).Archived = true;
            Repository.Save();
        }

        public void Unarchive(string id)
        {
            //base.Remove(id);
            Repository.Find(id).Archived = false;
            Repository.Save();
        }
    }
}