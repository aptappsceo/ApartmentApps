// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

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
