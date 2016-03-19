// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

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
