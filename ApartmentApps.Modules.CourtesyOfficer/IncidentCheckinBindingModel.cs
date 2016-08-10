using System;
using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;

namespace ApartmentApps.Api.BindingModels
{
    public class IncidentCheckinBindingModel
    {
        public string StatusId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public List<ImageReference> Photos { get; set; }

        public UserBindingModel Officer { get; set; }
    }
}