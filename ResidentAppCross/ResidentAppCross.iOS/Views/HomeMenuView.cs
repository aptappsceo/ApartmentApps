using System;
using System.Linq;
using MvvmCross.iOS.Views;
using ResidentAppCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS
{
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
            this.NavigationItem.SetHidesBackButton(true, false);
            HomeMenuTable.Source = new HomeMenuTableSource() { Items = ViewModel.MenuItems.ToArray() };

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


