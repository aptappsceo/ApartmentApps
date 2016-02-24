using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AlertView;
using BigTed;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Events;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.Interfaces;

namespace ResidentAppCross.iOS.Views
{

    public class ViewBase : MvxViewController, IEventAware, IDisposableContainer
    {
        protected ViewBase(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }


        private IMvxMessenger _eventAggregator;

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.OnViewModelEvent<TaskStarted>(evt =>
            {
                this.SetTaskRunning(evt.Label);
            });

            this.OnViewModelEvent<TaskComplete>(evt =>
            {
                this.SetTaskComplete(evt.ShouldPrompt, evt.Label, evt.OnPrompted);
            });

            this.OnViewModelEvent<TaskFailed>(evt =>
            {
                this.SetTaskFailed(evt.ShouldPrompt, evt.Label, evt.Reason, evt.OnPrompted);
            });
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            this.DisposeContainer();
        }

        public List<IDisposable> Disposables { get; set; } = new List<IDisposable>();
    }


    public static class ViewExtensions
    {
        public static void SetTaskRunning(this ViewBase view, string label, bool block = true)
    {
            if (block)
            BTProgressHUD.Show(null,()=> {},label,-1f,ProgressHUD.MaskType.Black);
        }

        public static void SetTaskComplete(this ViewBase view, bool prompt, string label = null, Action onPrompted = null) 
        {
            BTProgressHUD.Dismiss();
            if (prompt)
            {
                var alertWithBody = MBAlertView.AlertWithBody(label, "Continue", () => onPrompted?.Invoke());
                alertWithBody.BackgroundAlpha = 0.7f;
                alertWithBody.AddToDisplayQueue();
            }
        }

        public static void SetTaskFailed(this ViewBase view, bool prompt, string label = null, Exception reson = null, Action<Exception> onPrompted = null) 
    {
            BTProgressHUD.Dismiss();
            if (prompt)
            {
                var alertWithBody = MBAlertView.AlertWithBody(label, "Ok", () =>
                {
                    onPrompted?.Invoke(reson);
                });
                alertWithBody.BackgroundAlpha = 0.7f;
                alertWithBody.AddToDisplayQueue();
            }
    }

        public static void OnViewModelEvent<TMessage>(this ViewBase view, Action<TMessage> handler) where TMessage : MvxMessage
        { 
            view.OnEvent<TMessage>(evt =>
            {
                if (evt.Sender == view.ViewModel) handler(evt);
            });

        }

        public static void OnEvent<TMessage>(this ViewBase view, Action<TMessage> handler) where TMessage : MvxMessage 
        {
            view.EventAggregator.Subscribe(handler).DisposeWith(view);
        }


    }

}
