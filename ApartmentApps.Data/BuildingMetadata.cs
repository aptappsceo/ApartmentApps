using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    [MetadataType(typeof(BuildingMetadata))]
    public partial class Building
    {
    }

    public partial class BuildingMetadata
    {
        [Display(Name = "Property")]
        public Property Property { get; set; }

        [Display(Name = "Units")]
        public Unit Units { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Property")]
        public int PropertyId { get; set; }

    }
}
