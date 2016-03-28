using System;
using System.Linq;
using CoreGraphics;
using MvvmCross.iOS.Views;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using UIKit;

namespace ResidentAppCross.iOS
{
    [NavbarStyling(Hidden = true)]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
	public partial class HomeMenuView : ViewBase
	{
		public HomeMenuView () : base ("HomeMenuView", null)
		{
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

		    this.SignOutButton.TouchUpInside += (sender, args) => ViewModel.SignOutCommand.Execute(null);
		    // Perform any additional setup after loading the view, typically from a nib.
		}

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            UsernameAvatarImage.Layer.MasksToBounds = true;
            UsernameAvatarImage.Layer.CornerRadius = UsernameAvatarImage.Frame.Width/2;
            UsernameAvatarImage.Layer.BorderWidth = 4f;
            UsernameAvatarImage.Layer.BorderColor = new CGColor(1f,1f,1f);
        }

        public override void ViewDidAppear(bool animated)
	    {
	        base.ViewDidAppear(animated);
            UsernameAvatarImage.Layer.MasksToBounds = true;
            UsernameAvatarImage.Layer.CornerRadius = UsernameAvatarImage.Frame.Width / 2;
            UsernameAvatarImage.Layer.BorderWidth = 4f;
            UsernameAvatarImage.Layer.BorderColor = new CGColor(1f, 1f, 1f);
        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
