using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;

namespace ResidentAppCross.Droid.Views.Sections
{
    public class LabelWithLabelSection : BaseSection
    {
        private LinearLayout _sectionContainer;
        private TextView _sectionHeader;
        private TextView _label;
        private string _headerText;
        private string _labelText;

        public LabelWithLabelSection(Context context) : base(context)
        {

        }

        public override int SectionHeight { get; set; } = AppTheme.SingleLineSection;
        public override ViewGroup ContentView => SectionContainer;

        public LinearLayout SectionContainer
        {
            get
            {
                if (_sectionHeader == null)
                {
                    _sectionContainer = new LinearLayout(Context)
                    {
                        Orientation = Orientation.Horizontal,
                        Background = new ColorDrawable(Color.White),
                    }
                        .WithWidthMatchParent()
                        .WithHeight(SectionHeight)
                        .WithStandardPadding();

                    _sectionContainer.AddView(SectionHeader);
                    _sectionContainer.AddView(new Space(Context).WithDimensionsMatchParent().WithLinearWeight(1));
                    _sectionContainer.AddView(Label);
                }
                return _sectionContainer;
            }
            set { _sectionContainer = value; }
        }

        public TextView SectionHeader
        {
            get
            {
                if (_sectionHeader == null)
                {
                    _sectionHeader = new TextView(Context)
                    {
                        Text = HeaderText,
                        Gravity = GravityFlags.CenterVertical | GravityFlags.Left
                    }
                        .WithWidthWrapContent()
                        .WithHeightMatchParent()
                        .WithFont(AppFonts.SectionHeadline);
                }
                return _sectionHeader;
            }
            set { _sectionHeader = value; }
        }

        public string HeaderText
        {
            get { return _headerText; }
            set
            {
                _headerText = value;
                if (_sectionHeader != null) _sectionHeader.Text = value;
            }
        }

        public string LabelText
        {
            get { return _labelText; }
            set
            {
                _labelText = value;
                if (_label != null) _label.Text = value;
            }
        }

        public TextView Label
        {
            get
            {
                if (_label == null)
                {
                    _label = new TextView(Context)
                    {
                        Gravity =  GravityFlags.Center,
                        Text = LabelText
                    }
                    .WithFont(AppFonts.SectionHeadline)
                    .WithWidthWrapContent()
                    .WithHeightMatchParent();
                }
                return _label;
            }
            set { _label = value; }
        }
    }
}