using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Extensions;

namespace ResidentAppCross.ViewModels
{
    public class MaintenanceRequestTypeSelectionViewModel : MvxViewModel
    {

        public static Action<LookupPairModel> OnSelect { get; set; }
        public static List<LookupPairModel>   Options { get; set; }

        public static void Setup(List<LookupPairModel> options, Action<LookupPairModel> onSelect)
        {
            Options = options;
            OnSelect = onSelect;
        }

        private ObservableCollection<LookupPairModel> _types = new ObservableCollection<LookupPairModel>();

        public override void Start()
        {
            base.Start();
            Types.Clear();
            Types.AddRange(Options);
        }

        public void SelectRequestType(LookupPairModel type)
        {
            Close(this);
            OnSelect(type);
        }

        public ObservableCollection<LookupPairModel> Types
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
