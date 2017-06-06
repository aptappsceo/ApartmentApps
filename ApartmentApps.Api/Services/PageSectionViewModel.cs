using System;

namespace ApartmentApps.Portal.Controllers
{
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