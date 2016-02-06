using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.API.Service.Models
{
    public class Corporation
    {
   
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}