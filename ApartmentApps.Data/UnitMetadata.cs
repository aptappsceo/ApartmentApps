using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    [MetadataType(typeof(UnitMetadata))]
    public partial class Unit
    {
    }

    public partial class UnitMetadata
    {
        [Display(Name = "Building")]
        public Building Building { get; set; }

        [Display(Name = "Tenants")]
        public Tenant Tenants { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Building")]
        public int BuildingId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}
