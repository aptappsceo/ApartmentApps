using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross.Droid.Views.Screens
{
//    [Activity(Label = "Maintenance Request", MainLauncher = false, Icon = "@drawable/accounticon", NoHistory = false, WindowSoftInputMode = SoftInput.StateVisible | SoftInput.AdjustResize)]
//    public class MaintenanceRequestFormView : ViewBase<MaintenanceRequestFormViewModel>
//    {
//        private FrameLayout _screenLayout;
//        private MaintenanceRequestFormFragment _form;
//
//        public MaintenanceRequestFormFragment Form
//        {
//            get { return _form ?? (_form = new MaintenanceRequestFormFragment()); }
//            set { _form = value; }
//        }
//
//        protected override void OnViewModelSet()
//        {
//            ActionBar.SetBackgroundDrawable(new ColorDrawable(AppTheme.SecondaryBackgoundColor));
//            base.OnViewModelSet();
//            Form.OnBind += Bind;
//            SetContentView(ScreenLayout);
//            var tx = FragmentManager.BeginTransaction();
//            tx.Add(ScreenLayout.Id, Form, "form");
//            tx.Commit();
//        }
//
//        private void Bind()
//        {
//
//
//        }
//
//        public FrameLayout ScreenLayout
//        {
//            get
//            {
//                if (_screenLayout == null)
//                {
//                    _screenLayout = new FrameLayout(this)
//                    {
//                        Id = 1234,
//                    }.WithBackgroundColor(AppTheme.DeepBackgroundColor).WithDimensionsMatchParent();
//                }
//                return _screenLayout;
//            }
//            set { _screenLayout = value; }
//        }
//
//    }
//
//    public class MaintenanceRequestFormFragment : FormFragment<MaintenanceRequestFormViewModel>
//    {
//
//        public HeaderSection HeaderSection { get; set; }
//
//        public override void GetContent(List<View> content)
//        {
//            base.GetContent(content);
//        }
//    }
}