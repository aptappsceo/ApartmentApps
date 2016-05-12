using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.BindingModels
{
    public class FeedItemBindingModel
    {
        public UserBindingModel User { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Message { get; set; }

        public string[] Photos { get; set; }
        public string Description { get; set; }
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

    public class MaintenanceIndexBindingModel : BaseViewModel
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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Label { get; set; }
        public List<string> AcceptableCheckinCodes { get; set; }
        public int Id { get; set; }
        public bool Complete { get; set; }
        public DateTime? Date { get; set; }
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
        public int Id { get; set; }
    }
    public class IncidentCheckinBindingModel
    {
        public string StatusId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public List<ImageReference> Photos { get; set; }

        public UserBindingModel Officer { get; set; }
    }

    public class IncidentIndexBindingModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Comments { get; set; }
        public string StatusId { get; set; }
      
        public DateTime RequestDate { get; set; }
        public UserBindingModel ReportedBy { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public IncidentCheckinBindingModel LatestCheckin { get; set; }
        public string Reporter { get; set; }
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
                Officer = x.Officer.ToUserBindingModel(blob),
                Photos = blob.GetImages(x.GroupId).Select(s=>new ImageReference() { ThumbnailUrl = s, Url = s}).ToList(),

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
                Photos = blob.GetImages(x.GroupId).Select(s => new ImageReference() { ThumbnailUrl = s, Url = s }).ToList()
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
