using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Gms.Maps;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Shared.Caching;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Components.Navigation;
using ResidentAppCross.Droid.Views.Components.NavigationDrawer;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.Events;
using ResidentAppCross.Interfaces;
using ResidentAppCross.ViewModels;
using Square.OkHttp;
using Exception = System.Exception;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using Math = System.Math;
using Object = Java.Lang.Object;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ResidentAppCross.Droid.Views
{
    [Activity(Label = "Apartment Apps", 
        MainLauncher = true, 
        NoHistory = false,
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class ApplicationHostActivity : MvxCachingFragmentCompatActivity<ApplicationViewModel>
    {
        private FrameLayout _frame;
        private Toolbar _toolbar;
        private DrawerLayout _drawerLayout;
        private HomeMenuNavigationView _navigationView;
        private UsefulActionBarDrawerToggle _drawerToggle;
        private IMvxMessenger _eventAggregator;
        private Timer _waitTimer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        public DrawerLayout DrawerLayout
        {
            get { return _drawerLayout ?? (_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.application_host_container)); }
            set { _drawerLayout = value; }
        }

        public Toolbar Toolbar
        {
            get { return _toolbar ?? (_toolbar = FindViewById<Toolbar>(Resource.Id.toolbar)); }
            set { _toolbar = value; }
        }

        public HomeMenuNavigationView HomeMenuView
        {
            get { return _navigationView ?? (_navigationView = FindViewById<HomeMenuNavigationView>(Resource.Id.navigation_view)); }
            set { _navigationView = value; }
        }

        public UsefulActionBarDrawerToggle DrawerToggle
        {
            get { return _drawerToggle ?? (_drawerToggle = new UsefulActionBarDrawerToggle(this, DrawerLayout, Toolbar, Resource.String.drawer_open, Resource.String.drawer_close)); }
            set { _drawerToggle = value; }
        }

        public override void OnBeforeFragmentChanging(IMvxCachedFragmentInfo fragmentInfo, FragmentTransaction transaction)
        {
            base.OnBeforeFragmentChanging(fragmentInfo, transaction);
            transaction.SetCustomAnimations(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight,Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        protected override void OnViewModelSet()
        {

            base.OnViewModelSet();

            //Setup content
            SetContentView(Resource.Layout.application_host);
            //Setup action bar
            SetSupportActionBar(Toolbar);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            //Setup drawer
            DrawerLayout.AddDrawerListener(DrawerToggle);
            DrawerLayout.Post(() => DrawerToggle.SyncState());

            //Setup what's inside the drawer (Home Menu View)
            DrawerToggle.Opening += () =>
            {
                HomeMenuView.Post(() =>
                {
                    HomeMenuView.Refresh();
//                   var item = HomeMenuView.Menu.Add("Please");
//                    item.SetShowAsActionFlags(ShowAsAction.Never);
//                    item.SetCheckable(true);
//                    item.SetIcon(Resource.Drawable.Search);
//                    Console.WriteLine("ok");
                });
            };
            HomeMenuView.ViewModel = Mvx.Resolve<HomeMenuViewModel>();
            HomeMenuView.BeforeNavigate += (sender, args) =>
            {
                for (int i = 0; i < SupportFragmentManager.BackStackEntryCount; ++i)
                {
                    SupportFragmentManager.PopBackStack();
                }
                
                GetCurrentCacheableFragmentsInfo().Clear();

                args.MenuItem.SetChecked(true);

                DrawerLayout.CloseDrawers();
            };

            try
            {
                MapsInitializer.Initialize(this);
            }
            catch (GooglePlayServicesNotAvailableException e)
            {
                e.PrintStackTrace();
            }


            this.OnEvent<TaskStarted>(evt => this.SetTaskRunning(evt.Label));
            this.OnEvent<TaskComplete>(evt => this.SetTaskComplete(evt.ShouldPrompt, evt.Label, evt.OnPrompted));
            this.OnEvent<TaskFailed>(evt => this.SetTaskFailed(evt.ShouldPrompt, evt.Label, evt.Reason, evt.OnPrompted));
            this.OnEvent<TaskProgressUpdated>(evt => this.SetTaskProgress(evt.ShouldPrompt, evt.Label));

            //            var frame = FindViewById<FrameLayout>(Resource.Id.application_host_container_primary);
            //            CoordinatorLayout.LayoutParams prms=(CoordinatorLayout.LayoutParams)frame.LayoutParameters;
            //            prms.Behavior = new SlideUpOnSnackbarBehaviour();
            //            frame.RequestLayout();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //NavigationView.InflateMenu(Resource.Menu.menu_main);
            menu.Clear();
            MenuInflater.Inflate(Resource.Menu.menu_main,menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool Show(MvxViewModelRequest request, Bundle bundle, Type fragmentType, MvxFragmentAttribute fragmentAttribute)
        {
            string fragmentTag = this.GetFragmentTag(request, bundle, fragmentType);
            this.FragmentCacheConfiguration.RegisterFragmentToCache(fragmentTag, fragmentType, request.ViewModelType, fragmentAttribute.AddToBackStack);
            this.ShowFragment(fragmentTag, fragmentAttribute.FragmentContentId, bundle, false, false);
            return true;
        }
        
        protected override string FragmentJavaName(Type fragmentType)
        {
            return Java.Lang.Class.FromType(fragmentType).Name;
        }

        public override void OnFragmentCreated(IMvxCachedFragmentInfo fragmentInfo, FragmentTransaction transaction)
        {
            base.OnFragmentCreated(fragmentInfo, transaction);
        }

        public override void OnFragmentChanging(IMvxCachedFragmentInfo fragmentInfo, FragmentTransaction transaction)
        {
            base.OnFragmentChanging(fragmentInfo, transaction);
        }

        public override bool Close(IMvxViewModel viewModel)
        {
            IMvxCachedFragmentInfo cachedFragmentInfo = GetCurrentCacheableFragmentsInfo().First(x => x.ViewModelType == viewModel.GetType());
            this.CloseFragment(cachedFragmentInfo.Tag, cachedFragmentInfo.ContentId);
            return true;
        }

        protected override void CloseFragment(string tag, int contentId)
        {
            var findFragmentById = this.SupportFragmentManager.FindFragmentById(contentId);
            if (findFragmentById == null)
                return;
            this.SupportFragmentManager.PopBackStackImmediate(tag, 1);
        }

        public override void OnBackPressed()
        {
            if (SupportFragmentManager.BackStackEntryCount >= 1)
            {
                SupportFragmentManager.PopBackStackImmediate();
                if (!FragmentCacheConfiguration.EnableOnFragmentPoppedCallback)
                    return;
                OnFragmentPopped(GetCurrentCacheableFragmentsInfo());
            }
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

        private bool _nextWaitingBlock = false;
        private string _nextWaitingString = null;

        public void SetTaskRunning(string label, bool block = true)
        {
            _nextWaitingBlock = block;
            _nextWaitingString = label;
            WaitTimer.Start();
            //if(block) AndHUD.Shared.Show(view, label, -1, MaskType.Black, centered: true);
        }

        public Timer WaitTimer
        {
            get
            {
                if (_waitTimer == null)
                {
                    _waitTimer = new Timer(220f) {AutoReset = false};
                    _waitTimer.Elapsed += new System.Timers.ElapsedEventHandler((s, e) =>
                    {

                        DrawerLayout.Post(() =>
                        {
                            if (_nextWaitingBlock && !string.IsNullOrEmpty(_nextWaitingString))
                            {
                                var dialog = GetOrCreateDialog(this);
                                dialog.Mode = NotificationDialogMode.Progress;
                                dialog.TitleText = _nextWaitingString;
                                dialog.SubTitleText = "Please, Wait";
                                dialog.ShouldDismissWhenClickedOutside = false;
                            }
                            else
                            {
                                //DismissCurrentDialog();
                            }
                        });
                    });

                }
                return _waitTimer;
            }
            set { _waitTimer = value; }
        }

        public void SetTaskProgress(bool prompt, string label)
        {
            WaitTimer?.Stop();
            _nextWaitingBlock = false;

            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(this);
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

        public void SetTaskComplete(bool prompt, string label = null, Action onPrompted = null)
        {
            WaitTimer?.Stop();
            _nextWaitingBlock = false;

            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(this);
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
                onPrompted?.Invoke();
            }

        }

        public void SetTaskFailed(bool prompt, string label = null, Exception reason = null, Action<Exception> onPrompted = null)
        {
            WaitTimer?.Stop();
            _nextWaitingBlock = false;

            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(this);
                dialog.Mode = NotificationDialogMode.Failed;
                dialog.TitleText = "Oops!";
                dialog.SubTitleText = label;
                dialog.ShouldDismissWhenClickedOutside = true;
                if (onPrompted != null) dialog.OnceOnDismiss(() => onPrompted?.Invoke(reason));
            }
            else
            {
                DismissCurrentDialog();
                onPrompted?.Invoke(reason);
            }
        }

        public void OnEvent<TMessage>(Action<TMessage> handler) where TMessage : MvxMessage
        {
            EventAggregator.Subscribe<TMessage>(evt =>
            {
                DrawerLayout.Post(() =>
                {
                    try
                    {
                        handler(evt);
                    }
                    catch (Exception x)
                    {
                        Console.WriteLine(x.Message);
                    }
                });
            } ,MvxReference.Strong);
        }

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }
    }

    public class SlideUpOnSnackbarBehaviour : AppBarLayout.ScrollingViewBehavior
    {
        public SlideUpOnSnackbarBehaviour(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SlideUpOnSnackbarBehaviour()
        {
        }

        public override bool LayoutDependsOn(CoordinatorLayout parent, Object child, View dependency)
        {
            return dependency is Snackbar.SnackbarLayout || base.LayoutDependsOn(parent,child,dependency);
        }

        public override bool OnDependentViewChanged(CoordinatorLayout parent, Object child, View dependency)
        {
            if (dependency is Snackbar.SnackbarLayout)
            {
                var view = child as View;
                float translationY = Math.Min(0, dependency.TranslationY - dependency.Height);
                return true;
            }
            else
            {
                return base.OnDependentViewChanged(parent, child, dependency);
            }
        }
    }

}