using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public class PropertyYardiInfo : PropertyEntity
    {
 
        public string Endpoint { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string YardiPropertyId { get; set; }

      
    }
}