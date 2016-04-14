using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using ImageViews.Rounded;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Shared.Caching;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Components.Navigation;
using ResidentAppCross.Droid.Views.Components.NavigationDrawer;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ViewModels;
using ActionBar = Android.Support.V7.App.ActionBar;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ResidentAppCross.Droid.Views
{
    [Activity(Label = "Apartment Apps", 
        MainLauncher = true, 
        WindowSoftInputMode = SoftInput.AdjustResize)]
    public class ApplicationHostActivity : MvxCachingFragmentCompatActivity<ApplicationViewModel>
    {
        private FrameLayout _frame;
        private Toolbar _toolbar;
        private DrawerLayout _drawerLayout;
        private HomeMenuView _navigationView;
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
            get { return _drawerLayout ?? (_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout)); }
            set { _drawerLayout = value; }
        }

        public Toolbar Toolbar
        {
            get { return _toolbar ?? (_toolbar = FindViewById<Toolbar>(Resource.Id.toolbar)); }
            set { _toolbar = value; }
        }

        public HomeMenuView HomeMenuView
        {
            get { return _navigationView ?? (_navigationView = FindViewById<HomeMenuView>(Resource.Id.navigation_view)); }
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
            transaction.SetCustomAnimations(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
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

    }

    public class ContentFragment<T> : MvxFragment<T> where T: class, IMvxViewModel
    {

        public ContentFragment()
        {
        }

        public virtual Fragment HeaderFragment { get; set; }

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
        
        public virtual int LayoutId { get; set; }

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
            if (ViewModel != null && Layout != null) Bind();
        }

        public virtual void Bind()
        {
            
        }

    }

    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary)]
    public class Fragment1 : ContentFragment<Fragment1ViewModel>
    {
        public override int LayoutId => Resource.Layout.fragment_1;
    }

    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary)]
    public class Fragment2 : ContentFragment<Fragment2ViewModel>
    {
        public override int LayoutId => Resource.Layout.fragment_2;
    }

    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary)]
    public class LoginFormViewFragment: ContentFragment<LoginFormViewModel>
    {
        private EditText _emailInput;
        private EditText _passwordInput;
        private TextInputLayout _emailContainer;
        private TextInputLayout _passwordContainer;
        public override int LayoutId => Resource.Layout.login_form_view_fragment;

        public EditText EmailInput
        {
            get { return _emailInput ?? (_emailInput = Layout.FindViewById<EditText>(Resource.Id.input_email)); }
            set { _emailInput = value; }
        }

        public EditText PasswordInput
        {
            get { return _passwordInput ?? (_passwordInput = Layout.FindViewById<EditText>(Resource.Id.input_password)); }
            set { _passwordInput = value; }
        }


        public TextInputLayout EmailContainer
        {
            get { return _emailContainer ?? (_emailContainer = Layout.FindViewById<TextInputLayout>(Resource.Id.input_email_layout)); }
            set { _emailContainer = value; }
        }

        public TextInputLayout PasswordContainer
        {
            get { return _passwordContainer ?? (_passwordContainer = Layout.FindViewById<TextInputLayout>(Resource.Id.input_password_layout)); }
            set { _passwordContainer = value; }
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            EmailContainer.Background = AppShapes.GetBox.WithRoundedTop().OfColor(Color.White);
            PasswordContainer.Background = AppShapes.GetBox.WithRoundedBottom().OfColor(Color.White);
        }

        public override void Bind()
        {
            base.Bind();

        }
    }




    [MvxFragment(typeof (ApplicationViewModel), Resource.Id.application_host_container_primary)]
    public class MaterialPlaygroundFragment1 : ContentFragment<DevelopmentViewModel1>
    {
        private Switch _toolbarToggle;
     

        public override int LayoutId => Resource.Layout.material_playground_fragment_1;


        public Switch ToolbarToggle
        {
            get { return _toolbarToggle ?? (_toolbarToggle = Layout.FindViewById<Switch>(Resource.Id.show_toolbar_switch)); }
            set { _toolbarToggle = value; }
        }

        public override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            ToolbarToggle.Checked = true;
            ToolbarToggle.CheckedChange += (sender, args) =>
            {
                if (ToolbarToggle.Checked)
                {
                    Toolbar.Show();
                }
                else
                {
                    Toolbar.Hide();
                }
            };

            for (int i = 0; i < 15; i++)
            {
                Layout.AddView(new TextView(Context)
                {
                    Text = "Mega Trolololo"
                }.WithWidthMatchParent().WithHeight(40));
            }

        }
    }

}