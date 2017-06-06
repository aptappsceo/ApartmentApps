using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;

namespace ApartmentApps.Api.BindingModels
{
    public static class ModelExtensions
    {


        public static UserBindingModel ToUserBindingModel(this ApplicationUser user, IBlobStorageService blobService)
        {
            return new UserBindingModel()
            {
                Archived = user.Archived,
                Id = user.Id,
                ImageUrl = blobService.GetPhotoUrl(user.ImageUrl) ?? $"http://www.gravatar.com/avatar/{HashEmailForGravatar(user.Email.ToLower())}.jpg",
                ImageThumbnailUrl = blobService.GetPhotoUrl(user.ImageThumbnailUrl) ?? $"http://www.gravatar.com/avatar/{HashEmailForGravatar(user.Email.ToLower())}.jpg",
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FirstName + " " + user.LastName,
                UnitName = user.Unit?.Name,
                BuildingName = user.Unit?.Building.Name,
                IsTenant = user.Unit != null,
                PhoneNumber = user.PhoneNumber,
                Address = user?.Address,
                City = user?.City,
                PostalCode = user?.PostalCode
            };
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
    }
}