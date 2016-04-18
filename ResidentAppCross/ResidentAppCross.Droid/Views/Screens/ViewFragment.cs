using System;
using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Events;
using ResidentAppCross.Interfaces;
using ResidentAppCross.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Platform.Core;

namespace ResidentAppCross.Droid.Views
{
    public class ViewFragment<T> : ViewFragment where T : class, IMvxViewModel
    {
        public T ViewModel
        {
            get { return (T) base.ViewModel; }
            set { this.ViewModel = value; }
        }
    }

    public class ViewFragment : MvxFragment, IDisposableContainer
    {

        public ViewFragment()
        {
        }

        public virtual Fragment HeaderFragment { get; set; }


        private IMvxMessenger _eventAggregator;

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }

        public List<IDisposable> Disposables { get; set; } = new List<IDisposable>();

        private ActionBar _toolbar;
        private AppCompatActivity _mainActivity;

        public AppCompatActivity MainActivity
        {
            get { return _mainActivity ?? (_mainActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity as AppCompatActivity); }
            set { _mainActivity = value; }
        }

        public ActionBar Toolbar
        {
            get { return _toolbar ?? (_toolbar = MainActivity.SupportActionBar); }
            set { _toolbar = value; }
        }

        public virtual int LayoutId => GetType().Name.ToLowerUnderscored().AsLayoutId();

        public override void OnStart()
        {
            base.OnStart();
            this.OnViewModelEvent<TaskStarted>(evt => this.SetTaskRunning(evt.Label));
            this.OnViewModelEvent<TaskComplete>(evt => this.SetTaskComplete(evt.ShouldPrompt, evt.Label, evt.OnPrompted));
            this.OnViewModelEvent<TaskFailed>(evt => this.SetTaskFailed(evt.ShouldPrompt, evt.Label, evt.Reason, evt.OnPrompted));
            this.OnViewModelEvent<TaskProgressUpdated>(evt => this.SetTaskProgress(evt.ShouldPrompt, evt.Label));
        }

        public override void OnStop()
        {
            base.OnStop();
            this.DisposeContainer();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var viewFromLayout = CreateViewFromLayout(inflater, container, savedInstanceState);
            Layout = viewFromLayout as ViewGroup;
            return viewFromLayout;
        }

        public ViewGroup Layout { get; set; }

        public virtual View CreateViewFromLayout(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return this.BindingInflate(LayoutId, null);
        }

        public override void OnViewModelSet()
        {
            base.OnViewModelSet();
            if (ViewModel != null && Layout != null) Bind();
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            Layout?.LocateOutlets(this);
            if (ViewModel != null && Layout != null) Bind();
        }

        public bool IsBound { get; set; }

        public virtual void Bind()
        {
            
        }

    }

    public static class ViewFragmentExtensions
    {
        private static IMvxMainThreadDispatcher _dispatcher;

        public static IMvxMainThreadDispatcher Dispatcher
        {
            get { return _dispatcher ?? (_dispatcher = Mvx.Resolve<IMvxMainThreadDispatcher>()); }
            set { _dispatcher = value; }
        }

        public static void SetTaskRunning(this ViewFragment view, string label, bool block = true)
        {
            Toast.MakeText(view.MainActivity, label, ToastLength.Long);
        }

        public static void SetTaskProgress(this ViewFragment view, bool prompt, string label)
        {
            Toast.MakeText(view.MainActivity, label, ToastLength.Long);
        }

        public static void SetTaskComplete(this ViewFragment view, bool prompt, string label = null, Action onPrompted = null)
        {
            Toast.MakeText(view.MainActivity, label, ToastLength.Long);
            onPrompted?.Invoke();
        }

        public static void SetTaskFailed(this ViewFragment view, bool prompt, string label = null, Exception reason = null, Action<Exception> onPrompted = null)
        {
            Toast.MakeText(view.MainActivity, label, ToastLength.Long);
            onPrompted?.Invoke(reason);
        }


        public static void OnViewModelEvent<TMessage>(this ViewFragment view, Action<TMessage> handler) where TMessage : MvxMessage
        {
            view.OnEvent<TMessage>(evt =>
            {
                if (evt.Sender == view.ViewModel)
                {
                    Dispatcher.RequestMainThreadAction(() =>
                    {
                        handler(evt);
                    });
                }
            });
        }

        public static void OnEvent<TMessage>(this ViewFragment view, Action<TMessage> handler) where TMessage : MvxMessage
        {
            view.EventAggregator.Subscribe(handler).DisposeWith(view);
        }


    }

}