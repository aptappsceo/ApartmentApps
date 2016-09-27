using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Resources;
using ResidentAppCross.ViewModels.Screens;
using ZXing.Rendering;
using BindingFlags = System.Reflection.BindingFlags;
using Orientation = Android.Widget.Orientation;

namespace ResidentAppCross.Droid.Views.Sections
{
    public class BaseSection
    {
        public virtual ViewGroup ContentView { get; set; }
        public Context Context { get; set; }
        public virtual int SectionHeight { get; set; }

        public BaseSection(Context context)
        {
            Context = context;
        }
    }


    public class HeaderSection : BaseSection
    {
        private ImageView _headerImage;
        private LinearLayout _sectionContainer;
        private TextView _headerLabelView;
        private TextView _headerSubLabelView;
        private LinearLayout _titlesContainer;
        private Color? _headerImageColor = Color.Black;
        private int _headerImageResource = -1;

        public override int SectionHeight { get; set; } = AppTheme.HeaderSectionHeight;

        public override ViewGroup ContentView => SectionContainer;

        public ImageView HeaderImage
        {
            get
            {
                if (_headerImage == null)
                {
                    _headerImage = new ImageView(Context)
                    {
                    }
                        .WithHeightMatchParent()
                        .WithWidth(SectionHeight)
                        .WithStandardPadding();
                    _headerImage.SetScaleType(ImageView.ScaleType.CenterInside);

                    if (_headerImageColor.HasValue)
                        _headerImage.SetColorFilter(_headerImageColor.Value);
                    if (_headerImageResource != -1)
                        _headerImage.SetImageResource(_headerImageResource);
                }
                return _headerImage;
            }
            set { _headerImage = value; }
        }

        public LinearLayout SectionContainer
        {
            get
            {
                if (_sectionContainer == null)
                {
                    _sectionContainer = new LinearLayout(Context)
                    {
                        Orientation = Orientation.Horizontal,
                        Background = new ColorDrawable(Color.White),
                    }
                        .WithWidthMatchParent()
                        .WithHeight(SectionHeight)
                        .WithStandardPadding();
                    _sectionContainer.AddView(HeaderImage);
                    _sectionContainer.AddView(TitlesContainer);
                }
                return _sectionContainer;
            }
            set { _sectionContainer = value; }
        }

        public TextView HeaderLabelView
        {
            get
            {
                if (_headerLabelView == null)
                {
                    _headerLabelView = new TextView(Context)
                    {
                        Text = "Hello",
                    }.WithWidthWrapContent()
                        .WithHeightWrapContent()
                        .WithFont(AppFonts.FormHeadline);
                }
                return _headerLabelView;
            }
            set { _headerLabelView = value; }
        }

        public TextView HeaderSubLabelView
        {
            get
            {
                if (_headerSubLabelView == null)
                {
                    _headerSubLabelView = new TextView(Context)
                    {
                        Text = "World",
                    }
                        .WithWidthWrapContent()
                        .WithHeightWrapContent()
                        .WithFont(AppFonts.FormSubHeadline);
                }
                return _headerSubLabelView;
            }
            set { _headerSubLabelView = value; }
        }

        public LinearLayout TitlesContainer
        {
            get
            {
                if (_titlesContainer == null)
                {
                    _titlesContainer = new LinearLayout(Context)
                    {
                        Orientation = Orientation.Vertical,
                    }
                        .WithHeightMatchParent()
                        .WithWidthMatchParent()
                        .WithStandardPadding();
                    _titlesContainer.AddView(HeaderLabelView);
                    _titlesContainer.AddView(new Space(Context)
                        .WithDimensionsMatchParent()
                        .WithLinearWeight(1f));
                    _titlesContainer.AddView(HeaderSubLabelView);
                }
                return _titlesContainer;
            }
            set { _titlesContainer = value; }
        }

        public Color? HeaderImageColor
        {
            get { return _headerImageColor; }
            set
            {
                _headerImageColor = value;
                if (value.HasValue)
                    _headerImage?.SetColorFilter(value.Value); //trololo.Trololo
            }
        }

        public int HeaderImageResource
        {
            get { return _headerImageResource; }
            set
            {
                _headerImageResource = value;
                _headerImage?.SetImageResource(value);
            }
        }

        public HeaderSection(Context context) : base(context)
        {
        }
    }

    public class AppFont
    {
        public int SpSize { get; set; }
        public Color Color { get; set; }
        public TypefaceStyle Style { get; set; } = TypefaceStyle.Normal;
        public Typeface Typeface { get; set; }
    }


    public static class AppTheme
    {
        public static int ButtonToolbarSectionHeight = 60;
        public static int HeaderSectionHeight = 80;
        public static int CallToActionSectionHeight = 60;
        public static int CommentsSectionHeight = 160;
        public static int TenantDataSectionHeight = 230;
        public static int FormSectionVerticalSpacing = 8;
        public static int SegmentSectionHeight = 80;
        public static int SegmentSectionHeightReduced = 50;
        public static int SwitchSectionHeight = 120;
        public static int SingleLineSection = 46;
        public static int SectionHeadlineHeight = 38;

        public static Color SecondaryBackgoundColor { get; set; } = Color.ParseColor("#145c99");
        public static Color DeepBackgroundColor { get; set; } = Color.ParseColor("#e4e4e4");


        public static Drawable GetIcon(SharedResources.Icons icon, SharedResources.Size size)
        {
            var iconname = $"{size}_{icon}";
            var context = DroidApplication.Instance;

            //THE MOTHER OF ALL HACKS
            var fieldInfo = typeof (Resource.Drawable).GetField(iconname, BindingFlags.Static | BindingFlags.Public);
            int identifier = (int)fieldInfo.GetValue(null);

            return ContextCompat.GetDrawable(context, identifier);
        }

        public static int ColorResByMaintenanceState(MaintenanceRequestStatus status)
        {
            switch (status)
            {
                case MaintenanceRequestStatus.Complete:
                    return Resource.Color.semantic_complete;
                case MaintenanceRequestStatus.Paused:
                    return Resource.Color.semantic_pause;
                case MaintenanceRequestStatus.Scheduled:
                    return Resource.Color.semantic_schedule;
                case MaintenanceRequestStatus.Started:
                    return Resource.Color.semantic_inprogress;
                case MaintenanceRequestStatus.Submitted:
                    return Resource.Color.semantic_create;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        public static int ColorResByIncidentState(IncidentReportStatus status)
        {
            switch (status)
            {
                case IncidentReportStatus.Complete:
                    return Resource.Color.semantic_complete;
                case IncidentReportStatus.Open:
                    return Resource.Color.semantic_inprogress;
                case IncidentReportStatus.Paused:
                    return Resource.Color.semantic_pause;
                case IncidentReportStatus.Reported:
                    return Resource.Color.semantic_create;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        public static int IconResByMaintenanceState(MaintenanceRequestStatus status)
        {
            switch (status)
            {
                case MaintenanceRequestStatus.Complete:
                    return SharedResources.Icons.MaintenanceComplete.ToDrawableId();
                case MaintenanceRequestStatus.Paused:
                    return SharedResources.Icons.MaintenancePause.ToDrawableId();
                case MaintenanceRequestStatus.Scheduled:
                    return SharedResources.Icons.MaintenanceCalendar.ToDrawableId();
                case MaintenanceRequestStatus.Started:
                    return SharedResources.Icons.MaintenancePlay.ToDrawableId();
                case MaintenanceRequestStatus.Submitted:
                    return SharedResources.Icons.MaintenancePending.ToDrawableId();
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        public static int StatusIconResByMaintenanceState(MaintenanceRequestStatus status)
        {
            switch (status)
            {
                case MaintenanceRequestStatus.Complete:
                    return Resource.Drawable.cicle_checkmark;
                case MaintenanceRequestStatus.Paused:
                    return Resource.Drawable.circle_pause;
                case MaintenanceRequestStatus.Scheduled:
                    return Resource.Drawable.circle_calendar;
                case MaintenanceRequestStatus.Started:
                    return Resource.Drawable.circle_play;
                case MaintenanceRequestStatus.Submitted:
                    return Resource.Drawable.circle_question;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        public static int StatusIconResByIncidentState(IncidentReportStatus status)
        {
            switch (status)
            {
                case IncidentReportStatus.Complete:
                    return Resource.Drawable.cicle_checkmark;
                case IncidentReportStatus.Open:
                    return Resource.Drawable.circle_play;
                case IncidentReportStatus.Paused:
                    return Resource.Drawable.circle_pause;
                case IncidentReportStatus.Reported:
                    return Resource.Drawable.circle_question;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        public static int IconResByIncidentState(IncidentReportStatus status)
        {
            switch (status)
            {
                case IncidentReportStatus.Complete:
                    return SharedResources.Icons.CourtesyComplete.ToDrawableId();
                case IncidentReportStatus.Open:
                    return SharedResources.Icons.CourtesyInProgress.ToDrawableId();
                case IncidentReportStatus.Paused:
                    return SharedResources.Icons.CourtesyPaused.ToDrawableId();
                case IncidentReportStatus.Reported:
                    return SharedResources.Icons.CourtesyPending.ToDrawableId();
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        public static int ToDrawableId(this SharedResources.Icons icon)
        {
            return icon.ToString().ToLowerUnderscored().AsDrawableId();
        }

    }

    public static class AppFonts
    {
        public static AppFont FormHeadline = new AppFont() {Color = Color.Black, SpSize = 22};
        public static AppFont FormSubHeadline = new AppFont() {Color = Color.Gray, SpSize = 18};
        public static AppFont SectionHeadline = new AppFont() {Color = Color.Gray, SpSize = 18};
        public static AppFont SectionHeadlineInvert = new AppFont() {Color = Color.White, SpSize = 18};
        public static AppFont SectionSubHeadline = new AppFont() {Color = Color.LightGray, SpSize = 16};
        public static AppFont SectionSubHeadlineInvert = new AppFont() {Color = Color.White, SpSize = 16};
        public static AppFont TextViewBody = new AppFont() {Color = Color.Black, SpSize = 16};
        public static AppFont ApplicationTitleLargeInvert = new AppFont() {Color = Color.White, SpSize = 22};
        public static AppFont DialogButton = new AppFont() {Color = Color.White, SpSize = 14};
        public static AppFont DialogHeadline = new AppFont() {Color = Color.DarkGray, SpSize = 18};
        public static AppFont ListItemTitle = new AppFont() {Color = Color.Black, SpSize = 14 };
        public static AppFont ListItemCounter = new AppFont() {Color = Color.White, SpSize = 12, Style = TypefaceStyle.Bold};
        public static AppFont DialogSubHeadline = new AppFont() {Color = Color.DarkGray, SpSize = 16};
    }

    public static class AppBitmaps
    {
        public static Bitmap ColorToWhite(Color color)
        {
            var bitmap = Bitmap.CreateBitmap(4, 4, Bitmap.Config.Argb4444);

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    //if(y >= 2) 
                    bitmap.SetPixel(x, y, y >= 2 ? Color.White : color);
                }
            }

            bitmap.HasMipMap = false;
            return bitmap;
        }
    }

    public static class AppShapes
    {
        public static GradientDrawable GetBox
        {
            get
            {
                GradientDrawable shape = new GradientDrawable();
                shape.SetShape(ShapeType.Rectangle);
                shape.SetColor(Color.White);
                shape.SetStroke(3, Color.White);
                return shape;
            }
        }

        public static GradientDrawable GetCircle
        {
            get
            {
                GradientDrawable shape = new GradientDrawable();
                shape.SetShape(ShapeType.Oval);
                shape.SetColor(Color.White);
                shape.SetStroke(3, Color.White);
                return shape;
            }
        }

    }

    public static class AppDrawables
    {
        private static readonly Dictionary<Color,ColorDrawable> ColorDrawables = new Dictionary<Color, ColorDrawable>(); 

        public static ColorDrawable ByColor(Color c)
        {
            ColorDrawable d;
            if (!ColorDrawables.TryGetValue(c, out d))
            {
                d = ColorDrawables[c] = new ColorDrawable(c);
            }
            return d;
        }
    }

}