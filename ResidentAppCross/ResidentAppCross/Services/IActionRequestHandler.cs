using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Interfaces;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Services
{

    public interface IActionRequestHandler
    {
        void Handle(TypedActionRequest request);
    }

    public class ActionRequestHandler : BaseActionRequestHandler, IEventAware
    {
        private ViewModelBase _hack;
        private ILoginManager _loginManager;
        private IMvxMessenger _eventAggregator;

        public ActionRequestHandler(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }


        //Hackish way of getting some of the functionality (ShowViewModel with configurator action)
        public ViewModelBase Hack
        {
            get { return _hack ?? (_hack = Mvx.Resolve<HomeMenuViewModel>()); }
            set { _hack = value; }
        }

        [ForAction(ActionType.View, "courtesy")]
        public void ViewIncident(TypedActionRequest request)
        {
            if (!request.DataId.HasValue) return;
            if (_loginManager.IsLoggedIn)
            {
                Hack.ShowViewModel<IncidentReportStatusViewModel>(vm =>
                {
                    vm.IncidentReportId = request.DataId.Value;
                });
            }
            else
            {
                this.SubscribeOnce<UserLoggedInEvent>(evt =>
                {
                    evt.PreventNavigation = true;
                    Hack.ShowViewModel<IncidentReportStatusViewModel>(vm =>
                    {
                        vm.IncidentReportId = request.DataId.Value;
                    });
                });
            }
        }

        [ForAction(ActionType.View, "maintenance")]
        public void ViewMaintenance(TypedActionRequest request)
        {
            if (!request.DataId.HasValue) return;
            if (_loginManager.IsLoggedIn)
            {
                Hack.ShowViewModel<MaintenanceRequestStatusViewModel>(vm =>
                {
                    vm.MaintenanceRequestId = request.DataId.Value;
                });
            }
            else
            {
                this.SubscribeOnce<UserLoggedInEvent>(evt =>
                {
                    evt.PreventNavigation = true;
                    Hack.ShowViewModel<MaintenanceRequestStatusViewModel>(vm =>
                    {
                        vm.MaintenanceRequestId = request.DataId.Value;
                    });
                });
            }
        }


        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }
    }

    public class BaseActionRequestHandler : IActionRequestHandler
    {
        private Dictionary<ActionRequestHandlerDescriptor, MethodInfo> _handlers;

        private Dictionary<ActionRequestHandlerDescriptor, MethodInfo> Handlers => _handlers ?? (_handlers = LoadHandlers());

        private Dictionary<ActionRequestHandlerDescriptor, MethodInfo> LoadHandlers()
        {
            var dic = new Dictionary<ActionRequestHandlerDescriptor, MethodInfo>();
            foreach (var methodInfo in GetType().GetMethods(BindingFlags.Instance))
            {
                var attr = methodInfo.GetCustomAttribute(typeof (ForAction), true) as ForAction;
                if (attr == null) continue;
                var key = ConvertToDescriptor(attr);
                dic[key] = methodInfo;
            }
            return dic;
        }

        public void Handle(TypedActionRequest request)
        {
            var key = ConvertToDescriptor(request);
            MethodInfo handler;
            if (Handlers.TryGetValue(key, out handler))
            {
                handler.Invoke(this, new object[] { request } );
            }
        }

        private ActionRequestHandlerDescriptor ConvertToDescriptor(TypedActionRequest request)
        {
            return new ActionRequestHandlerDescriptor()
            {
                ActionType = request.ActionType,
                DataType = request.DataType
            };
        }

        private ActionRequestHandlerDescriptor ConvertToDescriptor(ForAction attr)
        {
            return new ActionRequestHandlerDescriptor()
            {
                ActionType = attr.Action,
                DataType = attr.DataType
            };
        }

        internal struct ActionRequestHandlerDescriptor
        {
            public ActionType ActionType { get; set; }
            public string DataType { get; set; }
        }
    }


    public class ForAction : Attribute
    {
        public ForAction(ActionType action, string dataType)
        {
            Action = action;
            DataType = dataType;
        }

        public ActionType Action { get; set; }
        public string DataType { get; set; }
    }

    public class NotificationPayload
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Semantic { get; set; } = "Default"; //App decides about icon based on semantic
        public string Action { get; set; }
        public int? DataId { get; set; }
        public string DataType { get; set; }
    }

    public class ActionRequest
    {
        public string Action { get; set; }
        public int? DataId { get; set; }
        public string DataType { get; set; }
    }

    public class TypedActionRequest
    {
        public string DataType { get; set; }
        public int? DataId { get; set; }
        public ActionType ActionType { get; set; }
    }

    public enum ActionType
    {
        None,
        View
    }

}
