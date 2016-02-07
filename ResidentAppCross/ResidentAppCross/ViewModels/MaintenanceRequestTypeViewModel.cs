using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client.Models;
using ResidentAppCross.Commands;

namespace ResidentAppCross.ViewModels
{
    public class MaintenanceRequestTypeViewModel
    {
        private readonly MaitenanceRequestType _model;

        public MaintenanceRequestTypeViewModel(MaitenanceRequestType model)
        {
            _model = model;
        }

        public string Title => _model.Name;

        public int Id => _model.Id ?? -1;

    }
}
