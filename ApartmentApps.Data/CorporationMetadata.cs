using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    [MetadataType(typeof(CorporationMetadata))]
    public partial class Corporation
    {
    }

    public partial class CorporationMetadata
    {
        [Display(Name = "Properties")]
        public Property Properties { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}
