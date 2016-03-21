using System;

using Foundation;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class TicketIndexTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("TicketIndexTableViewCell");
		public static readonly UINib Nib;

		static TicketIndexTableViewCell ()
		{
			Nib = UINib.FromName ("TicketIndexTableViewCell", NSBundle.MainBundle);
		}

		public TicketIndexTableViewCell (IntPtr handle) : base (handle)
		{
		}
	}
}
