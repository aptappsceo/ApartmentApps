using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Korzh.EasyQuery.Db;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{

    public interface IFillActions
    {
        void FillActions(List<ActionLinkModel> actions, object viewModel);
    }

    public interface IFillSections
    {
        //void FillSections(List<SetionViewModel> )
    }
    public class UserListMapper : BaseMapper<ApplicationUser, UserListModel>
    {
        public UserListMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(UserListModel viewModel, ApplicationUser model)
        {


        }

        public override void ToViewModel(ApplicationUser user, UserListModel viewModel)
        {
            if (user == null) return;
            viewModel.Id = user.Id;
        
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
         
            viewModel.UnitName = user.Unit?.Name;
            viewModel.BuildingName = user.Unit?.Building.Name;
        
            viewModel.PhoneNumber = user.PhoneNumber;
            viewModel.Email = user.Email;
        }
    }

    public class UserLookupMapper : BaseMapper<ApplicationUser, UserLookupBindingModel>
    {
        public UserLookupMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(UserLookupBindingModel viewModel, ApplicationUser model)
        {
            throw new NotImplementedException();
        }

        public override void ToViewModel(ApplicationUser model, UserLookupBindingModel viewModel)
        {
               if (model == null) return;
            viewModel.Id = model.Id;
            viewModel.Title = $"{model.FirstName} {model.LastName}";
            if (model.Unit != null) viewModel.Title+=$" [ {model.Unit?.Building.Name} {model.Unit?.Name} ]";
        }
    }

    public class UserMapper : BaseMapper<ApplicationUser, UserBindingModel>
    {
        private readonly IBlobStorageService _blobService;

        public UserMapper(IBlobStorageService blobService, IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
            _blobService = blobService;
        }

        public override void ToModel(UserBindingModel viewModel, ApplicationUser model)
        {
            model.Id = viewModel.Id.ToString();
            model.FirstName = viewModel.FirstName;
            model.LastName = viewModel.LastName;

        }
        /// Hashes an email with MD5.  Suitable for use with Gravatar profile
        /// image urls
        public static string HashEmailForGravatar(string email)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.  
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.  
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email.ToLower().Trim()));

            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();  // Return the hexadecimal string. 
        }
        public override void ToViewModel(ApplicationUser user, UserBindingModel viewModel)
        {
            if (user == null) return;
            viewModel.Id = user.Id;
            viewModel.ImageUrl = _blobService.GetPhotoUrl(user.ImageUrl) ??
                                 $"http://www.gravatar.com/avatar/{HashEmailForGravatar(user.Email.ToLower())}.jpg";
            viewModel.ImageThumbnailUrl = _blobService.GetPhotoUrl(user.ImageThumbnailUrl) ??
                                          $"http://www.gravatar.com/avatar/{HashEmailForGravatar(user.Email.ToLower())}.jpg";
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
            viewModel.FullName = user.FirstName + " " + user.LastName;
            viewModel.UnitName = user.Unit?.Name;
            viewModel.BuildingName = user.Unit?.Building.Name;

            viewModel.Title = $"{viewModel.FullName}";
            if (user.Unit != null) viewModel.Title+=$" [ {user.Unit?.Building.Name} {user.Unit?.Name} ]";

            viewModel.IsTenant = user.Unit != null;
            viewModel.PhoneNumber = user.PhoneNumber;
            viewModel.Email = user.Email;
            viewModel.Address = user?.Address;
            viewModel.City = user?.City;
            viewModel.PostalCode = user?.PostalCode;
            viewModel.Roles = user.Roles.Select(p => p.RoleId).ToArray();
            viewModel.Archived = user.Archived;
        }
    }

    public class UserSearchViewModel
    {
        public FilterViewModel Email { get; set; } = new FilterViewModel();
        public FilterViewModel FirstName { get; set; } = new FilterViewModel();
        public FilterViewModel LastName { get; set; } = new FilterViewModel();

        //[FilterPath("Unit.Name")]
        //public FilterViewModel UnitName { get; set; } = new FilterViewModel();

    }
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

    public class PropertyBindingModel : BaseViewModel
    {
        private readonly IRepository<Corporation> _corporationRepository;
        public string Name { get; set; }
        [DisplayName("Corporation")]
        public int CorporationId { get; set; }

        public PropertyBindingModel()
        {
        }

        public PropertyBindingModel(IRepository<Corporation> corporationRepository)
        {
            _corporationRepository = corporationRepository;
        }

        public IEnumerable<FormPropertySelectItem> CorporationId_Items
        {
            get
            {
                return
                    _corporationRepository
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, CorporationId == p.Id));


            }
        }

        public PropertyState State { get; set; }

    }

    public class PropertySearchModel
    {
        public FilterViewModel Name { get; set; }
    }
    public class PropertyMapper : BaseMapper<Property, PropertyBindingModel>
    {
        public PropertyMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(PropertyBindingModel viewModel, Property model)
        {
            model.Name = viewModel.Name;
            model.CorporationId = viewModel.CorporationId;
            model.State = viewModel.State;
        }

        public override void ToViewModel(Property model, PropertyBindingModel viewModel)
        {
            viewModel.Name = model.Name;
            viewModel.Id = model.Id.ToString();
            viewModel.State = model.State;
        }
    }
    public class PropertyService : StandardCrudService<Property>
    {
        public PropertyService(IKernel kernel, IRepository<Property> repository) : base(kernel, repository)
        {
        }

        public override string DefaultOrderBy =>"Name";

        [UserQuery("Engaging")]
        public IQueryable<Property> EngagingProperties()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            return Repository.Include(x=>x.MaitenanceRequests).Where(
                p => p.MaitenanceRequests.Any(x => x.SubmissionDate.Month == month && x.SubmissionDate.Year == year));
        }


        public DbQuery All()
        {
            return CreateQuery("All", new ConditionItem("Property.State","Equal","0"));
        }

        public DbQuery Suspended()
        {
            return CreateQuery("Suspended", new ConditionItem("Property.State", "Equal", "1"));
        }
        public DbQuery Archived()
        {
            return CreateQuery("Archived", new ConditionItem("Property.State", "Equal", "2"));
        }
    }
}