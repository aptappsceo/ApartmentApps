﻿using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Foundation;
using HealthKit;
using ResidentAppCross.Resources;
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
        private static UIColor _primaryIconColor;

        public static UIColor PrimaryBackgroundColor => _primaryBackgroundColor ?? (_primaryBackgroundColor = UIColor.White);
        public static UIColor PrimaryForegroundColor => _primaryForegroundColor ?? (_primaryForegroundColor = Color(81, 81, 81));
        public static UIColor SecondaryBackgoundColor => _secondaryBackgroundColor ?? (_secondaryBackgroundColor = Color(20, 92, 153));
        public static UIColor DeepBackgroundColor => _deepBackgroundColor ?? (_deepBackgroundColor = Color(228, 228, 228));
        public static UIColor SecondaryForegroundColor => _secondaryForegroundColor ?? (_secondaryForegroundColor = UIColor.White);
        public static UIColor PrimaryIconColor => _primaryIconColor ?? (_primaryIconColor = Color(20, 92, 153));


        public static UIColor CompleteColor => _completeColor ?? (_completeColor = Color(76, 218, 100));
        public static UIColor InProgressColor => _inProgressColor ?? (_inProgressColor = Color(78, 203, 251));
        public static UIColor PausedColor => _pausedColor ?? (_pausedColor = Color(254, 151, 48));
        public static UIColor ScheduledColor => _scheduledColor ?? (_scheduledColor = Color(125, 124, 168));
        public static UIColor PendingColor => _pendingColor ?? (_pendingColor = Color(252, 134, 86));

        public static float HeaderSectionHeight = 80;
        public static float CallToActionSectionHeight = 60;
        public static float CommentsSectionHeight = 130;
        public static float TenantDataSectionHeight = 180;
        public static float FormSectionVerticalSpacing = 8f;
        public static float SegmentSectionHeight = 92f;
        public static float LabelWithButtonSectionHeight = 46f;
        private static UIColor _completeColor;
        private static UIColor _inProgressColor;
        private static UIColor _pausedColor;
        private static UIColor _pendingColor;
        private static UIColor _scheduledColor;


        private static UIColor Color(byte r, byte g, byte b, byte a = 255)
        {
            return new UIColor(r / 255f, g/ 255f, b/ 255f, a/ 255f);
        }

        public static UIImage GetTemplateIcon(SharedResources.Icons type, SharedResources.Size size, bool filled = false)
        {
            return GetTemplateIcon(type.ToString(), size,filled);
        }

        public static UIImage GetTemplateIcon(string resource, SharedResources.Size size, bool filled = false)
        {
            var path = resource;

            switch (size)
            {
                case SharedResources.Size.X:
                    path = "132_" + path;
                    break;
                case SharedResources.Size.M:
                    path = "44_" + path;
                    break;
                case SharedResources.Size.S:
                    path = "44_" + path;
                    break;
                case SharedResources.Size.XS:
                    path = "44_" + path;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(size), size, null);
            }

            if (filled)
            {
                var filledPath = path + "_Filled.png";
                path += ".png";
                var image = UIImage.FromFile(filledPath) ?? UIImage.FromFile(path);
                return image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            }
            else
            {
                path += ".png";
                var image = UIImage.FromFile(path);
                return image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            }


         
        }
    }

    public static class AppString
    {
        public static readonly string ApplicationTitle = "Apartment Apps";

        public static string ShortVersion { get; } = NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString();

        public static string VersionShortVerstion => "Version " + ShortVersion;
    }
}
