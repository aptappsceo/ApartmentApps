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
    [Register ("TicketCollectionViewCell")]
    partial class TicketCollectionViewCell
    {
        [Outlet]
        UIKit.UILabel _noPhotoLabel { get; set; }


        [Outlet]
        UIKit.UICollectionView _photoContainer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_noPhotoLabel != null) {
                _noPhotoLabel.Dispose ();
                _noPhotoLabel = null;
            }

            if (_photoContainer != null) {
                _photoContainer.Dispose ();
                _photoContainer = null;
            }
        }
    }
}