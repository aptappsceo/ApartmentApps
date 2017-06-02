using System;
using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;

namespace ApartmentApps.Api.BindingModels
{
    public class CourtesyCheckinBindingModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Label { get; set; }
        public List<string> AcceptableCheckinCodes { get; set; }
        public int Id { get; set; }
        public bool Complete { get; set; }
        public DateTime? Date { get; set; }
        public UserBindingModel Officer { get; set; }
    }
}