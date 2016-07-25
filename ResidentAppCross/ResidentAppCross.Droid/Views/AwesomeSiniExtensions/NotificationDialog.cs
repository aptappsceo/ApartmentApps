using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Util;
using RecyclerViewAnimators.Animators;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.Extensions;
using Exception = System.Exception;
using Object = System.Object;
using Orientation = Android.Widget.Orientation;

namespace ResidentAppCross.Droid.Views.AwesomeSiniExtensions
{

    public class XmlPagerAdapter : PagerAdapter
    {
        private List<XmlPagerAdapterItem> _items;

        public View PagesLayout { get; set; }

        public XmlPagerAdapter( View targetLayout, params XmlPagerAdapterItem[] items)
        {
            Items = items.ToList();
            PagesLayout = targetLayout;
        }

        public List<XmlPagerAdapterItem> Items
        {
            get { return _items ?? (_items = new List<XmlPagerAdapterItem>()); }
            set { _items = value; }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object objectValue)
        {
            return view == ((View)objectValue);
        }

        public override int Count => Items.Count;

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(Items[position].Title);
        }

        public override Java.Lang.Object InstantiateItem(View container, int position)
        {
            return PagesLayout?.FindViewById(Items[position].Id);
        }

        public class XmlPagerAdapterItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }


    }

    public class DateTimePickerDialog : DialogFragment, TimePicker.IOnTimeChangedListener, DatePicker.IOnDateChangedListener
    {



//        [Outlet]
//        public TextViewCompat Label { get; set; }
        [Outlet]
        public TimePicker TimePicker { get; set; }
        [Outlet]
        public DatePicker DatePicker { get; set; }
        [Outlet]
        public Button ShowSelectDateButton { get; set; }
        [Outlet]
        public Button ConfirmButton { get; set; }
        [Outlet]
        public Button ShowSelectTimeButton { get; set; }
        [Outlet]
        public ViewPager DialogPager { get; set; }

        public override void OnStart()
        {
            base.OnStart();
            //Dialog?.Window?.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
            //Dialog?.Window?.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetStyle(DialogFragmentStyle.Normal, Resource.Style.MyMaterialTheme);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            CurrentContext = inflater.Context;
            Layout = inflater.Inflate(Resource.Layout.date_time_picker_dialog, container, false);
            Layout.LocateOutlets(this);
            InitializeUI();
            return Layout;
        }

        public View Layout { get; set; }

        private void InitializeUI()
        {

            //            ModePager.Adapter = new XmlPagerAdapter(Layout,new);
            //            ModeTabs.SetupWithViewPager(ModePager);
            //            ModeTabs.Invalidate();
            


            DialogPager.Adapter = new XmlPagerAdapter(Layout, 
            new XmlPagerAdapter.XmlPagerAdapterItem()
            {
                Id = Resource.Id.DatePage,
                Title = "Date"
            }, new XmlPagerAdapter.XmlPagerAdapterItem()
            {
                Id = Resource.Id.TimePage,
                Title = "Time"
            });


            TimePicker.SetOnTimeChangedListener(this);



            SelectedDate = DateTime.Now;
            SelectedTime = new TimeSpan(SelectedDate.Hour,SelectedDate.Minute,0);

            DatePicker.Init(SelectedDate.Year, SelectedDate.Month-1, SelectedDate.Day, this);

            ShowSelectDateButton.Click += (sender, args) =>
            {
                DialogPager.SetCurrentItem(0, true);
            };

            ShowSelectTimeButton.Click += (sender, args) =>
            {
                DialogPager.SetCurrentItem(1, true);
            };

            ConfirmButton.Click += (sender, args) =>
            {
                var dateTime = SelectedDate + SelectedTime;
                DateTimeSelected?.Invoke(dateTime);
            };
        }

        public event Action<DateTime> DateTimeSelected;
        public Context CurrentContext { get; set; }

        public DateTime SelectedDate { get; set; }
        public void OnTimeChanged(TimePicker view, int hourOfDay, int minute)
        {

            SelectedTime = new TimeSpan(hourOfDay,minute,0);
        }

        public TimeSpan SelectedTime { get; set; }
        public void OnDateChanged(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            SelectedDate = view.DateTime;
        }
    }

    public class SearchDialog<T> : DialogFragment
    {
        private IList<T> _items;

        [Outlet]
        public EditText SearchInput { get; set; }
        [Outlet]
        public RecyclerView SearchOutput { get; set; }

        public Func<T, string> TitleSelector { get; set; }
        public Action<T> OnItemSelected { get; set; }
        private ObservableCollection<T> _filteredItems;

        public IList<T> Items
        {
            get { return _items ?? (_items = new List<T>()); }
            set { _items = value; }
        }

        public ObservableCollection<T> FilteredItems
        {
            get { return _filteredItems ?? (_filteredItems = new ObservableCollection<T>()); }
            set { _filteredItems = value; }
        }

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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            CurrentContext = inflater.Context;
            var view = inflater.Inflate(Resource.Layout.search_dialog_layout, container, false);
            view.LocateOutlets(this);
            InitializeUI();
            return view;
        }

        private void InitializeUI()
        {

            var adapter = new IconTitleBadgeListAdapter<T>()
            {
                TitleSelector = TitleSelector
            };

            adapter.Items = FilteredItems;
            adapter.BindToCollection(FilteredItems);

            adapter.ItemSelected += obj =>
            {
                OnItemSelected?.Invoke(obj);
                Dismiss();
            };


            SearchOutput.SetLayoutManager(new LinearLayoutManager(CurrentContext,LinearLayoutManager.Vertical, false));
            SearchOutput.SetItemAnimator(new SlideInLeftAnimator());
            SearchOutput.SetAdapter(adapter);
            SearchInput.TextChanged += (sender, args) => UpdateSearch();
            UpdateSearch();

        }

        public void UpdateSearch()
        {
            FilteredItems.Clear();
            var query = SearchInput.Text.ToLowerInvariant();

            if (!string.IsNullOrEmpty(query))
            {
                FilteredItems.AddRange(Items.Where(t => TitleSelector(t).ToLowerInvariant().Contains(query)));
            }
            else
            {
                FilteredItems.AddRange(Items);
            }

        }

        public Context CurrentContext { get; set; }
    }

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

        public Activity SourceActivity { get; set; }

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
                    _dialogContainer.WithBackgroundColor(Color.Transparent);
                    _dialogContainer.AddView(MainLayout);
                    _dialogContainer.AddView(IconView);
                    _dialogContainer.AddView(ProgressBar);
                    _dialogContainer.Click += (sender, args) =>
                    {
                        if(ShouldDismissWhenClickedOutside)
                        Dismiss();
                    };
                }
                return _dialogContainer;
            }
            set { _dialogContainer = value; }
        }

        public bool ShouldDismissWhenClickedOutside { get; set; }

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
                        .WithBackground(AppShapes.GetBox.WithRoundedCorners());
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
        private NotificationDialogMode _mode;
        private string _subTitleText;
        private string _titleText;
        private List<Action> _onNextDismiss;
        private List<NotificationDialogItem> _actions;

        public void SetActions(NotificationDialogItem[] notificationDialogItem)
        {
            Actions = notificationDialogItem.ToList();
            UpdateActionsIfViewIntialized();
        }

        private void UpdateActionsIfViewIntialized()
        {
            if (_mainLayout == null) return;



            var views =
                Enumerable.Range(0, MainLayout.ChildCount)
                    .Select(i => MainLayout.GetChildAt(i))
                    .Where(c => "action_btn".Equals(c?.Tag?.ToString())).ToArray();

            foreach (var view in views)
            {
                _mainLayout.RemoveView(view);

            }

            foreach (var item in Actions)
            {
                var butn = new AppCompatButton(CurrentContext)
                {
                    Text = item.Title,
                    Gravity = GravityFlags.Center,
                    Tag = "action_btn"
                }
                    .WithWidthMatchParent()
                    .WithHeightWrapContent()
                    .WithPaddingDp(0,0,0,0)
                    .WithLinearMargins(8,8,8,0)
                    .WithFont(AppFonts.DialogButton);
                butn.SupportBackgroundTintList = ColorStateList.ValueOf(Resources.GetColor(Resource.Color.accent));
                var item_CL = item;
                butn.Click += (sender, args) =>
                {
                    item_CL?.Action?.Invoke();
                    if(item_CL.ShouldDismiss) Dismiss();
                };

                MainLayout.AddView(butn);
            }
        }

        public List<NotificationDialogItem> Actions
        {
            get { return _actions ?? (_actions = new List<NotificationDialogItem>()); }
            set { _actions = value; }
        }

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
                    _iconView.SetScaleType(ImageView.ScaleType.FitXy);
                    _iconView.WithBackground(AppShapes.GetCircle.OfColor(Color.White).OfStroke(Color.White, 2));
                    _iconView.SetColorFilter(Resources.GetColor(Resource.Color.primary));
                    _iconView.WithPaddingDp(10, 10, 10, 10);

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

        public override void OnStop()
        {
            base.OnStop();
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

        public string TitleText
        {
            get { return _titleText; }
            set
            {
                _titleText = value;
                UpdateTitleIfInitialized();
            }
        }

        public string SubTitleText
        {
            get { return _subTitleText; }
            set
            {
                _subTitleText = value;
               UpdateSubTitleIfInitialized();
            }
        }

        public NotificationDialogMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                UpdateIfViewInitialized();
            }
        }

        private void UpdateTitleIfInitialized()
        {
            if (_titleLabel == null) return;

            if (string.IsNullOrEmpty(TitleText))
            {
                TitleLabel.Visibility = ViewStates.Gone;
            }
            else
            {
                TitleLabel.Visibility = ViewStates.Visible;
                TitleLabel.Text = TitleText;
            }
        }
        private void UpdateSubTitleIfInitialized()
        {
            if (_subTitleLabel == null) return;
            if (string.IsNullOrEmpty(SubTitleText))
            {
                SubTitleLabel.Visibility = ViewStates.Gone;
            }
            else
            {
                SubTitleLabel.Visibility = ViewStates.Visible;
                SubTitleLabel.Text = SubTitleText;
            }
        }

        private void UpdateIfViewInitialized()
        {
            if (_dialogContainer == null) return;

            if (Mode == NotificationDialogMode.Progress)
            {
                ProgressBar.Visibility = ViewStates.Visible;
            }
            else
            {
                ProgressBar.Visibility = ViewStates.Gone;
            }
           
            IconView.SetImageResource(CurrentIconId);
            IconView.SetColorFilter(CurrentColor);
            UpdateTitleIfInitialized();
            UpdateSubTitleIfInitialized();
            UpdateActionsIfViewIntialized();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            CurrentContext = inflater.Context;

//
//            foreach (var item in Items)
//            {
//                var butn = new Button(CurrentContext)
//                {
//                    Text = item.Title,
//                    Gravity = GravityFlags.Center
//                }
//                    .WithWidthMatchParent()
//                    .WithHeight(33)
//                    .WithPaddingDp(0,0,0,0)
//                    .WithBackground(AppTheme.SecondaryBackgoundColor).WithLinearMargins(0,8,0,0)
//                    .WithFont(AppFonts.DialogButton);
//                
//                MainLayout.AddView(butn);
//            }
            var mainguy = DialogContainer;

            UpdateIfViewInitialized();

            return mainguy;
        }


        

        public int CurrentIconId
        {
            get
            {
                switch (Mode)
                {
                    case NotificationDialogMode.Progress:
                        return Resource.Drawable.gear;
                    case NotificationDialogMode.Failed:
                        return Resource.Drawable.error;
                    case NotificationDialogMode.Complete:
                        return Resource.Drawable.cicle_checkmark;
                    case NotificationDialogMode.Notify:
                        return Resource.Drawable.info;
                    case NotificationDialogMode.Select:
                        return Resource.Drawable.circle_question;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Mode), Mode, null);
                }
            }
        }

        public Color CurrentColor
        {
            get { return AppTheme.SecondaryBackgoundColor; }
        }

        public void OnceOnDismiss(Action onPrompted)
        {
            if (onPrompted != null) OnNextDismiss.Add(onPrompted);
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
            foreach (var action in OnNextDismiss.ToArray())
            {
                action.Invoke();
            }
            OnNextDismiss.Clear();
        }

        public List<Action> OnNextDismiss
        {
            get { return _onNextDismiss ?? (_onNextDismiss = new List<Action>()); }
            set { _onNextDismiss = value; }
        }

    }

    public enum NotificationDialogMode
    {
        Progress,
        Complete,
        Failed,
        Notify,
        Select
    }

    public class NotificationDialogItem
    {
        public Action Action;
        public string Title;
        public bool ShouldDismiss { get; set; } = true;
    }
}