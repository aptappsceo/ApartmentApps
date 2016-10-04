using System.Collections.Generic;

namespace ApartmentApps.Api.Modules
{
    public class MenuItemViewModel
    {
        public decimal Index { get; set; }
        private List<MenuItemViewModel> _children;

        public List<MenuItemViewModel> Children
        {
            get { return _children ?? (_children = new List<MenuItemViewModel>()); }
            set { _children = value; }
        }

        public bool HasChildren { get { return _children != null && _children.Count > 0; } }

        public string Label { get; set; }
        public string Icon { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public object RouteParams { get; set; }
        public MenuItemViewModel(string label, string icon,  decimal index = 0)
        {
            Label = label;
            Icon = icon;
            Index = index;
        }


        public MenuItemViewModel(string label, string icon, string action, string controller, object routeParams, decimal index = 0)
        {
            Label = label;
            Icon = icon;
            Action = action;
            Controller = controller;
            RouteParams = routeParams;
            Index = index;
        }

        public MenuItemViewModel(string label, string icon, string action, string controller, decimal index = 0)
        {
            Label = label;
            Icon = icon;
            Action = action;
            Controller = controller;
            Index = index;
        }
    }
}