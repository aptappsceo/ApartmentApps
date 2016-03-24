using System;
using System.Collections.Generic;
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
    public class MaintenanceRequestIndexViewModel : ViewModelBase
    {
        private IApartmentAppsAPIService _service;
        private ObservableCollection<MaintenanceIndexBindingModel> _requests;
        private ObservableCollection<MaintenanceIndexBindingModel> _filteredRequests;
        private ObservableCollection<RequestsIndexFilter> _filters;
        private RequestsIndexFilter _currentFilter;
        private MaintenanceIndexBindingModel _selectedRequest;

        public MaintenanceRequestIndexViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }



        public override void Start()
        {
            base.Start();
            var all = new RequestsIndexFilter()
            {
                Title = "All",
                FilterExpression = item => true
            };
            Filters.Add(all);

            CurrentFilter = all;


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Open",
                FilterExpression = item => item.StatusId == "Submitted"
            });


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Scheduled",
                FilterExpression = item => item.StatusId == "Scheduled"
            });


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Started",
                FilterExpression = item => item.StatusId == "Started"
            });


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Paused",
                FilterExpression = item => item.StatusId == "Paused"
            });


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Complete",
                FilterExpression = item => item.StatusId == "Complete"
            });

        }



        public ObservableCollection<MaintenanceIndexBindingModel> Requests
        {
            get { return _requests ?? (_requests = new ObservableCollection<MaintenanceIndexBindingModel>()); }
            set { _requests = value; }
        }

        public ObservableCollection<RequestsIndexFilter> Filters
        {
            get { return _filters ?? (_filters = new ObservableCollection<RequestsIndexFilter>()); }
            set { _filters = value; }
        }

        public ObservableCollection<MaintenanceIndexBindingModel> FilteredRequests
        {
            get { return _filteredRequests ?? (_filteredRequests = new ObservableCollection<MaintenanceIndexBindingModel>()); }
            set { _filteredRequests = value; }
        }

        public RequestsIndexFilter CurrentFilter
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
                    var requests = await _service.Maitenance.ListRequestsAsync();
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
                    ShowViewModel<MaintenanceRequestFormViewModel>();
                });
            }
        }

        public MaintenanceIndexBindingModel SelectedRequest
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
                    ShowViewModel<MaintenanceRequestStatusViewModel>(vm =>
                    {
                        vm.MaintenanceRequestId = id;
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

    public class RequestsIndexFilter
    {
        public string Title { get; set; }
        public Func<MaintenanceIndexBindingModel, bool> FilterExpression { get; set; }
    }

}
