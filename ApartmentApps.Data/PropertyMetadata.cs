using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{

    public partial class PropertyMetadata
    {
        [Display(Name = "Corporation")]
        public Corporation Corporation { get; set; }

        [Display(Name = "PropertyAddons")]
        public PropertyAddon PropertyAddons { get; set; }

        [Display(Name = "Tenants")]
        public Tenant Tenants { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "CorporationId")]
        public int CorporationId { get; set; }

    }
}
