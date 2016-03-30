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
	[Register ("MapSection")]
	partial class MapSection
	{
		[Outlet]
		UIKit.UILabel _headerLabel { get; set; }

		[Outlet]
		MapKit.MKMapView _mapView { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint _sectionHeaderHeightConstraint { get; set; }
		
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

			if (_sectionHeaderHeightConstraint != null) {
				_sectionHeaderHeightConstraint.Dispose ();
				_sectionHeaderHeightConstraint = null;
			}
		}
	}
}
