using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public class UserService : StandardCrudService<ApplicationUser, UserBindingModel>
    {
        private readonly IBlobStorageService _blobService;

        public UserService(IBlobStorageService blobService,IRepository<ApplicationUser> repository) : base(repository)
        {
            _blobService = blobService;
        }

        public override void ToModel(UserBindingModel viewModel, ApplicationUser model)
        {
            model.Id = viewModel.Id;
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
            viewModel.Address = user?.Address;
            viewModel.City = user?.City;
            viewModel.PostalCode = user?.PostalCode;
        }
    }
    public class BuildingService : StandardCrudService<Building, BuildingViewModel>
    {
        public BuildingService(IRepository<Building> repository) : base(repository)
        {
        }

        public override void ToModel(BuildingViewModel viewModel, Building model)
        {
            model.Name = viewModel.Name;
            model.Id = viewModel.Id;

        }

        public override void ToViewModel(Building model, BuildingViewModel viewModel)
        {
            viewModel.Name = model.Name;
            viewModel.Id = model.Id;
        }
    }
    public class UnitService : StandardCrudService<Unit, UnitViewModel>
    {
        public override void ToModel(UnitViewModel viewModel, Unit model)
        {

            model.Name = viewModel.Name;
            model.Latitude = viewModel.Latitude;
            model.Longitude = viewModel.Longitude;
            model.BuildingId = viewModel.BuildingId;

        }

        public override void ToViewModel(Unit model, UnitViewModel viewModel)
        {
            viewModel.Id = model.Id;
            viewModel.Name = model.Name;
            viewModel.Latitude = model.Latitude;
            viewModel.Longitude = model.Longitude;
            viewModel.BuildingId = model.BuildingId;
            viewModel.BuildingName = model.Building.Name;
        }

        public UnitService(IRepository<Unit> repository) : base(repository)
        {
        }

    }
    public abstract class StandardCrudService<TModel, TViewModel> : IService, IMapper<TModel, TViewModel> where TViewModel : BaseViewModel, new() where TModel : IBaseEntity, new()
    {
        public IRepository<TModel> Repository { get; set; }
        public IMapper<TModel, TViewModel> Mapper { get; set; }

        protected StandardCrudService(IRepository<TModel> repository) : this(repository, null)
        {
            Repository = repository;
            Mapper = this;
        }

        protected StandardCrudService(IRepository<TModel> repository, IMapper<TModel, TViewModel> mapper)
        {
            Repository = repository;
            Mapper = mapper;
            if (Mapper == null)
                Mapper = this;
        }
        public IEnumerable<TViewModel> GetAll()
        {
            return Repository.GetAll().ToArray().Select(Mapper.ToViewModel);
        }

        public IEnumerable<TViewModel> GetRange(int skip, int take)
        {
            return Repository.GetAll().Skip(skip).Take(take).Select(Mapper.ToViewModel);
        }
        public void Add(TViewModel viewModel)
        {
            Repository.Add(Mapper.ToModel(viewModel));
            Repository.Save();

        }

        public void Remove(int id)
        {
            Repository.Remove(Repository.Find(id));
            Repository.Save();
        }

        public TViewModel Find(int id)
        {

            var vm = new TViewModel();
            Mapper.ToViewModel(Repository.Find(id), vm);
            return vm;
        }

        public abstract void ToModel(TViewModel viewModel, TModel model);
        public TModel ToModel(TViewModel viewModel)
        {
            var model = new TModel();
            ToModel(viewModel, model);
            return model;
        }

        public abstract void ToViewModel(TModel model, TViewModel viewModel);
        public TViewModel ToViewModel(TModel model)
        {
            var viewModel = new TViewModel();
            ToViewModel(model, viewModel);
            return viewModel;
        }

        public TViewModel CreateNew()
        {
            return new TViewModel();
        }

        public void Save(TViewModel unit)
        {
            var result = Repository.Find(unit.Id);
            if (result != null)
            {
                Mapper.ToModel(unit, result);
            }
            else
            {
                Repository.Add(Mapper.ToModel(unit));

            }
            Repository.Save();
        }
    }
}