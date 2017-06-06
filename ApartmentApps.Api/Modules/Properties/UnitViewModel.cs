using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{
    public class UnitViewModel :BaseViewModel
    {
        public string Name { get; set; }
        public string BuildingName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int BuildingId { get; set; }
        public string SearchAlias { get; set; }

        [AutoformIgnore]
        public string Title { get; set; }
    }
}