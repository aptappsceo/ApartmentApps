using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAppCross.ViewModels.Screens
{
    public class MaintenanceRequestIndexViewModel : ViewModelBase
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        //Will make it a command later. 
        public void RequestAction(string url)
        {
            //TODO: Parse ID from URL
            ShowViewModel<MaintenanceRequestStatusViewModel>(vm =>
            {
                vm.MaintenanceRequestId = 12;
            });
        }
    }
}
