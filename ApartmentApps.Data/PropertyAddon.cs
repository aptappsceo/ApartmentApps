using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public class PropertyAddon
    {
        [Key]
        public int Id { get; set; }

        public int PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }

        public int PropertyIntegrationTypeId { get; set; }

        [ForeignKey("PropertyIntegrationTypeId")]
        public PropertyAddonType AddonType
        {
            get;
            set;
        }
    }
}