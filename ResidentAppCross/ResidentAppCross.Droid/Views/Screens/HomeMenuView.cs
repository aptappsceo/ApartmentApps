using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using FlyOutMenu;
using ImageViews.Rounded;
using MvvmCross.Droid.Views;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.Resources;
using Object = Java.Lang.Object;

namespace ResidentAppCross.Droid.Views
{
//    [Activity(Label = "Home")]
//    public class DrawerToggle : ViewBase<HomeMenuViewModel>
//    {
//        private RelativeLayout _headerView;
//        private RelativeLayout _mainContainer;
//        private LinearLayout _mainInnerContainer;
//        private ListView _menuItems;
//        private LinearLayout _optionsView;
//        private LinearLayout _footerView;
//        private RoundedImageView _avatarView;
//        private RelativeLayout _accountDataView;
//        private ImageButton _editAccountButton;
//        private TextView _nameLabel;
//
//
//        protected override void OnCreate(Bundle bundle)
//        {
//            base.OnCreate(bundle);
//            
//            //SetContentView(Resource.Layut.HomeMenuViewLayout);
//            //var menu = FindViewById<FlyOutContainer>(Resource.Id.FlyOutContainer);
//            //var menuButton = FindViewById(Resource.Id.MenuButton);
//            //menuButton.Click += (sender, e) => {
//            //    menu.AnimatedOpened = !menu.AnimatedOpened;
//            //};
//
//
//            LayoutScreen();
//            SetContentView(MainInnerContainer);
//
//        }
//
//        protected override void OnViewModelSet()
//        {
//            base.OnViewModelSet();
//            // var items = new List<string>() { "A", "B", "C", "D","E", "A", "B", "C", "D", "E", "A", "B", "C", "D", "E", "A", "B", "C", "D", "E" };
//            var adapter = new IconTitleBadgeListAdapter<HomeMenuItemViewModel>()
//            {
//                Items = ViewModel.MenuItems,
//                TitleSelector = x => x.Name,
//                BadgeSelector = x => x.BadgeLabel,
//                IconSelector = x => x.Icon,
//                IconColorSelector = x => AppTheme.SecondaryBackgoundColor,
//            };
//
//            MenuItems.ItemClick += (sender, args) =>
//            {
//                var item = adapter.Items[(int)args.Id];
//                item.Command.Execute(null);
//            };
//
//            MenuItems.Adapter = adapter;
//        }
//
//        private void LayoutScreen()
//        {
//
//
////            MainInnerContainer
////                .WithRelativeCopyOfParent()
////                .AddTo(MainContainer);
//
//            AvatarView
//                .AddTo(MainInnerContainer)
//                .WithHeight(125);
//
//            AccountDataView
//                .AddTo(MainInnerContainer)
//                .WithHeight(40);
//
//            MenuItems
//                .AddTo(MainInnerContainer)
//                .WithLinearWeight(1f);
//
//            OptionsView
//                .AddTo(MainInnerContainer)
//                .WithHeight(50);
//
//            FooterView
//                .AddTo(MainInnerContainer)
//                .WithHeight(25);
//
//
//            NameLabel
//                .AddTo(AccountDataView)
//                .WithRelativeCenterInParent();
//
//            EditAccountButton.AddTo(AccountDataView)
//                .WithRelativeCenterVertical()
//                .WithRelativeRightOf(NameLabel);
//
////            MenuItems
////                .WithRelativeBelow(HeaderView)
////                .WithRelativeAbove(OptionsView);
////            MainContainer.AddView(MenuItems);
////
////            var optionsLayout = OptionsView.EnsureRelativeLayoutParams();
////            optionsLayout.AddRule(LayoutRules.Above,FooterView.Id);
////            optionsLayout.AddRule(LayoutRules.Below,MenuItems.Id);
////            MainContainer.AddView(OptionsView);
////
////            MainContainer.AddView(FooterView);
//
//        }
//
//
//        public RelativeLayout AccountDataView
//        {
//            get
//            {
//                if (_accountDataView == null)
//                {
//                    _accountDataView = new RelativeLayout(this)
//                        .WithUniqueId()
//                        .WithBackgroundColor(Color.White)
//                        .WithWidthMatchParent();
//                }
//                return _accountDataView;
//            }
//            set { _accountDataView = value; }
//        }
//
//        public ImageButton EditAccountButton
//        {
//            get
//            {
//                if (_editAccountButton == null)
//                {
//                    _editAccountButton = new ImageButton(this)
//                    {
//                      Alpha = 0.4f
//                    }.WithUniqueId()
//                    .WithDimensions(25)
//                    .WithPaddingDp(0,0,0,0);
//                    _editAccountButton.SetBackgroundColor(Color.Transparent);
//                    _editAccountButton.SetImageResource(Resource.Drawable.L_Gear);
//                    _editAccountButton.SetColorFilter(AppTheme.SecondaryBackgoundColor);
//                    _editAccountButton.SetScaleType(ImageView.ScaleType.CenterInside);
//                }
//                return _editAccountButton;
//            }
//            set { _editAccountButton = value; }
//        }
//
//        public TextView NameLabel
//        {
//            get
//            {
//                if (_nameLabel == null)
//                {
//                    _nameLabel = new TextView(this)
//                    {
//                        Gravity = GravityFlags.Center,
//                        Text = "Micah Osborne"
//                    }.WithUniqueId().WithWidthWrapContent().WithPaddingDp(8,0,8,0).WithHeightMatchParent().WithFont(AppFonts.SectionHeadline);
//                    _nameLabel.SetIncludeFontPadding(false);
//                }
//                return _nameLabel;
//            }
//            set { _nameLabel = value; }
//        }
//
//        public RelativeLayout MainContainer
//        {
//            get
//            {
//                if (_mainContainer == null)
//                {
//                    _mainContainer = new RelativeLayout(this)
//                        .WithUniqueId()
//                        .WithDimensionsMatchParent();
//                }
//                return _mainContainer;
//            }
//            set { _mainContainer = value; }
//        }
//
//        public LinearLayout MainInnerContainer
//        {
//            get
//            {
//                if (_mainInnerContainer == null)
//                {
//                    _mainInnerContainer = new LinearLayout(this)
//                    {
//                        Orientation = Orientation.Vertical
//                    }
//                    .WithDimensionsMatchParent();
//                }
//                return _mainInnerContainer;
//            }
//            set { _mainInnerContainer = value; }
//        }
//
//        public RelativeLayout HeaderView
//        {
//            get
//            {
//                if (_headerView == null)
//                {
//                    _headerView = new RelativeLayout(this)
//                        .WithBackgroundColor(AppTheme.SecondaryBackgoundColor)
//                        .WithUniqueId()
//                        .WithWidthMatchParent();
//                }
//                return _headerView;
//            }
//            set { _headerView = value; }
//        }
//
//        public RoundedImageView AvatarView
//        {
//            get
//            {
//                if (_avatarView == null)
//                {
//
//                    _avatarView = new RoundedImageView(this)
//                    {
//                        IsOval = true,
//                        BorderColor = Color.White,
//                        BorderWidth = 8.ToPx(),
//                    }.WithUniqueId()
//                    .WithPaddingDp(16,16,16,16)
//                    .WithWidthMatchParent()
//                    .WithBackground(
//                        AppBitmaps.ColorToWhite(AppTheme.SecondaryBackgoundColor)
//                        .ToDrawable()
//                        .WithFilter(false));
//
//                    _avatarView.SetImageResource(Resource.Drawable.AvatarPlaceholder);
//
//                }
//                return _avatarView;
//            }
//            set { _avatarView = value; }
//        }
//
//        public ProgressBar AvatarLoadingIndicator { get; set; }
//
//        public ListView MenuItems
//        {
//            get
//            {
//                if (_menuItems == null)
//                {
//                    _menuItems = new ListView(this)
//                        .WithUniqueId()
//                        .WithBackgroundColor(Color.White);
//
//            
//                }
//                return _menuItems;
//            }
//            set { _menuItems = value; }
//        }
//
//        public LinearLayout OptionsView
//        {
//            get
//            {
//                if (_optionsView == null)
//                {
//                    _optionsView = new LinearLayout(this)
//                    {
//                        Orientation = Orientation.Horizontal
//                    }
//                    .WithUniqueId()
//                    .WithBackgroundColor(Color.BlanchedAlmond);
//                }
//                return _optionsView;
//            }
//            set { _optionsView = value; }
//        }
//
//        public LinearLayout FooterView
//        {
//            get
//            {
//                if (_footerView == null)
//                {
//                    _footerView = new LinearLayout(this)
//                    {
//                        Orientation = Orientation.Horizontal
//                    }
//                    .WithUniqueId()
//                    .WithBackgroundColor(AppTheme.SecondaryBackgoundColor);
//                }
//                return _footerView;
//            }
//            set { _footerView = value; }
//        }
//    }

    public class IconTitleBadgeListAdapter<T> : BaseAdapter
    {
        private IList<T> _items;

        public Func<T,string> TitleSelector { get; set; } 
        public Func<T,string> BadgeSelector { get; set; } 
        public Func<T,long> IdSelector { get; set; } 
        public Func<T,Color> IconColorSelector { get; set; } 
        public Func<T,Color> BadgeBackgroundColorSelector { get; set; } 
        public Func<T,Color> BadgeForegroundColorSelector { get; set; } 
        public Func<T,Color> BackgroundColorSelector { get; set; } 
        public Func<T,SharedResources.Icons> IconSelector { get; set; }
        public Action<T> ItemSelected { get; set; }
        public IList<T> Items
        {
            get { return _items ?? (_items = new List<T>()); }
            set { _items = value; }
        }

        public override Object GetItem(int position)
        {
            var item = Items[position] as Object;
            return item;
        }

        public override long GetItemId(int position)
        {
            return IdSelector?.Invoke(Items[position]) ?? position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView as ImageTextCounterListItem ?? new ImageTextCounterListItem(parent.Context);

            var item = Items[position];
            view.Title = TitleSelector?.Invoke(item);
            view.Icon = IconSelector?.Invoke(item) ?? SharedResources.Icons.LocationOk;
            view.CounterTitle = BadgeSelector?.Invoke(item);

            if (IconColorSelector != null) view.IconColor = IconColorSelector(item);    
            if (BackgroundColorSelector != null) view.BackgroundColor = BackgroundColorSelector(item);    
            if (BadgeForegroundColorSelector != null) view.BadgeForegroundColor = BadgeForegroundColorSelector(item);    
            if (BadgeBackgroundColorSelector != null) view.BadgeBackgroundColor = BadgeBackgroundColorSelector(item);    

            return view;
        }

        public override int Count => Items.Count;
    }
    

    public class ImageTextCounterListItem : RelativeLayout
    {
        private ImageView _icon;
        private TextView _label;
        private TextView _counter;
        private string _title;
        private SharedResources.Icons _icon1;
        private string _counterTitle;
        private Color _iconColor;
        private Color _badgeBackgroundColor;
        private Color _badgeForegroundColor;
        private Color _backgroundColor;

        public ImageTextCounterListItem(Context context) : base(context)
        {
            this.WithBackgroundColor(Color.White);
            this.AddView(IconView);
            this.AddView(Label);
            this.AddView(Counter);
        }

        public ImageView IconView
        {
            get
            {
                if (_icon == null)
                {
                    _icon = new ImageView(Context)
                        .WithRelativeMargins(8,8,8,0)
                        .WithRelativeAlignParentLeft()
                        .WithPaddingDp(1,1,1,1)
                        .WithDimensions(32);
                    _icon.SetScaleType(ImageView.ScaleType.CenterInside);
                }
                return _icon;
            }
            set { _icon = value; }
        }

        public TextView Label
        {
            get
            {
                if (_label == null)
                {
                    _label = new TextView(Context)
                        .WithDimensionsWrapContent()
                        .WithRelativeRightOf(IconView)
                        .WithRelativeAlignBaseline(Counter)
                        .WithFont(AppFonts.ListItemTitle);
                }
                return _label;
            }
            set { _label = value; }
        }

        public TextView Counter
        {
            get
            {
                if (_counter == null)
                {
                    _counter = new TextView(Context)
                    {
                        Gravity = GravityFlags.Center
                    }
                    .WithDimensions(32)
                    .WithRelativeAlignParentRight()
                    .WithRelativeMargins(0,8,8,0)
                    .WithBackground(AppShapes.GetBox.WithRoundedCorners().OfColor(AppTheme.SecondaryBackgoundColor))
                    .WithFont(AppFonts.ListItemCounter);
                }
                return _counter;
            }
            set { _counter = value; }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Label.Text = value;
            }
        }

        public SharedResources.Icons Icon
        {
            get { return _icon1; }
            set
            {
                _icon1 = value;
                IconView.SetImageDrawable(AppTheme.GetIcon(value,SharedResources.Size.S));
            }
        }

        public Color IconColor
        {
            get { return _iconColor; }
            set
            {
                _iconColor = value; 
                IconView.SetColorFilter(value);
            }
        }

        public Color BadgeBackgroundColor
        {
            get { return _badgeBackgroundColor; }
            set
            {
                _badgeBackgroundColor = value;
                (Counter.Background as GradientDrawable)?.SetColor(value);
            }
        }

        public Color BadgeForegroundColor
        {
            get { return _badgeForegroundColor; }
            set
            {
                _badgeForegroundColor = value;
                Counter.WithFontColor(value);
            }
        }

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value; 
                this.WithBackgroundColor(value);
            }
        }

        public string CounterTitle
        {
            get { return _counterTitle; }
            set
            {
                _counterTitle = value;

                if (string.IsNullOrEmpty(value))
                {
                    Counter.Visibility = ViewStates.Invisible;
                }
                else
                {
                    Counter.Visibility = ViewStates.Visible;
                    Counter.Text = value;
                }
            }
        }
    }
}