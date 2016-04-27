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
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Extensions;
using ResidentAppCross.Resources;

namespace ResidentAppCross.ViewModels.Screens
{
    public class IncidentReportIndexViewModel : ViewModelBase
    {
        private IApartmentAppsAPIService _service;
        private ObservableCollection<IncidentIndexBindingModel> _requests;
        private ObservableCollection<IncidentIndexBindingModel> _filteredRequests;
        private ObservableCollection<IncidentIndexFilter> _filters;
        private IncidentIndexFilter _currentFilter;
        private IncidentIndexBindingModel _selectedIncident;

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
                MarkerTitle = null,
                Title = "All",
                FilterExpression = item => true
                ,Icon = SharedResources.Icons.IncidentList
                
            });

            Filters.Add(new IncidentIndexFilter()
            {
                MarkerTitle = "Filtered: Reported",
                Title = "Reported",
                FilterExpression = item => item.StatusId == "Reported"
                ,
                Icon = SharedResources.Icons.QuestionMark

            });

            Filters.Add(new IncidentIndexFilter()
            {
                MarkerTitle = "Filtered: Open",
                Title = "Open",
                FilterExpression = item => item.StatusId == "Open"
                ,
                Icon = SharedResources.Icons.Play

            });

            Filters.Add(new IncidentIndexFilter()
            {
                MarkerTitle = "Filtered: Paused",
                Title = "Paused",
                FilterExpression = item => item.StatusId == "Paused"
                ,
                Icon = SharedResources.Icons.Pause

            });

            Filters.Add(new IncidentIndexFilter()
            {
                MarkerTitle = "Filtered: Complete",

                Title = "Complete",
                FilterExpression = item => item.StatusId == "Complete"
                ,
                Icon = SharedResources.Icons.Ok

            });

        }

        public ObservableCollection<IncidentIndexBindingModel> Incidents
        {
            get { return _requests ?? (_requests = new ObservableCollection<IncidentIndexBindingModel>()); }
            set { _requests = value; }
        }

        public ObservableCollection<IncidentIndexFilter> Filters
        {
            get { return _filters ?? (_filters = new ObservableCollection<IncidentIndexFilter>()); }
            set { _filters = value; }
        }

        public ObservableCollection<IncidentIndexBindingModel> FilteredIncidents
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

        public ICommand UpdateIncidentsCommand
        {
            get
            {

//                return new MvxCommand(async () =>
//                {
//                    this.Publish(new IncidentsIndexUpdateStarted(this));
//                    var requests = await _service.Courtesy.ListRequestsAsync();
//                    Incidents.Clear();
//                    Incidents.AddRange(requests);
//                    UpdateFilters();
//                    this.Publish(new IncidentsIndexUpdateFinished(this));
//
//                });


                return this.TaskCommand(async context =>
                {
                    this.Publish(new IncidentsIndexUpdateStarted(this));
                    var requests = await _service.Courtesy.ListRequestsAsync();
                    Incidents.Clear();
                    Incidents.AddRange(requests);
                    UpdateFilters();
                    this.Publish(new IncidentsIndexUpdateFinished(this));
                }).OnStart("Fetching Incidents...");
            }
        }

        public ICommand OpenIncidentReportFormCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<IncidentReportFormViewModel>();
                });
            }
        }

        public IncidentIndexBindingModel SelectedIncident
        {
            get { return _selectedIncident; }
            set { SetProperty(ref _selectedIncident, value); }
        }

        public ICommand OpenSelectedIncidentCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if (SelectedIncident == null) return;
                    int id = SelectedIncident.Id ?? -1;
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
            FilteredIncidents.Clear();
            if (CurrentFilter != null)
                FilteredIncidents.AddRange(Incidents.Where(item => CurrentFilter.FilterExpression(item)));

            this.Publish(new IncidentsIndexFiltersUpdatedEvent(this));
        }
    }

    public class IncidentIndexFilter
    {
        public string Title { get; set; }
        public string MarkerTitle { get; set; }
        public Func<IncidentIndexBindingModel, bool> FilterExpression { get; set; }
        public SharedResources.Icons Icon { get; set; }
    }

    public class IncidentsIndexFiltersUpdatedEvent : MvxMessage
    {
        public IncidentsIndexFiltersUpdatedEvent(object sender) : base(sender)
        {
        }
    }

    public class IncidentsIndexUpdateStarted : MvxMessage
    {
        public IncidentsIndexUpdateStarted(object sender) : base(sender)
        {
        }
    }

    public class IncidentsIndexUpdateFinished : MvxMessage
    {
        public IncidentsIndexUpdateFinished(object sender) : base(sender)
        {
        }
    }

}
