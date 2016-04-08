using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using ResidentAppCross.Droid.Views.Sections;

namespace ResidentAppCross.Droid.Views.AwesomeSiniExtensions
{
    public class NotificationDialog : DialogFragment
    {
        private RelativeLayout _dialogContainer;
        private LinearLayout _mainLayout;
        private ImageView _iconView;
        private View _iconAnchor;
        private TextView _titleLabel;

        public override void OnStart()
        {
            base.OnStart();
            Dialog?.Window?.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
            Dialog?.Window?.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetStyle(DialogFragmentStyle.NoFrame, Android.Resource.Style.ThemeDeviceDefaultDialog);
        }

        public List<NotificationDialogItem> Items
        {
            get { return _items ?? (_items = new List<NotificationDialogItem>()); }
            set { _items = value; }
        }

        public RelativeLayout DialogContainer
        {
            get
            {
                if (_dialogContainer == null && CurrentContext != null)
                {
                    _dialogContainer = new RelativeLayout(CurrentContext).WithDimensionsMatchParent();
                    _dialogContainer.WithBackground(Color.Transparent);
                    _dialogContainer.AddView(MainLayout);
                    _dialogContainer.AddView(IconView);
                    _dialogContainer.AddView(ProgressBar);
                    _dialogContainer.Click += (sender, args) => { Dismiss(); };
                }
                return _dialogContainer;
            }
            set { _dialogContainer = value; }
        }

        public LinearLayout MainLayout
        {
            get
            {
                if (_mainLayout == null && CurrentContext != null)
                {
                    _mainLayout = new LinearLayout(CurrentContext)
                    {
                        Id = 25524,
                        Orientation = Orientation.Vertical
                    }
                        .WithWidth(DialogWidth)
                        .WithHeightWrapContent()
                        .WithPaddingDp(8, IconSizeHalfDp, 8, IconSizeHalfDp/2)
                        .WithDrawableBackground(AppShapes.GetBox.WithRoundedCorners());
                    _mainLayout.Click += (sender, args) => { };
                    var p = _mainLayout.EnsureRelativeLayoutParams();
                    p.AddRule(LayoutRules.CenterInParent);
                    _mainLayout.AddView(TitleLabel);
                    _mainLayout.AddView(SubTitleLabel);
                }
                return _mainLayout ;
            }
            set { _mainLayout = value; }
        }

        public static int IconSizeDp = 80;
        public static int IconSizeHalfDp => IconSizeDp/2;
        public static int DialogWidth = 250;
        private TextView _subTitleLabel;
        private List<NotificationDialogItem> _items;
        private ProgressBar _progressBar;
        //
        //        public RoundedImageView IconView
        //        {
        //            get
        //            {
        //                if (_iconView == null && CurrentContext != null)
        //                {
        //                    _iconView = new RoundedImageView(CurrentContext);
        //                    _iconView.WithDimensions(IconSizeDp);
        //                    _iconView.SetImageResource(Resource.Drawable.L_Ok);
        //                    _iconView.SetScaleType(ImageView.ScaleType.CenterInside);
        //                    _iconView.SetBorderColor(ColorStateList.ValueOf(Color.White));
        //                    _iconView.WithBackground(Color.White);
        //                    _iconView.SetColorFilter(Color.Aquamarine);
        //                    _iconView.BorderWidth = 5.ToPx();
        //                    _iconView.IsOval = true;
        //                    var p = _iconView.EnsureRelativeLayoutParams();
        //                    //p.AddRule(LayoutRules.CenterHorizontal);
        //                    p.AddRule(LayoutRules.Above,MainLayout.Id);
        //                    p.BottomMargin = -(IconSizeDp/2).ToPx();
        //                    p.AddRule(LayoutRules.CenterHorizontal);
        //                    p.AlignWithParent = false;
        //                }
        //                return _iconView;
        //            }
        //            set { _iconView = value; }
        //        }

        public ImageView IconView
        {
            get
            {
                if (_iconView == null && CurrentContext != null)
                {
                    _iconView = new ImageView(CurrentContext);
                    _iconView.WithDimensions(IconSizeDp);
                  //  _iconView.SetImageResource(Resource.Drawable.L_Ok);
                    _iconView.SetScaleType(ImageView.ScaleType.CenterInside);
                    _iconView.WithDrawableBackground(AppShapes.GetCircle.OfColor(Color.White));
                    _iconView.SetColorFilter(AppTheme.SecondaryBackgoundColor);
                    var p = _iconView.EnsureRelativeLayoutParams();
                    //p.AddRule(LayoutRules.CenterHorizontal);
                    p.AddRule(LayoutRules.Above,MainLayout.Id);
                    p.BottomMargin = -(IconSizeHalfDp).ToPx();
                    p.AddRule(LayoutRules.CenterHorizontal);
                    p.AlignWithParent = false;
                }
                return _iconView;
            }
            set { _iconView = value; }
        }

        public ProgressBar ProgressBar
        {
            get
            {
                if (_progressBar == null)
                {
                    _progressBar = new ProgressBar(CurrentContext).WithPaddingDp(16, 16, 16, 16);
                    _progressBar.WithDimensions(IconSizeDp);

                    var p = _progressBar.EnsureRelativeLayoutParams();
                    //p.AddRule(LayoutRules.CenterHorizontal);

                    p.AddRule(LayoutRules.Above, MainLayout.Id);
                    p.BottomMargin = -(IconSizeHalfDp).ToPx();
                    p.AddRule(LayoutRules.CenterHorizontal);
                    p.AlignWithParent = false;
                }
                return _progressBar;
            }
            set { _progressBar = value; }
        }

        public TextView TitleLabel
        {
            get
            {
                if (_titleLabel == null)
                {
                    _titleLabel = new TextView(CurrentContext)
                    {
                        Text = "Testing Against Short Text",
                        Gravity = GravityFlags.Center,
                    }.WithWidthMatchParent()
                    .WithHeightWrapContent()
                    .WithLinearMargins(0,8,0,0)
                    .WithFont(AppFonts.DialogHeadline);
                }
                return _titleLabel;
            }
            set { _titleLabel = value; }
        }

        public TextView SubTitleLabel
        {
            get
            {
                if (_subTitleLabel == null)
                {
                    _subTitleLabel = new TextView(CurrentContext)
                    {
                        Text = "And some othe message",
                        Gravity = GravityFlags.Center,
                    }.WithWidthMatchParent()
                    .WithHeightWrapContent()
                    .WithLinearMargins(0, 16, 0, 8)
                    .WithFont(AppFonts.DialogSubHeadline);
                }
                return _subTitleLabel;
            }
            set { _subTitleLabel = value; }
        }

        public Context CurrentContext { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            CurrentContext = inflater.Context;


            foreach (var item in Items)
            {
                var butn = new Button(CurrentContext)
                {
                    Text = item.Title,
                    Gravity = GravityFlags.Center
                }
                    .WithWidthMatchParent()
                    .WithHeight(33)
                    .WithPaddingDp(0,0,0,0)
                    .WithBackground(AppTheme.SecondaryBackgoundColor).WithLinearMargins(0,8,0,0)
                    .WithFont(AppFonts.DialogButton);
                
                MainLayout.AddView(butn);
            }


            return DialogContainer;
        }
    }


    public class NotificationDialogItem
    {
        public Action Action;
        public string Title;
    }
}