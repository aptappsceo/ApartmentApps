﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public partial class Unit
    {
        [Key]
        public int Id { get; set; }

        public int BuildingId { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        public virtual ICollection<MaitenanceRequest> MaitenanceRequests { get; set; } 

        public virtual ICollection<Tenant> Tenants { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }
        
        public decimal Longitude { get; set; }
    }

    public partial class CourtesyOfficerLocation
    {
        [Key]
        public int Id { get; set; }

        ////[Index("IX_LocationAndProperty",1)]
        public string LocationId { get; set; }

        //[Index("IX_LocationAndProperty", 2)]
        public int PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }

    public class IncidentReport
    {
        [Key] 
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Guid GroupId { get; set; }
        
        public string Comments { get; set; }

        public IncidentType IncidentType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual IncidentReportStatus IncidentReportStatus { get; set; }

        public DateTime? CompletionDate { get; set; }
    }

    public enum IncidentType
    {
        Noise,
        Parking,
        VisualDisturbance,
        Other
    }

    public class IncidentReportCheckin
    {
        [Key]
        public int Id { get; set; }
        public string OfficerId { get; set; }

        [ForeignKey("OfficerId")]
        public virtual ApplicationUser Officer { get; set; }
        public string Comments { get; set; }
        public Guid GroupId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int IncidentReportId { get; set; }

        [ForeignKey("IncidentReportId")]
        public virtual IncidentReport IncidentReport { get; set; }

        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual IncidentReportStatus IncidentReportStatus { get; set; }
    }

    public class CourtesyOfficerCheckin
    {
        [Key]
        public int Id { get; set; }
        public string OfficerId { get; set; }
        public int CourtesyOfficerLocationId { get; set; }

        [ForeignKey("OfficerId")]
        public virtual ApplicationUser Officer { get; set; }

        [ForeignKey("CourtesyOfficerLocationId")]
        public virtual CourtesyOfficerLocation CourtesyOfficerLocation { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Comments { get; set; }

        public Guid GroupId { get; set; }
    }
}