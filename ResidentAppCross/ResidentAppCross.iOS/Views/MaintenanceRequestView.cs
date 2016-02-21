using System;

using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class MaintenanceRequestView : UIViewController
	{
		public MaintenanceRequestView () : base ("MaintenanceRequestView", null)
		{
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


