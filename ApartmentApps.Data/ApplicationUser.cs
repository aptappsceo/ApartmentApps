using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.Data
{
    public enum PaymentOptionType
    {
        CreditCard,
        Checking,
        Savings
    }
    public class UserPaymentOption : PropertyEntity
    {
        public string FriendlyName { get; set; }

        public string TokenId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public PaymentOptionType Type { get; set; }
    }

    public class UserTransaction : PropertyEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateExecuted { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }


    }

    public class UserCharges : PropertyEntity
    {
        
    }
    public class UserLeaseAgreement : PropertyEntity
    {
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IPropertyEntity
    {
        [Key]
        public override string Id { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }

        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        public string ThirdPartyId { get; set; }

        public string MiddleName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Gender { get; set; }

        [NotMapped]
        public TimeZoneInfo TimeZone => Property.TimeZone ?? TimeZoneInfo.Local;

        public virtual ICollection<MaitenanceRequest> MaitenanceRequests { get; set; }
        public virtual ICollection<UserAlert> UserAlerts { get; set; }

        public string DevicePlatform { get; set; }

        public string DeviceToken { get; set; }

        public int? ForteClientId { get; set; }

        int IBaseEntity.Id => 0;

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}