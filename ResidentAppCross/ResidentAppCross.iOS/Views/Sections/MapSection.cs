using Foundation;
using System;
using System.CodeDom.Compiler;
using MapKit;
using ResidentAppCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class MapSection : SectionViewBase
	{
	    public MapSection()
	    {
	    }

	    public MapSection (IntPtr handle) : base (handle)
		{
            
		}

	    public MKMapView MapView => _mapView;
	    public UILabel HeaderLabel => _headerLabel;

	    public override void AwakeFromNib()
	    {
	        base.AwakeFromNib();
	        HeaderLabel.Font = AppFonts.SectionHeader;
	        MapView.Layer.BorderWidth = 2f;
	        MapView.Layer.BorderColor = UIColor.LightGray.CGColor;
	        MapView.Layer.MasksToBounds = false;
	    }

	    public double MilesToLatitudeDegrees(double miles)
        {
            double earthRadius = 3960.0; // in miles
            double radiansToDegrees = 180.0 / Math.PI;
            return (miles / earthRadius) * radiansToDegrees;
        }

        public double MilesToLongitudeDegrees(double miles, double atLatitude)
        {
            double earthRadius = 3960.0; // in miles
            double degreesToRadians = Math.PI / 180.0;
            double radiansToDegrees = 180.0 / Math.PI;
            // derive the earth's radius at that point in latitude
            double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
            return (miles / radiusAtLatitude) * radiansToDegrees;
        }

    }
}
