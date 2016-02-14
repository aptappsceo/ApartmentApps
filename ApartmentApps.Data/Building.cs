using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public partial class Building
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}