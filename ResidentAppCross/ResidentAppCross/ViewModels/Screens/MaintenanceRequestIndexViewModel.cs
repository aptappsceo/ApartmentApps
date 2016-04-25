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
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Extensions;
using ResidentAppCross.Resources;

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
                FilterExpression = item => true,
                Icon = SharedResources.Icons.MaintenanceList
            };
            Filters.Add(all);


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Open",
                FilterExpression = item => item.StatusId == "Submitted",
                Icon = SharedResources.Icons.QuestionMark
            });


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Scheduled",
                FilterExpression = item => item.StatusId == "Scheduled",
                Icon = SharedResources.Icons.Calendar
            });


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Started",
                FilterExpression = item => item.StatusId == "Started",
                Icon = SharedResources.Icons.Play
            });


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Paused",
                FilterExpression = item => item.StatusId == "Paused",
                Icon = SharedResources.Icons.Pause
            });


            Filters.Add(new RequestsIndexFilter()
            {
                Title = "Complete",
                FilterExpression = item => item.StatusId == "Complete",
                Icon = SharedResources.Icons.Ok
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

        public MaintenanceIndexBindingModel SelectedRequest
        {
            get { return _selectedRequest; }
            set { SetProperty(ref _selectedRequest, value); }
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
//                return new MvxCommand(async () =>
//                {
//                    this.Publish(new RequestsIndexUpdateStarted(this));
//                    var requests = await _service.Maitenance.ListRequestsAsync();
//                    Requests.Clear();
//                    Requests.AddRange(requests);
//                    UpdateFilters();
//                    this.Publish(new RequestsIndexUpdateFinished(this));
//                });

              return this.TaskCommand(async context =>
                                {
                
                this.Publish(new RequestsIndexUpdateStarted(this));
                var requests = await _service.Maitenance.ListRequestsAsync();
                Requests.Clear();
                Requests.AddRange(requests);
                UpdateFilters();
                this.Publish(new RequestsIndexUpdateFinished(this));
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
            if(CurrentFilter != null)
            FilteredRequests.AddRange(Requests.Where(item => CurrentFilter.FilterExpression(item)));

            this.Publish(new RequestsIndexFiltersUpdatedEvent(this));
        }
    }

    public class RequestsIndexFilter
    {
        public string Title { get; set; }
        public Func<MaintenanceIndexBindingModel, bool> FilterExpression { get; set; }
        public SharedResources.Icons Icon { get; set; }
    }


    public class RequestsIndexFiltersUpdatedEvent : MvxMessage
    {
        public RequestsIndexFiltersUpdatedEvent(object sender) : base(sender)
        {

        }
    }

    public class RequestsIndexUpdateStarted : MvxMessage
    {
        public RequestsIndexUpdateStarted(object sender) : base(sender)
        {
        }
    }

    public class RequestsIndexUpdateFinished : MvxMessage
    {
        public RequestsIndexUpdateFinished(object sender) : base(sender)
        {
        }
    }

}
