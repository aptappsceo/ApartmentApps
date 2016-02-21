using System;

using Foundation;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class HomeMenuItemView : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("HomeMenuItemView");
		public static readonly UINib Nib;

		static HomeMenuItemView ()
		{
			Nib = UINib.FromName ("HomeMenuItemView", NSBundle.MainBundle);
		}

		public HomeMenuItemView (IntPtr handle) : base (handle)
		{
		}
	}
}
