using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;

namespace ResidentAppCross.Droid.Views.Sections
{
    public class SpinnerSelectionSection : BaseSection
    {
        private LinearLayout _sectionContainer;
        private TextView _sectionHeader;
        private Spinner _spinner;
        private string _headerText;

        public SpinnerSelectionSection(Context context) : base(context)
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
                    _sectionContainer.AddView(Spinner);
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
                        Gravity = GravityFlags.CenterVertical | GravityFlags.Left,
                        Text = HeaderText,
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

        public Spinner Spinner
        {
            get
            {
                if (_spinner == null)
                {
                    _spinner = new Spinner(Context, SpinnerMode.Dropdown)
                        .WithWidthWrapContent()
                        .WithPaddingDp(0,0,0,0)
                        .WithHeightMatchParent();
                    _spinner.SetGravity(GravityFlags.CenterVertical | GravityFlags.Right);
                }
                return _spinner;
            }
            set { _spinner = value; }
        }
    }
}