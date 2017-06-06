using ApartmentApps.Data;

namespace ApartmentApps.Portal.Controllers
{
    public class UnitSearchViewModel
    {
        public FilterViewModel Name { get; set; }

        [FilterPath("Building.Name")]
        public FilterViewModel BuildingName { get; set; }

    }
}