using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Extensions;

namespace ResidentAppCross.ViewModels.Screens
{
    public class IncidentReportIndexViewModel : ViewModelBase
    {
        private IApartmentAppsAPIService _service;
        private ObservableCollection<IncidentIndexBindingModel> _requests;
        private ObservableCollection<IncidentIndexBindingModel> _filteredRequests;
        private ObservableCollection<IncidentIndexFilter> _filters;
        private IncidentIndexFilter _currentFilter;
        private IncidentIndexBindingModel _selectedRequest;

        public IncidentReportIndexViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }



        public override void Start()
        {
            base.Start();




            Filters.Clear();
            Filters.Add(new IncidentIndexFilter()
            {
                Title = "Reported",
                FilterExpression = item => item.StatusId == "Reported"
            });
            CurrentFilter = Filters[0];
            Filters.Add(new IncidentIndexFilter()
            {
                Title = "Open",
                FilterExpression = item => item.StatusId == "Open"
            });

            Filters.Add(new IncidentIndexFilter()
            {
                Title = "Paused",
                FilterExpression = item => item.StatusId == "Paused"
            });

            Filters.Add(new IncidentIndexFilter()
            {
                Title = "Complete",
                FilterExpression = item => item.StatusId == "Complete"
            });

        }



        public ObservableCollection<IncidentIndexBindingModel> Requests
        {
            get { return _requests ?? (_requests = new ObservableCollection<IncidentIndexBindingModel>()); }
            set { _requests = value; }
        }

        public ObservableCollection<IncidentIndexFilter> Filters
        {
            get { return _filters ?? (_filters = new ObservableCollection<IncidentIndexFilter>()); }
            set { _filters = value; }
        }

        public ObservableCollection<IncidentIndexBindingModel> FilteredRequests
        {
            get { return _filteredRequests ?? (_filteredRequests = new ObservableCollection<IncidentIndexBindingModel>()); }
            set { _filteredRequests = value; }
        }

        public IncidentIndexFilter CurrentFilter
        {
            get { return _currentFilter; }
            set
            {
                SetProperty(ref _currentFilter, value);
                UpdateFilters();
            }
        }

        public ICommand UpdateRequestsCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    var requests = await _service.Courtesy.ListRequestsAsync();
                    Requests.Clear();
                    Requests.AddRange(requests);
                    UpdateFilters();

                }).OnStart("Fetching Requests...");
            }
        }

        public ICommand OpenMaintenanceRequestFormCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<IncidentReportFormViewModel>();
                });
            }
        }

        public IncidentIndexBindingModel SelectedRequest
        {
            get { return _selectedRequest; }
            set { SetProperty(ref _selectedRequest, value); }
        }

        public ICommand OpenSelectedRequestCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if (SelectedRequest == null) return;
                    int id = SelectedRequest.Id ?? -1;
                    if (id == -1) return;
                    ShowViewModel<IncidentReportStatusViewModel>(vm =>
                    {
                        vm.IncidentReportId = id;
                    });
                });
            }
        }

        private void UpdateFilters()
        {
            FilteredRequests.Clear();
            FilteredRequests.AddRange(Requests.Where(item => CurrentFilter.FilterExpression(item)));
        }
    }

    public class IncidentIndexFilter
    {
        public string Title { get; set; }
        public Func<IncidentIndexBindingModel, bool> FilterExpression { get; set; }
    }

}
