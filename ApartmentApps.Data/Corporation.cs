using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    public partial class Corporation
    {
   
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Corporation")]
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}