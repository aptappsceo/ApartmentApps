using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Data
{
    public class LookupBindingModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string TextPrimary { get; set; }
        public string TextSecondary { get; set; }
        public string ImageUrl { get; set; }
        public bool Selected { get; set; }
    }
}
