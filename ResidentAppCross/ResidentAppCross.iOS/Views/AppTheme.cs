using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Foundation;
using HealthKit;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public static class AppTheme
    {
        private static UIColor _primaryBackgroundColor;
        private static UIColor _secondaryBackgroundColor;
        private static UIColor _primaryForegroundColor;
        private static UIColor _secondaryForegroundColor;
        private static UIColor _deepBackgroundColor;



        public static UIColor PrimaryBackgroundColor => _primaryBackgroundColor ?? (_primaryBackgroundColor = UIColor.White);
        public static UIColor PrimaryForegroundColor => _primaryForegroundColor ?? (_primaryForegroundColor = Color(81, 81, 81));
        public static UIColor SecondaryBackgoundColor => _secondaryBackgroundColor ?? (_secondaryBackgroundColor = Color(20, 92, 153));

        public static UIColor SecondaryForegroundColor => _secondaryForegroundColor ?? (_secondaryForegroundColor = UIColor.White);

        public static float HeaderSectionHeight = 80;
        public static float CallToActionSectionHeight = 60;
        public static float CommentsSectionHeight = 130;
        public static float TenantDataSectionHeight = 180;
        public static float FormSectionVerticalSpacing = 8f;
        public static float SegmentSectionHeight = 92f;
        public static float LabelWithButtonSectionHeight = 46f;


        public static UIColor DeepBackgroundColor => _deepBackgroundColor ?? ( _deepBackgroundColor = Color(228,228,228));

        private static UIColor Color(byte r, byte g, byte b, byte a = 255)
        {
            return new UIColor(r / 255f, g/ 255f, b/ 255f, a/ 255f);
        }

    }

    public static class AppString
    {
        public static readonly string ApplicationTitle = "Apartment Apps";

        public static string ShortVersion { get; } =
            NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString();

        public static string VersionShortVerstion => "Version " + ShortVersion;
    }

}
