using System;

using Foundation;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class TicketCollectionViewCell : UICollectionViewCell
	{
		public static readonly NSString Key = new NSString ("TicketCollectionViewCell");
		public static readonly UINib Nib;

		static TicketCollectionViewCell ()
		{
			Nib = UINib.FromName ("TicketCollectionViewCell", NSBundle.MainBundle);
		}

		public TicketCollectionViewCell (IntPtr handle) : base (handle)
		{
		}
	}
}
