using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ApartmentApps.Api;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public class UserMapper : BaseMapper<ApplicationUser, UserBindingModel>
    {
        private readonly IBlobStorageService _blobService;

        public UserMapper(IBlobStorageService blobService)
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
        }
    }
    public class UserService : SearchableCrudService<ApplicationUser, UserBindingModel, UserBindingModel>
    {
        public UserService(IRepository<ApplicationUser> repository, IMapper<ApplicationUser, UserBindingModel> mapper) : base(repository, mapper)
        {
        }

        public override IEnumerable<SearchFieldMutator<ApplicationUser, UserBindingModel>> GetMutators()
        {
            yield return Mutator(p => !string.IsNullOrEmpty(p.Email), (x, y) => x.Where(p => p.Email == y.Email));
        }
    }
}