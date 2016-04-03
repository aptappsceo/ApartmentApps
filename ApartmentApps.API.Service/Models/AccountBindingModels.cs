using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ApartmentApps.Api;
using ApartmentApps.Data;
using Newtonsoft.Json;

namespace ApartmentApps.API.Service.Models
{
    // Models used as parameters to AccountController actions.
    public class UserBindingModel
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public bool IsTenant { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }

    public class MaintenanceBindingModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public IEnumerable<string> Photos { get; set; }
        public string UnitName { get; set; }
        public string Status { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int PetStatus { get; set; }
        public MaintenanceCheckinBindingModel[] Checkins { get; set; }
        public UserBindingModel User { get; set; }
        public string BuildingName { get; set; }
        public bool PermissionToEnter { get; set; }
    }

    public class MaintenanceIndexBindingModel
    {
        public string Title { get; set; }
        public string Comments { get; set; }
        public string StatusId { get; set; }
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public UserBindingModel SubmissionBy { get; set; }
        public MaintenanceCheckinBindingModel LatestCheckin { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
    }
    public class CourtesyCheckinBindingModel
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Label { get; set; }
        public List<string> AcceptableCheckinCodes { get; set; }
        public int Id { get; set; }
        public bool Complete { get; set; }
    }

    public class IncidentReportBindingModel
    {
        public string Comments { get; set; }
        public string IncidentType { get; set; }
        public IEnumerable<string> Photos { get; set; }
        public UserBindingModel Requester { get; set; }
        public string RequesterId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public string Status { get; set; }

        public IncidentCheckinBindingModel[] Checkins { get; set; }
        public string RequesterPhoneNumber { get; set; }
        public int? UnitId { get; set; }
    }
    public class IncidentCheckinBindingModel
    {
        public string StatusId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public List<ImageReference> Photos { get; set; }

        public UserBindingModel Officer { get; set; }
    }

    public class IncidentIndexBindingModel
    {
        public string Title { get; set; }
        public string Comments { get; set; }
        public string StatusId { get; set; }
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public UserBindingModel ReportedBy { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public IncidentCheckinBindingModel LatestCheckin { get; set; }
    }
    public class MaintenanceCheckinBindingModel
    {
        public string StatusId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public List<ImageReference> Photos { get; set; }
        public UserBindingModel Worker { get; set; }
    }

    public static class ModelExtensions
    {
               public static IncidentCheckinBindingModel ToIncidentCheckinBindingModel(this IncidentReportCheckin x, IBlobStorageService blob)
        {

            return new IncidentCheckinBindingModel
            {
                StatusId = x.StatusId,
                Date = x.CreatedOn,
                Comments = x.Comments,
                Officer= x.Officer.ToUserBindingModel(blob),
                Photos = blob.GetImages(x.GroupId).ToList(),
                
            };
        }
        public static MaintenanceCheckinBindingModel ToMaintenanceCheckinBindingModel(this MaintenanceRequestCheckin x, IBlobStorageService blob)
        {
       
            return new MaintenanceCheckinBindingModel
            {
                StatusId = x.StatusId,
                Date = x.Date,
                Comments = x.Comments,
                Worker = x.Worker.ToUserBindingModel(blob),
                Photos = blob.GetImages(x.GroupId).ToList()
            };
        }
        public static UserBindingModel ToUserBindingModel(this ApplicationUser user, IBlobStorageService blobService)
        {
            return new UserBindingModel()
            {
                Id = user.Id,
                ImageUrl = blobService.GetPhotoUrl(user.ImageUrl) ?? $"http://www.gravatar.com/avatar/{HashEmailForGravatar(user.Email.ToLower())}.jpg",
                ImageThumbnailUrl = blobService.GetPhotoUrl(user.ImageThumbnailUrl) ?? $"http://www.gravatar.com/avatar/{HashEmailForGravatar(user.Email.ToLower())}.jpg",
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FirstName + " " + user.LastName,
                UnitName = user.Tenant?.Unit?.Name,
                BuildingName = user.Tenant?.Unit?.Building.Name,
                IsTenant = user.Tenant != null,
                PhoneNumber = user.PhoneNumber,
                Address = user.Tenant?.Address,
                City = user.Tenant?.City,
                PostalCode = user.Tenant?.PostalCode
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
    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class SetDeviceTokenBindingModel
    {
        [Required]
        public string Platform { get; set; }
        [Required]
        public string DeviceToken { get; set; }
    }
    public class RegisterFromPhoneBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
