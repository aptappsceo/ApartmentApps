﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public partial class Building : PropertyEntity
    {
        [Searchable]
        public string Name { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
        public int RentAmount { get; set; } = 0;
    }
}