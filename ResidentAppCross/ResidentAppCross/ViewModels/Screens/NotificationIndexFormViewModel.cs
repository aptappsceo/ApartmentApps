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
        private ObservableCollection<NotificationBindingModelMock> _filteredNotifications;
        private NotificationBindingModelMock _selectedNotification;
        private ObservableCollection<NotificationBindingModelMock> _notifications;
        private IApartmentAppsAPIService _service;

        public NotificationIndexFormViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public NotificationBindingModelMock SelectedNotification
        {
            get { return _selectedNotification; }
            set { SetProperty(ref _selectedNotification,value); }
        }

        public ObservableCollection<NotificationBindingModelMock> FilteredNotifications
        {
            get { return _filteredNotifications ?? (FilteredNotifications = new ObservableCollection<NotificationBindingModelMock>()); }
            set { SetProperty(ref _filteredNotifications, value); }
        }

        public ObservableCollection<NotificationBindingModelMock> Notifications
        {
            get { return _notifications ?? (Notifications = new ObservableCollection<NotificationBindingModelMock>()); }
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


        public ICommand UpdateNotificationsCommand => new MvxCommand(() =>
        {
        });

        public ICommand OpenSelectedNotificationDetailsCommand => new MvxCommand(() =>
        {
            ShowViewModel<NotificationDetailsFormViewModel>();
        });


        public override void Start()
        {
            base.Start();

            //TODO: Replace MOCK

            var ids = 0;

            for (int i = 0; i < 15; i++)
            {
                Notifications.Add(new NotificationBindingModelMock()
                {
                    Id = ids++,
                    Type =  NotificationTypeMock.Maintenance,
                    Title = "Lorem Upsum",
                    Message = "I'm da king of congo-bongo, obey or dance",
                    Unread = i <= 5
                });    
            }

            for (int i = 0; i < 15; i++)
            {
                Notifications.Add(new NotificationBindingModelMock()
                {
                    Type = NotificationTypeMock.Courtesy,
                    Id = ids++,
                    Title = "Lorem Upsum",
                    Message = "I'm da king of congo-bongo, obey or dance",
                    Unread = i <= 5
                });    
            }

            NotificationStatusFilters.Clear();

            var defaultStatusFilter = new NotificationStatusFilter()
            {
                Title = "Unread",
                FilterExpression = item => item.Unread
            };

            NotificationStatusFilters.Add(defaultStatusFilter);
          
            NotificationStatusFilters.Add(new NotificationStatusFilter()
            {
                Title = "All",
                FilterExpression = item => true
            });

            CurrentNotificationStatusFilter = defaultStatusFilter;


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
        public Func<NotificationBindingModelMock,bool> FilterExpression { get; set; } 
    }

    public class NotificationBindingModelMock
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationTypeMock Type { get; set; }
        public bool Unread { get; set; }
    }

    public enum NotificationTypeMock
    {
        Maintenance,
        Courtesy
    }




}
