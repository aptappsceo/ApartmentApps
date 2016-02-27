using System;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class MaintenanceRequestStatusView : ViewBase
	{

	    public MaintenanceRequestStatusView () : base ("MaintenanceRequestStatusView", null)
		{
		}


	    public new MaintenanceRequestStatusViewModel ViewModel
	    {
	        get { return (MaintenanceRequestStatusViewModel) base.ViewModel; }
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


