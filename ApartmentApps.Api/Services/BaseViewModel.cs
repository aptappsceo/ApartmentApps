using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Forms;

namespace ApartmentApps.Portal.Controllers
{
    public class BaseViewModel
    {
        [DataType("Hidden")]
        public string Id { get; set; }

        public List<ActionLinkModel> ActionLinks { get; set; } = new List<ActionLinkModel>();
    }

    public class PageViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<ActionLinkModel> ActionLinks { get; set; } = new List<ActionLinkModel>();
        public Type ViewModelType => ViewModelObject.GetType();
        public object ViewModelObject { get; set; }

        public string View { get; set; }
    }

    public class PageSectionViewModel
    {

        /// <summary>
        /// Similar to col-md-12 -- 12 being an entire row
        /// </summary>
        public int ColumnSpan { get; set; }

        public Type ViewModelType => ViewModel.GetType();
        public object ViewModel { get; set; }

        public string View { get; set; }
    }
}