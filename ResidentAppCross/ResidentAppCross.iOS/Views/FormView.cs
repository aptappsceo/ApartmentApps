using System;

using UIKit;
using ResidentAppCross.iOS.Views;
using System.Diagnostics;
using ResidentAppCross.iOS.Views.Attributes;

namespace ResidentAppCross.iOS
{
	[NavbarStyling]
	public partial class FormView : ViewBase<FormViewModel>
	{
		public FormView () : base (null,null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			this.View.BackgroundColor = UIColor.Blue;
			Debug.WriteLine ("view should be added");
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


