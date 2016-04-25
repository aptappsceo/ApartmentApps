using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;

namespace ResidentAppCross.Droid.Views.Sections
{
    public class LabelWithButtonSection : BaseSection
    {
        private LinearLayout _sectionContainer;
        private TextView _sectionHeader;
        private Button _button;
        private string _headerText;
        private string _buttonText;

        public LabelWithButtonSection(Context context) : base(context)
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
                    _sectionContainer.AddView(Button);
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

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                if (_button != null) _button.Text = value;
            }
        }

        public Button Button
        {
            get
            {
                if (_button == null)
                {
                    _button = new Button(Context)
                    {
                        Gravity = GravityFlags.Center
                    }
                        .WithPaddingDp(8,0,8,0)
                        .WithFont(AppFonts.SectionSubHeadlineInvert)
                        .WithWidthWrapContent()
                        .WithHeightMatchParent()
                        .WithBackgroundColor(AppTheme.SecondaryBackgoundColor);
                    _button.Text = _buttonText;
                }
                return _button;
            }
            set { _button = value; }
        }
    }
}