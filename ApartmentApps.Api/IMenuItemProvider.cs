using System.Collections.Generic;

namespace ApartmentApps.Api.Modules
{
    public interface IMenuItemProvider
    {
        void PopulateMenuItems(List<MenuItemViewModel> menuItems);
    }
}