using System.Collections.Generic;
using ApartmentApps.Forms;

namespace ApartmentApps.Api.Modules
{
    public interface IPageTabsProvider
    {
        void PopulateMenuItems(List<ActionLinkModel> menuItems);
    }
}