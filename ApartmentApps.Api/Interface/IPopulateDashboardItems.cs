using System.Collections.Generic;

namespace ApartmentApps.Api.Modules
{
    public interface IPopulateDashboardItems
    {
        void PopulateDashboardItems(List<MenuItemViewModel> menuItems);
    }
}