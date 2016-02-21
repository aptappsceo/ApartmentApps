using System;

using Foundation;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class MaintenanceRequestTypeSelectionItemVIew : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("MaintenanceRequestTypeSelectionItemVIew");
		public static readonly UINib Nib;

		static MaintenanceRequestTypeSelectionItemVIew ()
		{
			Nib = UINib.FromName ("MaintenanceRequestTypeSelectionItemVIew", NSBundle.MainBundle);
		}

		public MaintenanceRequestTypeSelectionItemVIew (IntPtr handle) : base (handle)
		{
		}
	}
}
