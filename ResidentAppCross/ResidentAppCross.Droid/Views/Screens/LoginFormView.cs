using System;
using System.ComponentModel;
using System.Linq;
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
using Android.Views.InputMethods;
using Android.Widget;
using AndroidHUD;
using ApartmentApps.Client.Models;
using Java.Util;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.Platform;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Views;
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

        [Outlet]
        public Button SignUpButton { get; set; }

        public override void Bind()
        {
            base.Bind();

            MainActivity.Window.SetSoftInputMode(SoftInput.AdjustResize | SoftInput.StateHidden);

            var set = this.CreateBindingSet<LoginFormView, LoginFormViewModel>();

            set.Bind(LoginButton).To(vm => vm.LoginCommand);
            set.Bind(EmailInput).TwoWay().For(v => v.Text).To(vm => vm.Username);
            set.Bind(PasswordInput).TwoWay().For(v => v.Text).To(vm => vm.Password);
            set.Bind(SignUpButton).To(vm => vm.SignUpCommand);
            set.Apply();

        }


        public override bool EnableToolbar => false;
    }


    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary)]
    public class RecoverPasswordView: ViewFragment<RecoverPasswordViewModel>
    {

        [Outlet]
        public EditText EmailInput { get; set; }

        [Outlet]
        public Button RecoverPasswordButton { get; set; }

        public override void Bind()
        {
            base.Bind();

            MainActivity.Window.SetSoftInputMode(SoftInput.AdjustResize | SoftInput.StateHidden);

            var set = this.CreateBindingSet<RecoverPasswordView, RecoverPasswordViewModel>();
            set.Bind(RecoverPasswordButton).To(vm => vm.RecoverPasswordCommand);
            set.Bind(EmailInput).TwoWay().For(v => v.Text).To(vm => vm.Email);
            set.Apply();

        }


        public override bool EnableToolbar => false;
    }

    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary,true)]
    public class SignupFormView: ViewFragment<SignUpFormViewModel>
    {

        [Outlet]
        public EditText FirstnameInput { get; set; }

        [Outlet]
        public EditText LastnameInput { get; set; }

        [Outlet]
        public EditText EmailInput { get; set; }

        [Outlet]
        public EditText PhoneInput { get; set; }

        [Outlet]
        public EditText PasswordInput { get; set; }

        [Outlet]
        public EditText PasswordConfirmInput { get; set; }

        [Outlet]
        public ScrollView ScrollContainer { get; set; }

        [Outlet]
        public LinearLayout SectionContainerDefault { get; set; }

        [Outlet]
        public Button SignUpButton { get; set; }

        public override void Bind()
        {
            base.Bind();

            MainActivity.Window.SetSoftInputMode(SoftInput.AdjustResize | SoftInput.StateHidden);

            //       FirstnameInput.WithScrollOnFocus(ScrollContainer);
            //        PasswordConfirmInput.WithScrollOnFocus(ScrollContainer);

            SectionContainerDefault.Click += (sender, args) =>
            {
                InputMethodManager imm = (InputMethodManager)MainActivity.GetSystemService(Application.InputMethodService);
                imm.HideSoftInputFromWindow(Layout.WindowToken, 0);
            };

            PasswordConfirmInput.EditorAction += (sender, args) =>
            {
                InputMethodManager imm = (InputMethodManager)MainActivity.GetSystemService(Application.InputMethodService);
                imm.HideSoftInputFromWindow(Layout.WindowToken, 0);
            };


            var set = this.CreateBindingSet<SignupFormView, SignUpFormViewModel>();
            set.Bind(FirstnameInput).For(f => f.Text).TwoWay().To(vm => vm.FirstName);
            set.Bind(LastnameInput).For(f => f.Text).TwoWay().To(vm => vm.LastName);
            set.Bind(EmailInput).For(f => f.Text).TwoWay().To(vm => vm.Email);
            set.Bind(PhoneInput).For(f => f.Text).TwoWay().To(vm => vm.PhoneNumber);
            set.Bind(PasswordInput).For(f => f.Text).TwoWay().To(vm => vm.Password);
            set.Bind(PasswordConfirmInput).For(f => f.Text).TwoWay().To(vm => vm.PasswordConfirmation);
            set.Bind(SignUpButton).To(vm => vm.SignUpCommand);
            set.Apply();

        }

        public override bool EnableToolbar => false;
    }



    [MvxFragment(typeof (ApplicationViewModel), Resource.Id.application_host_container_primary)]
    public class NotificationIndexView : ViewFragment<NotificationIndexFormViewModel>
    {

        [Outlet]
        public RecyclerView ListContainer { get; set; }

        [Outlet]
        public TextView DescriptionLabel { get; set; }

        public override int LayoutId => typeof(IncidentReportIndexView).MatchingLayoutId();

        public override void Bind()
        {
            base.Bind();
            var adapter = new IconTitleBadgeListAdapter<AlertBindingModel>()
            {
                TitleSelector = i=>i.Title,
                IconColorResourceSelector = i=> (i.HasRead ?? false) ? Resource.Color.secondary_text_body : Resource.Color.primary,
                IconResourceSelector = i => (i.HasRead ?? false) ? Resource.Drawable.message_read : Resource.Drawable.message_unread
            };

            adapter.Items = ViewModel.FilteredNotifications;
            adapter.BindToCollection(ViewModel.FilteredNotifications);

            adapter.ItemSelected += obj =>
            {
                ViewModel.SelectedNotification = obj;
                ViewModel.OpenSelectedNotificationDetailsCommand.Execute(null);
            };

            var set = this.CreateBindingSet<NotificationIndexView, NotificationIndexFormViewModel>();
            set.Bind(DescriptionLabel).For(x => x.Text).To(vm => vm.CurrentNotificationStatusFilter.MarkerTitle);
            set.Apply();

            this.OnViewModelEvent<NotificationFiltersUpdatedEvent>(evt =>
            {
                UpdatesSecondaryInformation();
            });
            UpdatesSecondaryInformation();



            ListContainer.SetLayoutManager(new LinearLayoutManager(Context, LinearLayoutManager.Vertical, false));
            ListContainer.SetItemAnimator(new SlideInLeftAnimator());
            ListContainer.SetAdapter(adapter);

            if (ViewModel.CurrentNotificationStatusFilter == null)
            {
                ViewModel.CurrentNotificationStatusFilter = ViewModel.NotificationStatusFilters?.FirstOrDefault();
            }

        }
        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            base.OnCreateOptionsMenu(menu, inflater);

            inflater.Inflate(Resource.Menu.maintenance_request_index_view_menu, menu);
            FilterItem = menu.FindItem(Resource.Id.FilterButton);
            FilterItem.SetTitle(ViewModel?.CurrentNotificationStatusFilter?.Title);



            foreach (var filter in ViewModel.NotificationStatusFilters)
            {
                var item = FilterItem.SubMenu.Add(ViewModel.GetHashCode(), filter.GetHashCode(), 0, filter.Title);
            }
            UpdateTitle();


        }

        public void UpdatesSecondaryInformation()
        {
            if (string.IsNullOrEmpty(ViewModel?.CurrentNotificationStatusFilter?.MarkerTitle)) DescriptionLabel.Visibility = ViewStates.Gone;
            else DescriptionLabel.Visibility = ViewStates.Visible;
        }

        public override void OnDetach()
        {
            base.OnDetach();
            FilterItem = null;
        }

        public IMenuItem FilterItem { get; set; }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (ViewModel.GetHashCode() != item.GroupId) return base.OnOptionsItemSelected(item);


            //filter?
            var filter = ViewModel.NotificationStatusFilters.FirstOrDefault(f => f.GetHashCode() == item.ItemId);
            if (filter == null) return base.OnOptionsItemSelected(item);
            FilterItem?.SetTitle(filter.Title);
            ViewModel.CurrentNotificationStatusFilter = filter;

            ListContainer.SmoothScrollToPosition(0);

            UpdateTitle();
            return true;


        }


        public override string Title
        {
            get
            {
                if (!string.IsNullOrEmpty(ViewModel?.CurrentNotificationStatusFilter?.MarkerTitle))
                {
                    return $"Notifications ({ViewModel?.CurrentNotificationStatusFilter?.Title ?? "All"})";
                }
                else
                {
                    return $"Notifications";
                }
            }
        }

    }

    [MvxFragment(typeof(ApplicationViewModel),Resource.Id.application_host_container_primary)]
    public class HomeMenuView : ViewFragment<HomeMenuViewModel>
    {
        public override string Title => "Apartment Apps";
        public override void Bind()
        {
            base.Bind();
            Layout.PostDelayed(() =>
            {
                ViewModel.ShowViewModel<NotificationIndexFormViewModel>(vm => { });
            }, 300);
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