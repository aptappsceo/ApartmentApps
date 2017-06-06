using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Forms;

namespace ApartmentApps.Api.Modules
{
    public class DashboardGridViewModel : ComponentViewModel
    {
        public DashboardGridViewModel(Type type, IEnumerable<object> items)
        {
            GridModel = new DefaultFormProvider().CreateGridFor(type);

            GridModel.ObjectItems = items.Cast<object>();
        }
        public GridModel GridModel { get; set; }
    }
}