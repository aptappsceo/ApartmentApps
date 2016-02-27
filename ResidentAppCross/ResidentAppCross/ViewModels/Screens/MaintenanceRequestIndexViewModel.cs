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
            Debug.WriteLine("Shit should happen");
            //TODO: Parse and Own
            try
            {
                ShowViewModel<MaintenanceRequestStatusViewModel>(vm =>
                {
                    vm.MaintenanceRequestId = 12;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("shit");
            }
        }
    }
}
