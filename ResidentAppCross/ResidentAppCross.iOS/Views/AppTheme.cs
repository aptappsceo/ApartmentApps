using System;
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
        public static UIColor PrimaryForegroundColor => _primaryForegroundColor ?? (_primaryForegroundColor = ColorFromRGB(81, 81, 81));
        public static UIColor SecondaryBackgoundColor => _secondaryBackgroundColor ?? (_secondaryBackgroundColor = ColorFromRGB(20, 92, 153));
        public static UIColor DeepBackgroundColor => _deepBackgroundColor ?? (_deepBackgroundColor = ColorFromRGB(228, 228, 228));
        public static UIColor SecondaryForegroundColor => _secondaryForegroundColor ?? (_secondaryForegroundColor = UIColor.White);
        public static UIColor PrimaryIconColor => _primaryIconColor ?? (_primaryIconColor = ColorFromRGB(20, 92, 153));

//        public static int CompleteColorHex = 0x10a201;
//        public static int InProgressColorHex = 0x289edb;
//        public static int PausedColorHex = 0xff972e;
//        public static int ScheduledColorHex = 0x872eff;
//        public static int PendingColorHex = 0xfe5335;

        public static int CompleteColorHex = 0x14991a;
        public static int InProgressColorHex = 0x148899;
        public static int PausedColorHex = 0x997e14;
        public static int ScheduledColorHex = 0x531499;
        public static int PendingColorHex = 0x992d14;

        public static UIColor CompleteColor => _completeColor ?? (_completeColor = ColorFromHex(CompleteColorHex));
        public static UIColor InProgressColor => _inProgressColor ?? (_inProgressColor = ColorFromHex(InProgressColorHex));
        public static UIColor PausedColor => _pausedColor ?? (_pausedColor = ColorFromHex(PausedColorHex));
        public static UIColor ScheduledColor => _scheduledColor ?? (_scheduledColor = ColorFromHex(ScheduledColorHex));
        public static UIColor PendingColor => _pendingColor ?? (_pendingColor = ColorFromHex(PendingColorHex));

      

        public static UIColor FormControlColor
            => _formControlButton ?? (_formControlButton = ColorFromHex(0x237ecc));
        //Candidates
        //0x331832
        //0x5B1865
        //0x095256
        //0x28C2FF
        public static UIColor CreateColor => _createColor ?? (_createColor = ColorFromRGB(65, 153, 230));

        public static float ButtonToolbarSectionHeight = 60;
        public static float HeaderSectionHeight = 80;
        public static float CallToActionSectionHeight = 60;
        public static float CommentsSectionHeight = 160;
        public static float TenantDataSectionHeight = 220;
        public static float FormSectionVerticalSpacing = 8f;
        public static float SegmentSectionHeight = 80f;
        public static float SegmentSectionHeightReduced = 50f;
        public static float SwitchSectionHeight = 120f;
        public static float LabelWithButtonSectionHeight = 46f;

        private static UIColor _completeColor;
        private static UIColor _inProgressColor;
        private static UIColor _pausedColor;
        private static UIColor _pendingColor;
        private static UIColor _scheduledColor;
        private static UIColor _createColor;
        private static UIColor _formControlButton;

        public static UIColor ColorFromRGB(byte r, byte g, byte b, byte a = 255)
        {
            return new UIColor(r / 255f, g/ 255f, b/ 255f, a/ 255f);
        }

        public static UIColor ColorFromHex(int hexValue)
        {
            return UIColor.FromRGB(
                (((float)((hexValue & 0xFF0000) >> 16)) / 255.0f),
                (((float)((hexValue & 0xFF00) >> 8)) / 255.0f),
                (((float)(hexValue & 0xFF)) / 255.0f)
            );
        }

        public static UIImage GetTemplateIcon(SharedResources.Icons type, SharedResources.Size size, bool filled = false)
        {
            return GetIcon(type.ToString(), size,filled).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
        }

        public static UIImage GetIcon(SharedResources.Icons type, SharedResources.Size size, bool filled = false)
        {
            return GetIcon(type.ToString(), size,filled);
        }

        public static UIImage GetIcon(string resource, SharedResources.Size size, bool filled = false)
        {
            var path = resource;

            switch (size)
            {
                case SharedResources.Size.L:
                    path = "132_" + path;
                    break;
                case SharedResources.Size.M:
                    path = "88_" + path;
                    break;
                case SharedResources.Size.S:
                    path = "44_" + path;
                    break;
                case SharedResources.Size.XS:
                    path = "25_" + path;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(size), size, null);
            }

            if (filled)
            {
                var filledPath = path + "_Filled.png";
                path += ".png";
                var image = UIImage.FromFile(filledPath) ?? UIImage.FromFile(path);
                return image;
            }
            else
            {
                path += ".png";
                var image = UIImage.FromFile(path);
                return image;
            }
         
        }
    }

    public static class AppString
    {
        public static readonly string ApplicationTitle = "Apartment Apps";

        public static string ShortVersion { get; } = NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString();

        public static string VersionShortVerstion => "Version " + ShortVersion;
    }

    public static class AppFonts
    {
        private static UIFont _cellHeaderFont;
        private static UIFont _cellDetailsFont;
        private static UIFont _cellNoteFont;
        private static UIFont _sectionHeaderFont;
        private static UIFont _cellNoteFontSmall;
        private static UIFont _formSubheadline;
        private static UIFont _headerSectionMainFont;
        private static UIFont _formHeadline;
        private static UIFont _note;

        public static UIFont FormHeadline
        {
            get { return _formHeadline ?? (_formHeadline = UIFont.FromDescriptor(UIFontDescriptor.PreferredHeadline, 22f)); }
            set { _formHeadline = value; }
        }

        public static UIFont FormSubheadline
        {
            get { return _formSubheadline ?? (_formSubheadline = UIFont.FromDescriptor(UIFontDescriptor.PreferredSubheadline, 18f)); }
            set { _formSubheadline = value; }
        }

        public static UIFont SectionHeader
        {
            get { return _sectionHeaderFont ?? (_sectionHeaderFont = UIFont.FromDescriptor(UIFontDescriptor.PreferredHeadline, 18f)); }
            set { _sectionHeaderFont = value; }
        }

        public static UIFont CellHeader
        {
            get { return _cellHeaderFont ?? (_cellHeaderFont = UIFont.FromDescriptor(UIFontDescriptor.PreferredHeadline, 16f)); }
            set { _cellHeaderFont = value; }
        }

        public static UIFont CellDetails
        {
            get { return _cellDetailsFont ?? (_cellDetailsFont = UIFont.FromDescriptor(UIFontDescriptor.PreferredSubheadline, 15f)); }
            set { _cellDetailsFont = value; }
        }

        public static UIFont CellNote
        {
            get { return _cellNoteFont ?? (_cellNoteFont = UIFont.FromDescriptor(UIFontDescriptor.PreferredCaption1, 14f)); }
            set { _cellNoteFont = value; }
        }

        public static UIFont CellNoteSmall
        {
            get { return _cellNoteFontSmall ?? (_cellNoteFontSmall = UIFont.FromDescriptor(UIFontDescriptor.PreferredCaption1, 12f)); }
            set { _cellNoteFontSmall = value; }
        }

        public static UIFont Note
        {
            get { return _note ?? (_note = UIFont.FromDescriptor(UIFontDescriptor.PreferredCaption1, 12f)); }
            set { _note = value; }
        }
    }

    public static class AppStrings
    {
        public static string DefaultTextViewHeaderText = "Comments & Details";
    } 
}
