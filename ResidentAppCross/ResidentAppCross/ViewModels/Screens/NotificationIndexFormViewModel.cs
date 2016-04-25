using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Commands;
using ResidentAppCross.Extensions;
using ResidentAppCross.Resources;

namespace ResidentAppCross.ViewModels.Screens
{
    public class NotificationIndexFormViewModel  : ViewModelBase
    {
        private NotificationStatusFilter _currentNotificationStatusFilter;
        private ObservableCollection<NotificationStatusFilter> _notificationStatusFilters;
        private ObservableCollection<AlertBindingModel> _filteredNotifications;
        private AlertBindingModel _selectedNotification;
        private ObservableCollection<AlertBindingModel> _notifications;
        private IApartmentAppsAPIService _service;

        public NotificationIndexFormViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public AlertBindingModel SelectedNotification
        {
            get { return _selectedNotification; }
            set { SetProperty(ref _selectedNotification,value); }
        }

        public ObservableCollection<AlertBindingModel> FilteredNotifications
        {
            get { return _filteredNotifications ?? (FilteredNotifications = new ObservableCollection<AlertBindingModel>()); }
            set { SetProperty(ref _filteredNotifications, value); }
        }

        public ObservableCollection<AlertBindingModel> Notifications
        {
            get { return _notifications ?? (Notifications = new ObservableCollection<AlertBindingModel>()); }
            set { SetProperty(ref _notifications, value); }
        }

        public ObservableCollection<NotificationStatusFilter> NotificationStatusFilters
        {
            get { return _notificationStatusFilters ?? (NotificationStatusFilters = new ObservableCollection<NotificationStatusFilter>()); }
            set { SetProperty(ref _notificationStatusFilters,value); }
        }

        public NotificationStatusFilter CurrentNotificationStatusFilter
        {
            get { return _currentNotificationStatusFilter; }
            set
            {
                SetProperty(ref _currentNotificationStatusFilter,value);
                UpdateFilters();
            }
        }

        public ICommand UpdateNotificationsCommand => new MvxCommand(async () =>
        {
            var task = await _service.Alerts.GetWithOperationResponseAsync();
            Notifications.Clear();
            Notifications.AddRange(task.Body);
            UpdateFilters();
        });

        public ICommand OpenSelectedNotificationDetailsCommand => new MvxCommand(() =>
        {
            if (SelectedNotification?.RelatedId == null) return;


            var alertId = SelectedNotification?.Id;
            if (alertId.HasValue)
                Task.Run(()=> _service.Alerts.PostWithOperationResponseAsync(alertId.Value));

            if (SelectedNotification.Type == "Maintenance")
            {
                ShowViewModel<MaintenanceRequestStatusViewModel>(vm =>
                {
                    vm.MaintenanceRequestId = SelectedNotification.RelatedId.Value;
                });
            }
            else
            {
                ShowViewModel<IncidentReportStatusViewModel>(vm =>
                {
                    vm.IncidentReportId = SelectedNotification.RelatedId.Value;
                });
            }
            //ShowViewModel<NotificationDetailsFormViewModel>();
        });


        public override void Start()
        {
            base.Start();
            
            NotificationStatusFilters.Clear();

            var defaultStatusFilter = new NotificationStatusFilter()
            {
                Title = "Unread",
                FilterExpression = item => !item.HasRead.HasValue || !item.HasRead.Value
            };

            NotificationStatusFilters.Add(defaultStatusFilter);
          
            NotificationStatusFilters.Add(new NotificationStatusFilter()
            {
                Title = "All",
                FilterExpression = item => true
            });

            CurrentNotificationStatusFilter = defaultStatusFilter;

            UpdateNotificationsCommand.Execute(null);
        }

        private void UpdateFilters()
        {
            FilteredNotifications.Clear();
            FilteredNotifications.AddRange(Notifications.Where(item => (CurrentNotificationStatusFilter?.FilterExpression(item) ?? true)));
            this.Publish(new NotificationFiltersUpdatedEvent(this));
        }

    }


    public class NotificationFiltersUpdatedEvent : MvxMessage
    {
        public NotificationFiltersUpdatedEvent(object sender) : base(sender)
        {
        }
    }

    public class NotificationStatusFilter
    {
        public string Title { get; set; }
        public Func<AlertBindingModel, bool> FilterExpression { get; set; } 
    }


}
