using System;
using System.Collections.Generic;
using System.Diagnostics;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;
using Orientation = Android.Widget.Orientation;

namespace ResidentAppCross.Droid.Views
{
    [Activity(Label = "Apartment Apps", MainLauncher = true, Icon = "@drawable/accounticon", NoHistory = false,WindowSoftInputMode = SoftInput.StateVisible | SoftInput.AdjustResize)]
    public class TestFormView : ViewBase<TestFormViewModel>
    {
        private FrameLayout _screenLayout;

        protected override void OnViewModelSet()
        {
            ActionBar.SetBackgroundDrawable(new ColorDrawable(AppTheme.SecondaryBackgoundColor));
            base.OnViewModelSet();

            SetContentView(ScreenLayout);


            var tx = FragmentManager.BeginTransaction();

            tx.Add(ScreenLayout.Id,new TestForm(), "form");

            tx.Commit();


//            //ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
//            //SetContentView(Resource.Layout.LoginViewLayout);
//
//            var layout = new LinearLayout(this)
//            {
//                Id = 5,
//                Background = new ColorDrawable(AppTheme.DeepBackgroundColor),
//                Orientation = Orientation.Vertical
//            };
//
//            this.AddContentView(layout,
//                new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
//
//            var headerSection = new HeaderSection(this)
//            {
//                HeaderImageResource = Resource.Drawable.L_LocationOk,
//                HeaderImageColor = Color.ParseColor("#4199e6")
//            };
//            var set = this.CreateBindingSet<TestFormView, TestFormViewModel>();
//            set.Bind(headerSection.HeaderLabelView).For(l => l.Text).To(vm => vm.HeaderTitle);
//            set.Bind(headerSection.HeaderSubLabelView).For(l => l.Text).To(vm => vm.SubheaderTitle);
//            set.Apply();
//
//            layout.AddView(headerSection.ContentView);
//
//            layout.AddView(new Space(this).WithWidthMatchParent().WithHeight(10));
//
//            var spinnerSelectionSection = new SpinnerSelectionSection(this)
//            {
//                HeaderText = "Spinner Selection Section"
//            };
//            layout.AddView(spinnerSelectionSection.ContentView);
//
//            spinnerSelectionSection.Spinner.BindTo(new List<string>() {"Hello, World", "Anything Else", "Finnally"},
//                s => s, this);
//
////            layout.AddView(new Space(this).WithWidthMatchParent().WithHeight(10));
////
////            layout.AddView(new TextViewSection(this)
////            {
////                HeaderText = "Text View Section"
////            }.ContentView);
//
//            layout.AddView(new Space(this).WithWidthMatchParent().WithHeight(10));
//
//            var labelWithButtonSection = new LabelWithButtonSection(this)
//            {
//                HeaderText = "Label With Button Section",
//                ButtonText = "Open Dialog"
//            };
//
//
//            var drawable = ContextCompat.GetDrawable(this, Resource.Drawable.L_LocationOk);
//            var misFotos = new[]
//            {
//                drawable, drawable, drawable, drawable, drawable, drawable, drawable, drawable, drawable, drawable,
//                drawable
//            };
//
//
//            var imageBundle = new ImageBundleViewModel();
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri =
//                    new Uri(
//                        "http://i.cbc.ca/1.3376224.1450794847!/fileImage/httpImage/image.jpg_gen/derivatives/4x3_620/tundra-tea-toss.jpg"),
//            });
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri =
//                    new Uri(
//                        "https://timedotcom.files.wordpress.com/2015/12/scott-kelly-photograph-iss-9th-month02.jpg?quality=75&strip=color&w=838"),
//            });
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri =
//                    new Uri(
//                        "https://timedotcom.files.wordpress.com/2015/12/top-100-photos-of-the-year-2015-087.jpg?quality=75&strip=color&w=838"),
//            });
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri = new Uri("http://www.self.com/wp-content/uploads/2016/01/birth-photo-2.jpg"),
//            });
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri =
//                    new Uri(
//                        "http://i2.cdn.turner.com/cnnnext/dam/assets/160107172135-33-week-in-photos-0107-restricted-super-169.jpg"),
//            });
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri =
//                    new Uri(
//                        "http://www.telegraph.co.uk/content/dam/Travel/leadAssets/34/97/comedy-hamster_3497562a-large.jpg"),
//            });
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri = new Uri("https://www.google.com/photos/about/images/auto-awesome/bkg-start.jpg"),
//            });
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri = new Uri("https://www.google.com/photos/about/images/auto-awesome/motion-module/motion-1.jpg"),
//            });
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri =
//                    new Uri(
//                        "http://images.nationalgeographic.com/wpf/media-live/photos/000/911/cache/man-ocean-phytoplankton_91111_600x450.jpg"),
//            });
//            imageBundle.RawImages.Add(new ImageBundleItemViewModel()
//            {
//                Uri =
//                    new Uri(
//                        "http://i2.cdn.turner.com/cnnnext/dam/assets/160201140511-05-china-moon-surface-photos-super-169.jpg"),
//            });
//
//
//            labelWithButtonSection.Button.Click += (sender, args) =>
//            {
//                var fragment = new NotificationDialog();
//                fragment.Items.Add(new NotificationDialogItem() {Title = "Hello"});
//                fragment.Items.Add(new NotificationDialogItem() {Title = "Mister"});
//                fragment.Items.Add(new NotificationDialogItem() {Title = "World"});
//                fragment.Items.Add(new NotificationDialogItem() {Title = "Woop Woop"});
//                fragment.Show(this.FragmentManager, "dialog");
//            };
//
//
//            layout.AddView(labelWithButtonSection.ContentView);
//
//            layout.AddView(new Space(this).WithWidthMatchParent().WithHeight(10));
//
//            layout.AddView(new LabelWithLabelSection(this)
//            {
//                HeaderText = "Label With Label Section",
//                LabelText = "Some Info"
//            }.ContentView);
//
//            layout.AddView(new Space(this).WithWidthMatchParent().WithHeight(10));
//
//            var photoGallerySection = new PhotoGallerySection(this)
//            {
//                HeaderText = "Photo Gallery Section",
//                ButtonText = "Add Photo"
//            };
//
//            photoGallerySection.BindTo(imageBundle);
//            layout.AddView(photoGallerySection.ContentView);
        }

        public FrameLayout ScreenLayout
        {
            get
            {
                if (_screenLayout == null)
                {
                    _screenLayout = new FrameLayout(this)
                    {
                        Id = 1234 ,
                    }.WithBackgroundColor(AppTheme.DeepBackgroundColor).WithDimensionsMatchParent();
                }
                return _screenLayout;
            }
            set { _screenLayout = value; }
        }
    }
}