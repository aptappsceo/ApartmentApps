using System;
using System.Collections.Generic;
using Android.OS;
using AndroidHUD;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Events;
using ResidentAppCross.Interfaces;

namespace ResidentAppCross.Droid.Views
{

   

    public abstract class ViewBase : MvxActivity, IDisposableContainer
    {
        private IMvxMessenger _eventAggregator;

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
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

        protected override void OnDestroy()
        {
            base.OnDestroy();
            this.DisposeContainer();
        }

        public List<IDisposable> Disposables { get; set; } = new List<IDisposable>();
    }


    public abstract class ViewBase<T> : MvxActivity<T> where T : class, IMvxViewModel
    {
        
    }


    public static class ViewExtensions
    {
        public static void SetTaskRunning(this ViewBase view, string label, bool block = true)
        {
            if(block) AndHUD.Shared.Show(view, label, -1, MaskType.Black, centered: true);
        }

        public static void SetTaskComplete(this ViewBase view,bool prompt, string label = null, Action onPrompted = null)
        {
            if (!prompt)
            {
                AndHUD.Shared.Dismiss(view);
                return;
            }
            AndHUD.Shared.ShowSuccess(view, label,MaskType.Black,clickCallback: () =>
            {
                AndHUD.Shared.Dismiss(view);
                onPrompted?.Invoke();
            });
        }

        public static void SetTaskFailed(this ViewBase view, bool prompt, string label = null,Exception reason = null,  Action<Exception> onPrompted = null)
        {
            if (!prompt)
            {
                AndHUD.Shared.Dismiss(view);
                return;
            }
            AndHUD.Shared.ShowError(view, label, MaskType.Black, clickCallback: () =>
            {
                AndHUD.Shared.Dismiss(view);
                onPrompted?.Invoke(reason);
            });
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