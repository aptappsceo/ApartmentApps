using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public class MaitenanceRequest
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string WorkerId { get; set; }
        public int MaitenanceRequestTypeId { get; set; }

        [ForeignKey("WorkerId")]
        public ApplicationUser Worker { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [ForeignKey("MaitenanceRequestTypeId")]
        public MaitenanceRequestType MaitenanceRequestType { get; set; }

        public ICollection<MaitenanceAction> Actions { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}