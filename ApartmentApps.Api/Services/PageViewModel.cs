using System;
using System.Collections.Generic;
using ApartmentApps.Forms;

namespace ApartmentApps.Portal.Controllers
{
    public class PageViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<ActionLinkModel> ActionLinks { get; set; } = new List<ActionLinkModel>();
        public Type ViewModelType => ViewModelObject.GetType();
        public object ViewModelObject { get; set; }

        public string View { get; set; }
    }
}