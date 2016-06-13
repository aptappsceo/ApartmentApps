﻿using System;

using Foundation;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class PaymentSummaryViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("PaymentSummaryViewCell");
		public static readonly UINib Nib;

		static PaymentSummaryViewCell ()
		{
			Nib = UINib.FromName ("PaymentSummaryViewCell", NSBundle.MainBundle);
		}

		public PaymentSummaryViewCell (IntPtr handle) : base (handle)
		{
		}

        public UIView TopSeparator => _topSeparator;
        public UIView BottomSeparator => _bottomSeparator;
        public UILabel ItemTitleLabel => _itemTitleLabel;
        public UILabel ItemPriceLabel => _itemPriceLabel;

    }
}
