using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.Resources;
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
                set.Bind(EditProfileButton).To(vm => vm.EditProfileCommand);
                set.Bind(SignOutButton).To(vm => vm.SignOutCommand);
                set.Apply();

                var exitIcon = AppTheme.GetTemplateIcon(SharedResources.Icons.Exit, SharedResources.Size.S);
                var settingsIcon = AppTheme.GetTemplateIcon(SharedResources.Icons.Settings, SharedResources.Size.S);

                var iconsPadding = 15f;
                var imageEdgeInsets = new UIEdgeInsets(iconsPadding, iconsPadding, iconsPadding, iconsPadding);
                var titleEdgeInsets = new UIEdgeInsets(0, 32f, 0, 0);

                UsernameLabel.Font = AppFonts.SectionHeader;
                EditProfileButton.Font = AppFonts.Note;

                MenuTable.Source = new HomeMenuTableSource() { Items = ViewModel.MenuItems.ToArray() };
                MenuTable.SeparatorStyle = UITableViewCellSeparatorStyle.None;
                SignOutButton.SetRightIcon(exitIcon, false);
                SignOutButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                SignOutButton.TitleEdgeInsets = titleEdgeInsets;
                SignOutButton.ImageEdgeInsets = imageEdgeInsets;
                SignOutButton.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
                SignOutButton.ImageView.TintColor = UIColor.Orange;
                SettingsButton.SetLeftIcon(settingsIcon,false);
                SettingsButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                SettingsButton.TitleEdgeInsets = titleEdgeInsets;
                SettingsButton.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
                SettingsButton.ImageEdgeInsets = imageEdgeInsets;
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
		}

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            UsernameAvatarImage.ContentMode = UIViewContentMode.ScaleAspectFill;
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
