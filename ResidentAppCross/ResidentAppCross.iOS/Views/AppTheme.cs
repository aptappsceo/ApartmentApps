﻿using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public static class AppTheme
    {
        private static UIColor _primaryBackgroundColor;
        private static UIColor _secondaryBackgroundColor;
        private static UIColor _primaryForegroundColor;
        private static UIColor _secondaryForegroundColor;

        public static UIColor PrimaryBackgroundColor => _primaryBackgroundColor ?? (_primaryBackgroundColor = UIColor.White);
        public static UIColor PrimaryForegroundColor => _primaryForegroundColor ?? (_primaryForegroundColor = Color(81, 81, 81));
        public static UIColor SecondaryBackgoundColor => _secondaryBackgroundColor ?? (_secondaryBackgroundColor = Color(20, 92, 153));
        public static UIColor SecondaryForegroundColor => _secondaryForegroundColor ?? (_secondaryForegroundColor = UIColor.White);

        private static UIColor Color(byte r, byte g, byte b, byte a = 255)
        {
            return new UIColor(r / 255f, g/ 255f, b/ 255f, a/ 255f);
        }

    }
}