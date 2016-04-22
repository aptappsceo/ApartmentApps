using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
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
using ImageViews.Rounded;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Caching;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Droid.Views.Components.Navigation;
using ResidentAppCross.Droid.Views.Components.NavigationDrawer;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ViewModels;
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
            transaction.SetCustomAnimations(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight,Android.Resource.Animation.FadeIn, Android.Resource.Animation.FadeOut);
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
            HomeMenuView.NavigationItemSelected += (sender, args) =>
            {
                args.MenuItem.SetChecked(true);
                DrawerLayout.CloseDrawers();
            };

//            var frame = FindViewById<FrameLayout>(Resource.Id.application_host_container_primary);
//            CoordinatorLayout.LayoutParams prms=(CoordinatorLayout.LayoutParams)frame.LayoutParameters;
//            prms.Behavior = new SlideUpOnSnackbarBehaviour();
//            frame.RequestLayout();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //NavigationView.InflateMenu(Resource.Menu.menu_main);
            MenuInflater.Inflate(Resource.Menu.menu_main,menu);
            return base.OnCreateOptionsMenu(menu);
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