using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Client.Models;
using Cirrious.MvvmCross.ViewModels;
using ResidentAppCross.Extensions;

namespace ResidentAppCross.ViewModels
{
    public class MaintenanceRequestTypeSelectionViewModel : MvxViewModel
    {

        public static Action<MaitenanceRequestType> OnSelect { get; set; }
        public static List<MaitenanceRequestType>   Options { get; set; }

        public static void Setup(List<MaitenanceRequestType> options, Action<MaitenanceRequestType> onSelect)
        {
            Options = options;
            OnSelect = onSelect;
        }

        private ObservableCollection<MaintenanceRequestTypeViewModel> _types = new ObservableCollection<MaintenanceRequestTypeViewModel>();

        public override void Start()
        {
            base.Start();
            Types.Clear();
            Types.AddRange(Options.Select(_=>new MaintenanceRequestTypeViewModel(_)));
        }

        public void SelectRequestType(MaintenanceRequestTypeViewModel type)
        {
            Debug.WriteLine("Selected: {0}", type.Title);
        }

        public ObservableCollection<MaintenanceRequestTypeViewModel> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                RaisePropertyChanged();
            }
        }

    }

}
