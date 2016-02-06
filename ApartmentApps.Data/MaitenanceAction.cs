using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.API.Service.Models
{
    public class MaitenanceAction
    {
        public int MaitenanceRequestId { get; set; }

        [ForeignKey("MaitenanceRequestId")]
        public MaitenanceRequest MaitenanceRequest { get; set; }
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public MaitenanceActionType ActionType { get; set; }


    }
}