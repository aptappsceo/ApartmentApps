using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Views;
using Android.Widget;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;

namespace ResidentAppCross.Droid.Views.Sections
{
    public class TextViewSection : BaseSection
    {
        private LinearLayout _sectionContainer;
        private TextView _sectionHeader;
        private EditText _textView;
        private string _headerText;

        public TextViewSection(Context context) : base(context)
        {
        }

        public override int SectionHeight { get; set; } = AppTheme.CommentsSectionHeight;
        public override ViewGroup ContentView => SectionContainer;

        public LinearLayout SectionContainer
        {
            get
            {
                if (_sectionContainer == null)
                {
                    _sectionContainer = new LinearLayout(Context)
                    {
                        Orientation = Orientation.Vertical,
                        Background = new ColorDrawable(Color.White),
                    }
                        .WithWidthMatchParent()
                        .WithHeight(SectionHeight)
                        .WithStandardPadding();

                    _sectionContainer.AddView(SectionHeader);
                    _sectionContainer.AddView(TextView);
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
                    }
                        .WithWidthWrapContent()
                        .WithStandardPadding()
                        .WithHeight(AppTheme.SectionHeadlineHeight)
                        .WithFont(AppFonts.SectionHeadline);
                }
                return _sectionHeader;
            }
            set { _sectionHeader = value; }
        }

        public EditText TextView
        {
            get
            {
                if (_textView == null)
                {
                    _textView = new EditText(Context)
                    {
                        InputType = InputTypes.TextFlagMultiLine,
                        Gravity = GravityFlags.Top | GravityFlags.Left
                    }
                        .WithDimensionsMatchParent()
                        .WithStandardPadding()
                        .WithFont(AppFonts.TextViewBody);
                }
                return _textView;
            }
            set { _textView = value; }
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
    }
}