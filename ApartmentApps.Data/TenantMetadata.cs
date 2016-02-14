using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    [MetadataType(typeof(TenantMetadata))]
    public partial class Tenant
    {
    }

    public partial class TenantMetadata
    {
        [Display(Name = "Unit")]
        public Unit Unit { get; set; }

        [Display(Name = "User")]
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Please enter : User")]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [Display(Name = "Unit")]
        public int UnitId { get; set; }

        [Display(Name = "ThirdPartyId")]
        public string ThirdPartyId { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "UnitNumber")]
        public string UnitNumber { get; set; }

        [Display(Name = "BuildingName")]
        public string BuildingName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "PostalCode")]
        public string PostalCode { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }

    }
}
