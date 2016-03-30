using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using SDWebImage;
using UIKit;

namespace ResidentAppCross.iOS
{
    [NavbarStyling(Hidden = true)]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
	public partial class HomeMenuView : ViewBase
	{
		public HomeMenuView () : base ("HomeMenuView", null)
		{
            this.DelayBind(() =>
            {

                this.OnViewModelEvent<UserInfoUpdated>(evt =>
                {
                    InvokeOnMainThread(()=>UpdateAvatar());
                });

                var set = this.CreateBindingSet<HomeMenuView, HomeMenuViewModel>();
                set.Bind(UsernameLabel).For(l => l.Text).To(vm => vm.Username);
                set.Apply();


                AppTitleLabel.Text = AppString.ApplicationTitle;
                VersionLabel.Text = AppString.VersionShortVerstion;
            });
		}

        private void UpdateAvatar()
        {
            if (ViewModel.ProfileImageUrl != null)
            {



                var activityIndicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.White);
                activityIndicator.Color = AppTheme.SecondaryBackgoundColor;
                UsernameAvatarImage.AddSubview(activityIndicator);
                activityIndicator.Frame = UsernameAvatarImage.Bounds;
                activityIndicator.HidesWhenStopped = true;
                activityIndicator.StartAnimating();
                //using (var data = NSData.FromUrl(new NSUrl(ViewModel.ProfileImageUrl)))
                UsernameAvatarImage.SetImage(
                    url: new NSUrl(ViewModel.ProfileImageUrl), 
                    placeholder: UIImage.FromFile("avatar-placeholder.png"),
                    completedBlock: (image, error, type, url) =>
                    {
                        activityIndicator.RemoveFromSuperview();
                    });

      
    //);
            }
        }

        public new HomeMenuViewModel ViewModel
		{
			get { return (HomeMenuViewModel) base.ViewModel; }
			set { base.ViewModel = value; }
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			//Hide navbars

			MenuTable.Source = new HomeMenuTableSource() { Items = ViewModel.MenuItems.ToArray() };
		    MenuTable.SeparatorStyle = UITableViewCellSeparatorStyle.None;
		    this.EditProfileButton.TouchUpInside += (sender, args) => ViewModel.EditProfileCommand.Execute(null);
		    this.SignOutButton.TouchUpInside += (sender, args) => ViewModel.SignOutCommand.Execute(null);
		    // Perform any additional setup after loading the view, typically from a nib.
		}


        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            UsernameAvatarImage.Layer.MasksToBounds = true;
            UsernameAvatarImage.Layer.CornerRadius = UsernameAvatarImage.Frame.Width / 2;
            UsernameAvatarImage.Layer.BorderWidth = 4f;
            UsernameAvatarImage.Layer.BorderColor = new CGColor(1f, 1f, 1f);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            UpdateAvatar();
        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
