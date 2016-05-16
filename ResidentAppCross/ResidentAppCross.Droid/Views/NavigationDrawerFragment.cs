using System;
using System.Collections.ObjectModel;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace ResidentAppCross.Droid.Views.Components.NavigationDrawer
{
//    public class NavigationDrawerFragment : MvxFragment<HomeMenuViewModel>
//    {
//        public NavigationDrawerFragment()
//        {
//        }
//
//        public ObservableCollection<HomeMenuItemViewModel> Data => ViewModel?.MenuItems;
//
//        public override void OnViewModelSet()
//        {
//            base.OnViewModelSet();
//            Recycler.SetAdapter(new NavigationDrawer.NavigationDrawerAdapter(Activity, Data));
//
//        }
//
//        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
//        {
//            //return base.OnCreateView(inflater, container, savedInstanceState);
//
//            var layout = inflater.Inflate(Resource.Layout.nav_main,container,false);
//            Recycler = layout.FindViewById<RecyclerView>(Resource.Id.drawerList);
//            Recycler.SetLayoutManager(new LinearLayoutManager(Activity));
//            return layout;
//
//        }
//
//        public RecyclerView Recycler { get; set; }
//
//        public void Setup(int fragmentId, DrawerLayout layout, Toolbar toolbar)
//        {
//            Container = Activity.FindViewById(fragmentId);
//            DrawerLayout = layout;
//            DrawerToggle = new UsefulActionBarDrawerToggle(Activity,layout,toolbar,Resource.String.drawer_open,Resource.String.drawer_close);
//            DrawerLayout.AddDrawerListener(DrawerToggle);
//            DrawerLayout.Post(() => DrawerToggle.SyncState());
//        }
//
//        public UsefulActionBarDrawerToggle DrawerToggle { get; set; }
//
//        public View Container { get; set; }
//        public DrawerLayout DrawerLayout { get; set; }
//    }

    public class UsefulActionBarDrawerToggle : ActionBarDrawerToggle
    {
        protected UsefulActionBarDrawerToggle(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public UsefulActionBarDrawerToggle(Activity activity, DrawerLayout drawerLayout, Toolbar toolbar, int openDrawerContentDescRes, int closeDrawerContentDescRes) : base(activity, drawerLayout, toolbar, openDrawerContentDescRes, closeDrawerContentDescRes)
        {
            this.Activity = activity;
            this.Layout = drawerLayout;
            this.Toolbar = toolbar;
        }

        public UsefulActionBarDrawerToggle(Activity activity, DrawerLayout drawerLayout, int openDrawerContentDescRes, int closeDrawerContentDescRes) : base(activity, drawerLayout, openDrawerContentDescRes, closeDrawerContentDescRes)
        {
            this.Activity = activity;
            this.Layout = drawerLayout;
        }

        public Toolbar Toolbar { get; set; }
        public DrawerLayout Layout { get; set; }
        public Activity Activity { get; set; }

        public Action<View> Opened { get; set; }
        public Action<View> Closed { get; set; }
        public Action Opening { get; set; }

        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
            Opened?.Invoke(drawerView);
        }

        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
            Closed?.Invoke(drawerView);

        }

        public override void OnDrawerStateChanged(int newState)
        {
            if (newState == DrawerLayout.StateSettling && !Layout.IsDrawerOpen(GravityCompat.Start))
            {
                Layout.Post(()=>Opening?.Invoke());
            }
        }

        public Action<int> OnDrawerOpening { get; set; }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
            Toolbar.Alpha = (1 - slideOffset/2);
        }
    }
}