using System;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class MaintenanceStartFormView : ViewBase
	{
		public MaintenanceStartFormView () : base ("MaintenanceStartFormView", null)
		{
		}

	    public new MaintenanceStartFormViewModel ViewModel
	    {
	        get { return (MaintenanceStartFormViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
	    }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


