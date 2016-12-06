using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    public class MaitenanceRequestType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}