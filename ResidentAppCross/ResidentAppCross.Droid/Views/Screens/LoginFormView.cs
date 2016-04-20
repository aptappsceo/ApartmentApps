using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using AndroidHUD;
using ApartmentApps.Client.Models;
using Java.Util;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.Platform;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Views;
using RecyclerViewAnimators.Adapters;
using RecyclerViewAnimators.Animators;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.Resources;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary)]
    public class LoginFormView: ViewFragment<LoginFormViewModel>
    {

        [Outlet]
        public EditText EmailInput { get; set; }

        [Outlet]
        public EditText PasswordInput { get; set; }

        [Outlet]
        public Button LoginButton { get; set; }

        public override void Bind()
        {
            base.Bind();

            var set = this.CreateBindingSet<LoginFormView, LoginFormViewModel>();

            set.Bind(LoginButton).To(vm => vm.LoginCommand);
            set.Bind(EmailInput).TwoWay().For(v => v.Text).To(vm => vm.Username);
            set.Bind(PasswordInput).TwoWay().For(v => v.Text).To(vm => vm.Password);
            set.Apply();

        }
    }


    [MvxFragment(typeof(ApplicationViewModel),Resource.Id.application_host_container_primary)]
    public class HomeMenuView : ViewFragment<HomeMenuViewModel>
    {
        public override void Bind()
        {
            base.Bind();
            Console.WriteLine("HomeMenuView: my viewmodel is "+ViewModel.GetHashCode());
        }
    }







    [MvxFragment(typeof(ApplicationViewModel),Resource.Id.application_host_container_primary)]
    public class IncidentReportIndexView : ViewFragment<IncidentReportIndexViewModel>
    {

        [Outlet]
        public RecyclerView ListContainer { get; set; }

        public override void Bind()
        {
            base.Bind();

            var adapter = new TicketIndexAdapter<IncidentIndexBindingModel>()
            {
                Items = ViewModel.Incidents,
                TitleSelector = i=>i.Title
            };

            adapter.DetailsClicked += model =>
            {
                ViewModel.SelectedIncident = model;
                ViewModel.OpenSelectedIncidentCommand.Execute(null);
            };

            ListContainer.SetAdapter(new AlphaInAnimationAdapter(adapter));
            ListContainer.SetLayoutManager(new LinearLayoutManager(Context,LinearLayoutManager.Vertical,false));
            ListContainer.SetItemAnimator(new SlideInLeftAnimator());

            ViewModel.UpdateIncidentsCommand.Execute(null);

        }

    }

}

/*

namespace ResidentAppCross.Droid.Views
{
    [Activity(
        Label = "Authentication", 
        MainLauncher = false, 
        Icon = "@drawable/accounticon",
        NoHistory = true)]
    public class LoginFormView : ViewBase<LoginFormViewModel>
    {
        private LinearLayout _mainLayout;
        private RelativeLayout _headerContainer;
        private LinearLayout _footerContainer;
        private ImageView _applicationLogoView;
        private TextView _applicationTitleView;
        private LinearLayout _bodyContainer;
        private EditText _loginFieldView;
        private RelativeLayout _bodyOuterContainer;
        private EditText _passwordFieldView;
        private TextView _applicationVersionView;
        private Button _loginButtonView;

        protected override void OnViewModelSet()
        {

            base.OnViewModelSet();
            //ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
            SetContentView(MainLayout);

            var set = this.CreateBindingSet<LoginFormView, LoginFormViewModel>();
            set.Bind(LoginButtonView).To(vm => vm.LoginCommand);
            set.Apply();
            
        }

        protected override void OnResume()
        {
            base.OnResume();

            //Window.RequestFeature(WindowFeatures.ActionBar);
            ActionBar.Hide();
//
//            View decorView = Window.DecorView;
//            // Hide the status bar.
//            decorView.SystemUiVisibility = StatusBarVisibility.Hidden;.Fullscreen;
//            // Remember that you should never show the action bar if the
//            // status bar is hidden, so hide that too if necessary.
//            ActionBar actionBar = getActionBar();
//            actionBar.hide();
        }


        public LinearLayout MainLayout
        {
            get
            {
                if (_mainLayout == null)
                {
                    _mainLayout = new LinearLayout(this);
                    _mainLayout.Orientation = Orientation.Vertical;
                    _mainLayout.WeightSum = 1f;
                    _mainLayout.WithDimensionsMatchParent().WithBackground(ContextCompat.GetDrawable(this,Resource.Drawable.background));
                    
                    _mainLayout.AddView(HeaderContainer);
                    _mainLayout.AddView(BodyOuterContainer);

                    //_mainLayout.AddView(FooterContainer);
                }
                return _mainLayout;
            }
            set { _mainLayout = value; }
        }

        public RelativeLayout HeaderContainer
        {
            get
            {
                if (_headerContainer == null)
                {
                    _headerContainer = new RelativeLayout(this)
                        .WithWidthMatchParent()
                        .WithLinearWeight(0.3f);

                    _headerContainer.AddView(ApplicationLogoView);
                    _headerContainer.AddView(ApplicationTitleView);

                }
                return _headerContainer;
            }
            set { _headerContainer = value; }
        }

        public RelativeLayout BodyOuterContainer
        {
            get
            {
                if (_bodyOuterContainer == null)
                {
                    _bodyOuterContainer = new RelativeLayout(this)
                        .WithWidthMatchParent()
                        .WithLinearWeight(0.7f);
                    _bodyOuterContainer.AddView(BodyContainer);
                    _bodyOuterContainer.AddView(ApplicationVersionView);

                }
                return _bodyOuterContainer;
            }
            set { _bodyOuterContainer = value; }
        }

        public LinearLayout BodyContainer
        {
            get
            {
                if (_bodyContainer == null)
                {
                    _bodyContainer = new LinearLayout(this)
                    {
                        Orientation = Orientation.Vertical
                    }
                        .WithLinearGravity(GravityFlags.CenterVertical)
                        .WithWidthMatchParent()
                        .WithHeightWrapContent();
                    _bodyContainer.AddView(LoginFieldView);
                    _bodyContainer.AddView(new View(this).WithWidth(FormWidth).WithHeight(1).WithBackgroundColor(Color.LightGray).WithLinearGravity(GravityFlags.Center));
                    _bodyContainer.AddView(PasswordFieldView);
                    _bodyContainer.AddView(LoginButtonView);

                    var p = _bodyContainer.EnsureRelativeLayoutParams();
                    p.AddRule(LayoutRules.CenterInParent);
                    _bodyContainer.SetPadding(0,-ApplicationVersionView.Height,0,ApplicationVersionView.Height);
                }
                return _bodyContainer;
            }
            set { _bodyContainer = value; }
        }

        public LinearLayout FooterContainer
        {
            get { return _footerContainer; }
            set { _footerContainer = value; }
        }

        public ImageView ApplicationLogoView
        {
            get
            {
                if (_applicationLogoView == null)
                {
                    _applicationLogoView = new ImageView(this)
                        .WithWidthMatchParent();
                    _applicationLogoView.SetScaleType(ImageView.ScaleType.FitCenter);
                    _applicationLogoView.SetImageResource(Resource.Drawable.AppartmentAppsIcon);
                    var p = _applicationLogoView.EnsureRelativeLayoutParams();
                    p.AddRule(LayoutRules.AlignParentTop);
                    p.AddRule(LayoutRules.Above,ApplicationTitleView.Id);
                }
                return _applicationLogoView;
            }
            set { _applicationLogoView = value; }
        }

        public TextView ApplicationTitleView
        {
            get
            {
                if (_applicationTitleView == null)
                {
                    _applicationTitleView = new TextView(this)
                    {
                        Text = "Apartment Apps",
                        Gravity = GravityFlags.Center
                    }
                    .WithHeight(30)
                    .WithWidthMatchParent()
                    .WithFont(AppFonts.ApplicationTitleLargeInvert);
                    _applicationTitleView.Id = 10;
                    var p = _applicationTitleView.EnsureRelativeLayoutParams();
                    p.AddRule(LayoutRules.AlignParentBottom);
                }
                return _applicationTitleView;
            }
            set { _applicationTitleView = value; }
        }

        private static int FormWidth = 270;


        public EditText LoginFieldView
        {
            get
            {
                if (_loginFieldView == null)
                {
                    _loginFieldView = new EditText(this)
                    {
                        Hint = "Username..."
                    }
                        .WithBackground(AppShapes.GetBox.WithRoundedTop())
                        .WithHeight(44)
                        .WithPaddingDp(8,0,8,0)
                        .WithWidth(FormWidth)
                        .WithLinearGravity(GravityFlags.CenterHorizontal)
                        .WithFont(AppFonts.SectionHeadline);
                    _loginFieldView.SetSingleLine(true);
                    _loginFieldView.SetHintTextColor(Color.DarkGray);
                }
                return _loginFieldView;
            }
            set { _loginFieldView = value; }
        }

        public EditText PasswordFieldView
        {
            get
            {
                if (_passwordFieldView == null)
                {
                    _passwordFieldView = new EditText(this)
                    {
                        Hint = "Password..."
                    }
                        .WithBackground(AppShapes.GetBox.WithRoundedBottom())
                        .WithHeight(44)
                        .WithPaddingDp(8, 0, 8, 0)
                        .WithWidth(FormWidth)
                        .WithLinearGravity(GravityFlags.CenterHorizontal)
                        .WithFont(AppFonts.SectionHeadline)
                        .WithLinearMargins(0,0,0,0);
                    _passwordFieldView.SetSingleLine(true);
                    _passwordFieldView.SetHintTextColor(Color.DarkGray);
                    
                }
                return _passwordFieldView;
            }
            set { _passwordFieldView = value; }
        }

        public Button LoginButtonView
        {
            get
            {
                if (_loginButtonView == null)
                {
                    _loginButtonView = new Button(this)
                    {
                        Gravity = GravityFlags.Center,
                        Text = "Log in"
                    }
                    .WithBackgroundColor(AppTheme.SecondaryBackgoundColor)
                    .WithPaddingDp(0,0,0,0)
                    .WithLinearGravity(GravityFlags.CenterHorizontal)
                    .WithWidth(FormWidth)
                    .WithLinearMargins(0, 15, 0, 0)
                    .WithHeight(44);
                }
                return _loginButtonView;
            }
            set { _loginButtonView = value; }
        }

        public TextView ApplicationVersionView
        {
            get
            {
                if (_applicationVersionView == null)
                {
                    _applicationVersionView = new TextView(this)
                    {
                        Text = "Version 1.3 Droid",
                        Gravity = GravityFlags.Center
                    }.WithFont(AppFonts.SectionSubHeadlineInvert)
                    .WithWidthMatchParent()
                    .WithHeight(44);

                    _applicationVersionView.EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignParentBottom);
                }
                return _applicationVersionView;
            }
            set { _applicationVersionView = value; }
        }
    }
}*/