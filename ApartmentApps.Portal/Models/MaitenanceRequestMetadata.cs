using System;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Models
{
    [MetadataType(typeof(MaitenanceRequestMetadata))]
    public partial class MaitenanceRequest
    {
    }

    public partial class MaitenanceRequestMetadata
    {
        [Display(Name = "Actions")]
        public MaitenanceAction Actions { get; set; }

        [Display(Name = "MaitenanceRequestType")]
        public MaitenanceRequestType MaitenanceRequestType { get; set; }

        [Display(Name = "User")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Worker")]
        public ApplicationUser Worker { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "UserId")]
        public string UserId { get; set; }

        [Display(Name = "WorkerId")]
        public string WorkerId { get; set; }

        [Display(Name = "MaitenanceRequestTypeId")]
        public int MaitenanceRequestTypeId { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

    }
}
