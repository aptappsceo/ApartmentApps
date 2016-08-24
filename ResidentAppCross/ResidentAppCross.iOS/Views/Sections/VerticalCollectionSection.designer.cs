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
    [Register ("VerticalCollectionSection")]
    partial class VerticalCollectionSection
    {
        [Outlet]
        UIKit.UICollectionView _collection { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_collection != null) {
                _collection.Dispose ();
                _collection = null;
            }
        }
    }
}