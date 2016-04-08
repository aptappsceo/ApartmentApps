using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ZXing.Rendering;

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
        public static AppFont DialogButton = new AppFont() { Color = Color.White, SpSize = 14 };
        public static AppFont DialogHeadline = new AppFont() { Color = Color.DarkGray, SpSize = 18 };
        public static AppFont DialogSubHeadline = new AppFont() { Color = Color.DarkGray, SpSize = 16 };

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




        public static GradientDrawable OfColor(this GradientDrawable g, Color r)
        {
            g.SetColor(r);
            return g;
        }

        public static GradientDrawable OfStroke(this GradientDrawable g, Color r, int widthDp)
        {
            g.SetStroke(widthDp.ToPx(), r);
            return g;
        }

        public static GradientDrawable WithRoundedTop(this GradientDrawable g, int rad = 8)
        {
            g.SetCornerRadii(GetCornerRadiiDp(rad,rad,0,0));
            return g;
        }

        public static GradientDrawable WithRoundedBottom(this GradientDrawable g, int rad = 8)
        {
            g.SetCornerRadii(GetCornerRadiiDp(0,0,rad,rad));
            return g;
        }

        public static GradientDrawable WithRoundedCorners(this GradientDrawable g, int rad = 8)
        {
            g.SetCornerRadii(GetCornerRadiiDp(rad,rad,rad,rad));
            return g;
        }



        public static float[] GetCornerRadiiDp(int topLeft, int topRight, int bottomRight, int bottomLeft)
        {
            var tl = topLeft.ToPx();
            var tr = topRight.ToPx();
            var br = bottomRight.ToPx();
            var bl = bottomLeft.ToPx();
            return new float[] {tl, tl, tr, tr, br, br, bl , bl };
        }
    }

}