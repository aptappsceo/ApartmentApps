using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
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

    public class HeaderSection : FragmentSection
    {
        [Outlet]
        public TextView TitleLabel { get; set; }

        [Outlet]
        public TextView SubtitleLabel { get; set; }

        [Outlet]
        public ImageView IconView { get; set; }
    }

    public class TicketStatusSection : FragmentSection
    {
        [Outlet]
        public TextView TypeLabel { get; set; }

        [Outlet]
        public TextView StatusLabel { get; set; }

        [Outlet]
        public TextView LastRevisionLabel { get; set; }
    }


    public class TextSection : FragmentSection
    {
        [Outlet]
        public TextView HeaderLabel { get; set; }

        [Outlet]
        public EditText TextInput { get; set; }
    }



    public class FragmentSection
    {

        public ViewGroup ParentLayout { get; set; }

        public Context Context { get; set; }

        public virtual int ContainerId => Resource.Id.SectionContainerDefault;

        public virtual View View { get; set; }

        public virtual void Inflate()
        {
            View = LayoutInflater.From(Context).Inflate(GetType().Name.ToLowerUnderscored().AsLayoutId(), ParentLayout, false);
            View.LocateOutlets(this);
        }

    }

    public class SectionViewFragment<T> : ViewFragment<T> where T : class, IMvxViewModel
    {
        private List<FragmentSection> _content;
        private ViewGroup _sectionContainer;

        protected T CreateSection<T>() where T : FragmentSection
        {
            var instance = (T)Activator.CreateInstance(typeof(T));
            instance.Context = Context;
            instance.ParentLayout = (ViewGroup) Layout.FindViewById(instance.ContainerId);
            instance.Inflate();
            return instance;
        }

        public ViewGroup SectionContainer
        {
            get
            {
                if (_sectionContainer == null)
                {
                    _sectionContainer = (ViewGroup) Layout.FindViewById(Resource.Id.SectionContainerDefault);
                }
                return _sectionContainer;
            }
            set { _sectionContainer = value; }
        }

        public virtual void RefreshContent()
        {
            Content.Clear();
            GetContent(Content);
            SectionContainer.RemoveAllViews();
            LayoutContent();
        }

        public override void UnBind()
        {
            base.UnBind();
            SectionContainer = null;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            RefreshContent();
        }

        public override void InitializeView(ViewGroup layout, Bundle savedInstanceState)
        {
            base.InitializeView(layout, savedInstanceState);
            foreach (var prop in GetType().GetProperties().Where(m => typeof(FragmentSection).IsAssignableFrom(m.PropertyType)))
            {
                var instance = (FragmentSection)Activator.CreateInstance(prop.PropertyType);
                instance.Context = Context;
                instance.ParentLayout = (ViewGroup)Layout.FindViewById(instance.ContainerId);
                instance.Inflate();
                prop.SetValue(this, instance);
            }
        }

        public List<FragmentSection> Content
        {
            get { return _content ?? (_content = new List<FragmentSection>()); }
            set { _content = value; }
        }

        public virtual void GetContent(List<FragmentSection> sections)
        {
        }

        public virtual void LayoutContent()
        {
            foreach (var fragmentSection in Content)
            {
                SectionContainer.AddView(fragmentSection.View);
            }
        }

    }

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
            this.OnViewModelEvent<TaskStarted>(evt => this.SetTaskRunning(evt.Label));
            this.OnViewModelEvent<TaskComplete>(evt => this.SetTaskComplete(evt.ShouldPrompt, evt.Label, evt.OnPrompted));
            this.OnViewModelEvent<TaskFailed>(evt => this.SetTaskFailed(evt.ShouldPrompt, evt.Label, evt.Reason, evt.OnPrompted));
            this.OnViewModelEvent<TaskProgressUpdated>(evt => this.SetTaskProgress(evt.ShouldPrompt, evt.Label));
        }

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

        public override void OnStop()
        {
            base.OnStop();

            if (IsBound)
            {
                UnBind();
                IsBound = false;
            }
            this.DisposeContainer();
        }

        public virtual void UnBind()
        {
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
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            Layout?.LocateOutlets(this);
            InitializeView(Layout, savedInstanceState);
            Bind();
            IsBound = true;
        }

        public virtual void InitializeView(ViewGroup layout, Bundle savedInstanceState)
        {
        }

        public bool IsBound { get; private set; }

        public virtual void Bind()
        {
            
        }

    }

    public class Generate : Attribute
    {
        
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
            //Toast.MakeText(view.MainActivity, label, ToastLength.Long);
            Snackbar.Make(view.Layout, label, Snackbar.LengthLong).Show();
        }

        public static void SetTaskProgress(this ViewFragment view, bool prompt, string label)
        {
            //Toast.MakeText(view.MainActivity, label, ToastLength.Long);
            Snackbar.Make(view.Layout, label, Snackbar.LengthLong).Show();
        }

        public static void SetTaskComplete(this ViewFragment view, bool prompt, string label = null, Action onPrompted = null)
        {
            Snackbar.Make(view.Layout, label, Snackbar.LengthLong).Show();
            //Toast.MakeText(view.MainActivity, label, ToastLength.Long);
            onPrompted?.Invoke();
        }

        public static void SetTaskFailed(this ViewFragment view, bool prompt, string label = null, Exception reason = null, Action<Exception> onPrompted = null)
        {
            Snackbar.Make(view.Layout, label, Snackbar.LengthLong).Show();
            //Toast.MakeText(view.MainActivity, label, ToastLength.Long);
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