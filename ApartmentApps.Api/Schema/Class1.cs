using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Api.Schema
{
    public class WidgetAttribute : Attribute
    {
        public WidgetAttribute(string widgetName)
        {
            WidgetName = widgetName;
        }

        public string WidgetName { get; set; }
    }

    public class RemoteSelectAttribute : Attribute
    {
        public Type SelectType { get; set; }
        public string Filter { get; set; }
    }
}
