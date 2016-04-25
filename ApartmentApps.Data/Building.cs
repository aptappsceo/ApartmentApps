using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public partial class Building : PropertyEntity
    {
  
        public string Name { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}