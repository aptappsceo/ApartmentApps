using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
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

        [Display(Name = "Status")]
        public MaintenanceRequestStatus Status { get; set; }

        [Display(Name = "Unit")]
        public Unit Unit { get; set; }

        [Display(Name = "User")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Worker")]
        public ApplicationUser Worker { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Request By")]
        public string UserId { get; set; }

        [Display(Name = "Worker")]
        public string WorkerId { get; set; }

        [Display(Name = "Type")]
        public int MaitenanceRequestTypeId { get; set; }

        [Display(Name = "Unit")]
        public int UnitId { get; set; }

        [Display(Name = "SubmissionDate")]
        public DateTime SubmissionDate { get; set; }

        [Display(Name = "ScheduleDate")]
        public DateTime ScheduleDate { get; set; }

        [Display(Name = "CloseDate")]
        public DateTime CloseDate { get; set; }

        [Display(Name = "Status")]
        public string StatusId { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

    }
}
