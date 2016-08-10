using System.Collections.Generic;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{
    public class CourtesyCheckinViewModel : BaseViewModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Label { get; set; }
        public List<string> AcceptableCheckinCodes { get; set; }

        public bool Complete { get; set; }
    }
}