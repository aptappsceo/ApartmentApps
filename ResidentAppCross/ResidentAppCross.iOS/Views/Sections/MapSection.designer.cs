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
	[Register ("MapSection")]
	partial class MapSection
	{
		[Outlet]
		UIKit.UILabel _headerLabel { get; set; }

		[Outlet]
		MapKit.MKMapView _mapView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (_headerLabel != null) {
				_headerLabel.Dispose ();
				_headerLabel = null;
			}
			if (_mapView != null) {
				_mapView.Dispose ();
				_mapView = null;
			}
		}
	}
}
