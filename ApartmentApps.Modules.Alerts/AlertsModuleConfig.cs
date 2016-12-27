using ApartmentApps.Api.Modules;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    [Persistant]
    public class AlertsModuleConfig : PropertyModuleConfig
    {
        public string HeaderLogoImageUrl { get; set; } =
            "http://apartmentapps.com/wp-content/uploads/2016/02/ApartmentAppsLogo_Web.png";

        public int DaysBetweenEngagementLetters { get; set; }
    }
}