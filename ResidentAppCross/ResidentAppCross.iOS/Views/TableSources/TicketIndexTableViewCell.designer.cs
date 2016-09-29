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
    [Register ("TicketIndexTableViewCell")]
    partial class TicketIndexTableViewCell
    {
        [Outlet]
        UIKit.UILabel _commentsLabel { get; set; }


        [Outlet]
        UIKit.UILabel _dateLabel { get; set; }


        [Outlet]
        UIKit.UIImageView _headerIcon { get; set; }


        [Outlet]
        UIKit.UILabel _headerLabel { get; set; }


        [Outlet]
        UIKit.UILabel _noPhotosLabel { get; set; }


        [Outlet]
        UIKit.UICollectionView _photoContainer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_headerLabel != null) {
                _headerLabel.Dispose ();
                _headerLabel = null;
            }
        }
    }
}