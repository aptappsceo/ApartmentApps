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
                UsernameAvatarImage.SetImageWithAsyncIndicator(ViewModel.ProfileImageUrl,UIImage.FromFile("avatar-placeholder.png"));
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

			MenuTable.Source = new HomeMenuTableSource() { Items = ViewModel.MenuItems.ToArray() };
		    MenuTable.SeparatorStyle = UITableViewCellSeparatorStyle.None;

		    var set = this.CreateBindingSet<HomeMenuView, HomeMenuViewModel>();
		    set.Bind(EditProfileButton).To(vm => vm.EditProfileCommand);
		    set.Bind(SignOutButton).To(vm => vm.SignOutCommand);
            set.Apply();
		}


        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            UsernameAvatarImage.ToRounded(UIColor.White);
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
