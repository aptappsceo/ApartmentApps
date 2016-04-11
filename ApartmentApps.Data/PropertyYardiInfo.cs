using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public class PropertyYardiInfo : IPropertyEntity
    {
        [Key, ForeignKey("Property")]
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
        public string Endpoint { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string YardiPropertyId { get; set; }

        [NotMapped]
        int? IPropertyEntity.PropertyId
        {
            get { return PropertyId; }

            set { PropertyId = value ?? 1; }
        }
    }
}