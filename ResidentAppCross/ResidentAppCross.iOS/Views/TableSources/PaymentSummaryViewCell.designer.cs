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
    [Register ("PaymentSummaryViewCell")]
    partial class PaymentSummaryViewCell
    {
        [Outlet]
        UIKit.UIView _bottomSeparator { get; set; }


        [Outlet]
        UIKit.UILabel _itemPriceLabel { get; set; }


        [Outlet]
        UIKit.UILabel _itemTitleLabel { get; set; }


        [Outlet]
        UIKit.UIView _topSeparator { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_bottomSeparator != null) {
                _bottomSeparator.Dispose ();
                _bottomSeparator = null;
            }

            if (_itemPriceLabel != null) {
                _itemPriceLabel.Dispose ();
                _itemPriceLabel = null;
            }

            if (_itemTitleLabel != null) {
                _itemTitleLabel.Dispose ();
                _itemTitleLabel = null;
            }

            if (_topSeparator != null) {
                _topSeparator.Dispose ();
                _topSeparator = null;
            }
        }
    }
}