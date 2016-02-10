using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    public class PropertyAddonType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}