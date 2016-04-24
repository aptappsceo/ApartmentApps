using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
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
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Platform.Core;
using ResidentAppCross.Droid.Views.Sections;
using ActionBar = Android.Support.V7.App.ActionBar;

namespace ResidentAppCross.Droid.Views
{


    public class UnitInformationSection : FragmentSection
    {
        private string _avatarUrl;
        private AsyncImageView _avatarView;

        [Outlet]
        public FrameLayout AvatarViewContainer { get; set; }

        [Outlet]
        public TextView NameLabel { get; set; }

        [Outlet]
        public TextView AddressLabel { get; set; }

        [Outlet]
        public TextView PhoneLabel { get; set; }

        [Outlet]
        public TextView EmailLabel { get; set; }

        public AsyncImageView AvatarView
        {
            get
            {
                if (_avatarView == null)
                {
                    _avatarView = new AsyncImageView(Context)
                    {
                    }.WithDimensionsMatchParent().AddTo(AvatarViewContainer);
                    _avatarView.PhotoView.IsOval = true;
                    _avatarView.PhotoView.SetScaleType(ImageView.ScaleType.CenterCrop);
                }
                return _avatarView;
            }
            set { _avatarView = value; }
        }

        public string AvatarUrl
        {
            get { return _avatarUrl; }
            set
            {
                _avatarUrl = value;
                //if (_avatarUrl != null) AvatarView.SetImage(value, new ColorDrawable(Color.White));
            }
        }
    }

    public class HeaderSection : FragmentSection
    {
        [Outlet]
        public TextView TitleLabel { get; set; }

        [Outlet]
        public TextView SubtitleLabel { get; set; }

        [Outlet]
        public ImageView IconView { get; set; }
    }

    public class ActionBarSection : FragmentSection
    {
        [Outlet]
        public ViewGroup ButtonContainer { get; set; }

        public void SetItems(params ActionBarItem[] items)
        {
            Items = items;
            ButtonContainer.RemoveAllViews();
            foreach (var item in items)
            {
                var item1 = item;
                var buttonItem = new AppCompatButton(Context)
                {
                    Hint = "Hint?",
                    Text = item.Title
                }.WithLinearWeight(1).WithHeightWrapContent().AddTo(ButtonContainer);
                buttonItem.SupportBackgroundTintList = ColorStateList.ValueOf(Context.Resources.GetColor(Resource.Color.accent));
                item.Button = buttonItem;
                buttonItem.Click += (sender, args) => item1.Action?.Invoke();
            }
            Update();
        }

        public void Update()
        {
            foreach (var item in Items)
            {
                if (item.IsAvailable?.Invoke() ?? true)
                {
                    item.Button.Visibility = ViewStates.Visible;
                }
                else
                {
                    item.Button.Visibility = ViewStates.Gone;
                }
            }
        }

        public ActionBarItem[] Items { get; private set; }


        public class ActionBarItem
        {
            public string Title { get; set; }
            public Action Action { get; set; }
            public Func<bool> IsAvailable { get; set; }
            public Button Button { get; set; }
        }

    }

    public class RadioSection : FragmentSection
    {

        [Outlet]
        public TextView Label { get; set; }

        [Outlet]
        public RadioGroup RadioContainer { get; set; }

        public void BindToList<T>(IList<T> items, Func<T, string> titleSelector, Action<T> selectionChanged)
        {
            RadioContainer.RemoveAllViews();
            for (int index = 0; index < items.Count; index++)
            {
                var item = items[index];
                var uiItem = new AppCompatRadioButton(Context)
                {
                    Id = index,
                    Text = titleSelector?.Invoke(item),
                    Checked = index == 0
                }
                    .WithWidthMatchParent()
                    .WithHeightWrapContent()
                    .AddTo(RadioContainer);
            }

            RadioContainer.CheckedChange += (sender, args) =>
            {
                selectionChanged?.Invoke(items[args.CheckedId]);
            };
        }
    }

    public class LabelButtonSection : FragmentSection
    {
        [Outlet]
        public TextView Label { get; set; }

        [Outlet]
        public Button Button { get; set; }
    }

    public class SwitchSection : FragmentSection
    {
        [Outlet]
        public TextView Label { get; set; }

        [Outlet]
        public TextView SubtitleLabel { get; set; }

        [Outlet]
        public SwitchCompat Switch { get; set; }
    }

    public class TicketStatusSection : FragmentSection
    {
        [Outlet]
        public TextView TypeLabel { get; set; }

        [Outlet]
        public TextView StatusLabel { get; set; }

        [Outlet]
        public TextView CreatedOnLabel { get; set; }
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

        public virtual void OnInflated()
        {
        }
    }

    public class SectionViewFragment<T> : ViewFragment<T> where T : class, IMvxViewModel
    {
        private List<FragmentSection> _content;
        private ViewGroup _sectionContainer;

        public static int DefaultLayoutId = Resource.Layout.default_section_view;

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

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            foreach (var prop in GetType().GetProperties().Where(m => typeof(FragmentSection).IsAssignableFrom(m.PropertyType)))
            {
                prop.SetValue(this, null);
            }
            Content.Clear();
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
                instance.OnInflated();
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
                SectionContainer.AddView(new View(Context).WithHeight(2).WithWidthMatchParent());
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

        public virtual int LayoutId => GetType().MatchingLayoutId();

        public override void OnStart()
        {
            base.OnStart();
//            this.OnViewModelEvent<TaskStarted>(evt => this.SetTaskRunning(evt.Label));
//            this.OnViewModelEvent<TaskComplete>(evt => this.SetTaskComplete(evt.ShouldPrompt, evt.Label, evt.OnPrompted));
//            this.OnViewModelEvent<TaskFailed>(evt => this.SetTaskFailed(evt.ShouldPrompt, evt.Label, evt.Reason, evt.OnPrompted));
//            this.OnViewModelEvent<TaskProgressUpdated>(evt => this.SetTaskProgress(evt.ShouldPrompt, evt.Label));
        }

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

        private static NotificationDialog _progressDialog;

        public static NotificationDialog CurrentDialog
        {
            get { return _progressDialog; }
            set { _progressDialog = value; }
        }

        public static NotificationDialog GetOrCreateDialog(Activity targetActivity)
        {

            if (targetActivity == null) return null;


            if (targetActivity == CurrentDialog?.SourceActivity)
            {
                return CurrentDialog;
            }


            DismissCurrentDialog();
            CurrentDialog = new NotificationDialog()
            {
                SourceActivity = targetActivity
            };

            CurrentDialog.Show(targetActivity.FragmentManager, "notification");
            CurrentDialog.OnceOnDismiss(() => CurrentDialog = null);
            return CurrentDialog;
            ///CurrentDialog = ;
        }

        public static void DismissCurrentDialog()
        {
            CurrentDialog?.Dismiss();
            CurrentDialog = null;
        }

        public static void SetTaskRunning(this ViewFragment view, string label, bool block = true)
        {

            if (block && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(view.MainActivity);
                dialog.Mode = NotificationDialogMode.Progress;
                dialog.TitleText = label;
                dialog.SubTitleText = "Please, Wait";
                dialog.ShouldDismissWhenClickedOutside = false;
            }
            else
            {
                DismissCurrentDialog();
            }

            //if(block) AndHUD.Shared.Show(view, label, -1, MaskType.Black, centered: true);
        }

        public static void SetTaskProgress(this ViewFragment view, bool prompt, string label)
        {
            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(view.MainActivity);
                dialog.Mode = NotificationDialogMode.Progress;
                dialog.TitleText = label;
                dialog.SubTitleText = "Please, Wait";
                dialog.ShouldDismissWhenClickedOutside = false;
            }
            else
            {
                DismissCurrentDialog();
            }
        }

        public static void SetTaskComplete(this ViewFragment view, bool prompt, string label = null, Action onPrompted = null)
        {

            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(view.MainActivity);
                dialog.Mode = NotificationDialogMode.Complete;
                dialog.TitleText = label;
                dialog.SubTitleText = null;
                dialog.ShouldDismissWhenClickedOutside = true;
                dialog.OnceOnDismiss(onPrompted);
                dialog.SetActions(new[] { new NotificationDialogItem() { Action = () => { }, Title = "Ok", ShouldDismiss = true } });
            }
            else
            {
                DismissCurrentDialog();
            }

        }

        public static void SetTaskFailed(this ViewFragment view, bool prompt, string label = null, Exception reason = null, Action<Exception> onPrompted = null)
        {
            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(view.MainActivity);
                dialog.Mode = NotificationDialogMode.Failed;
                dialog.TitleText = "Oops!";
                dialog.SubTitleText = label;
                dialog.ShouldDismissWhenClickedOutside = true;
                if (onPrompted != null) dialog.OnceOnDismiss(() => onPrompted?.Invoke(reason));
            }
            else
            {
                DismissCurrentDialog();
            }
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