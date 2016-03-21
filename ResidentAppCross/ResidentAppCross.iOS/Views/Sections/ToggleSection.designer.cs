// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
	[Register ("ToggleSection")]
	partial class ToggleSection
	{
		[Outlet]
		UIKit.UILabel _headerLabel { get; set; }

		[Outlet]
		UIKit.UILabel _subHeaderLabel { get; set; }

		[Outlet]
		UIKit.UISwitch _switch { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (_headerLabel != null) {
				_headerLabel.Dispose ();
				_headerLabel = null;
			}
			if (_subHeaderLabel != null) {
				_subHeaderLabel.Dispose ();
				_subHeaderLabel = null;
			}
			if (_switch != null) {
				_switch.Dispose ();
				_switch = null;
			}
		}
	}
}
