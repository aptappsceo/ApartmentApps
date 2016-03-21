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

        public UILabel CommentsLabel => _commentsLabel;
        public UILabel DateLabel => _dateLabel;
        public UIImageView HeaderIcon => _headerIcon;
        public UILabel HeaderLabel => _headerLabel;
        public UILabel NoPhotosLabel => _noPhotosLabel;
	    public UICollectionView PhotoContainer => _photoContainer;
	}
}
