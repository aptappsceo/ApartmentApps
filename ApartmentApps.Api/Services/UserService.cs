using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using ApartmentApps.Api;
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
        public UserListMapper(IUserContext userContext) : base(userContext)
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
    public class UserMapper : BaseMapper<ApplicationUser, UserBindingModel>
    {
        private readonly IBlobStorageService _blobService;

        public UserMapper(IBlobStorageService blobService, IUserContext userContext) : base(userContext)
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
            viewModel.IsTenant = user.Unit != null;
            viewModel.PhoneNumber = user.PhoneNumber;
            viewModel.Email = user.Email;
            viewModel.Address = user?.Address;
            viewModel.City = user?.City;
            viewModel.PostalCode = user?.PostalCode;
            viewModel.Roles = user.Roles.Select(p => p.RoleId).ToArray();
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
      
        public override string DefaultOrderBy => "LastName";

        

        public UserService(IKernel kernel, IRepository<ApplicationUser> repository) : base(kernel, repository)
        {
        }

        public override void Remove(string id)
        {
            //base.Remove(id);
            Repository.Find(id).Archived = true;
            Repository.Save();
        }
    }

    public class PropertyBindingModel : BaseViewModel
    {
        public string Name { get; set; }
        public ActionLinkModel SwitchProperty => new ActionLinkModel("Switch Property", "ChangeProperty", "Account", new {id=Id});
    }

    public class PropertySearchModel
    {
        public FilterViewModel Name { get; set; }
    }
    public class PropertyMapper : BaseMapper<Property, PropertyBindingModel>
    {
        public PropertyMapper(IUserContext userContext) : base(userContext)
        {
        }

        public override void ToModel(PropertyBindingModel viewModel, Property model)
        {
            model.Name = viewModel.Name;
        }

        public override void ToViewModel(Property model, PropertyBindingModel viewModel)
        {
            viewModel.Name = model.Name;
            viewModel.Id = model.Id.ToString();
        }
    }
    public class PropertyService : StandardCrudService<Property>
    {
        public PropertyService(IKernel kernel, IRepository<Property> repository) : base(kernel, repository)
        {
        }

        public override string DefaultOrderBy =>"Name";

        public DbQuery All()
        {
            return CreateQuery("All");
        }
    }
}