using System.Collections.Generic;

namespace ApartmentApps.Api.Modules
{
    public interface IDashboardComponentProvider
    {
        void PopulateComponents(DashboardArea areaName, List<ComponentViewModel> dashboardComponents);
    }
}