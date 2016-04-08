using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross.Droid.Views.AwesomeSiniExtensions
{

    public class TestForm : FormFragment
    {
        private HeaderSection _headerSection;
        private PhotoGallerySection _photosSection;
        private LabelWithButtonSection _labelButtonSection;
        private LabelWithLabelSection _labelWithLabelSection;
        private SpinnerSelectionSection _spinnerSection;
        private TextViewSection _textViewSection;

        public override View HeaderView => HeaderSection.ContentView;

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = new HeaderSection(Ctx)
                    {
                        HeaderLabelView =
                        {
                            Text = "Maintenance Request"
                        },
                        HeaderSubLabelView =
                        {
                            Text = "Fill the information below"
                        },
                        HeaderImageResource = Resource.Drawable.L_LocationOk,
                        HeaderImageColor = AppTheme.SecondaryBackgoundColor
                    };
                    _headerSection.ContentView.Elevation = 4.ToPx();
                }
                return _headerSection;
            }
            set { _headerSection = value; }
        }

        public PhotoGallerySection PhotosSection
        {
            get
            {
                if (_photosSection == null)
                {
                    _photosSection = new PhotoGallerySection(Ctx)
                    {
                        HeaderText = "Photo Gallery Section",
                        ButtonText = "Add Photo"
                    };

                    var imageBundle = new ImageBundleViewModel();
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri =
                            new Uri(
                                "http://i.cbc.ca/1.3376224.1450794847!/fileImage/httpImage/image.jpg_gen/derivatives/4x3_620/tundra-tea-toss.jpg"),
                    });
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri =
                            new Uri(
                                "https://timedotcom.files.wordpress.com/2015/12/scott-kelly-photograph-iss-9th-month02.jpg?quality=75&strip=color&w=838"),
                    });
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri =
                            new Uri(
                                "https://timedotcom.files.wordpress.com/2015/12/top-100-photos-of-the-year-2015-087.jpg?quality=75&strip=color&w=838"),
                    });
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri = new Uri("http://www.self.com/wp-content/uploads/2016/01/birth-photo-2.jpg"),
                    });
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri =
                            new Uri(
                                "http://i2.cdn.turner.com/cnnnext/dam/assets/160107172135-33-week-in-photos-0107-restricted-super-169.jpg"),
                    });
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri =
                            new Uri(
                                "http://www.telegraph.co.uk/content/dam/Travel/leadAssets/34/97/comedy-hamster_3497562a-large.jpg"),
                    });
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri = new Uri("https://www.google.com/photos/about/images/auto-awesome/bkg-start.jpg"),
                    });
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri = new Uri("https://www.google.com/photos/about/images/auto-awesome/motion-module/motion-1.jpg"),
                    });
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri =
                            new Uri(
                                "http://images.nationalgeographic.com/wpf/media-live/photos/000/911/cache/man-ocean-phytoplankton_91111_600x450.jpg"),
                    });
                    imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Uri =
                            new Uri(
                                "http://i2.cdn.turner.com/cnnnext/dam/assets/160201140511-05-china-moon-surface-photos-super-169.jpg"),
                    });

                    _photosSection.BindTo(imageBundle);
                }
                return _photosSection;
            }
            set { _photosSection = value; }
        }

        public LabelWithButtonSection LabelButtonSection
        {
            get
            {
                if (_labelButtonSection == null)
                {
                    _labelButtonSection = new LabelWithButtonSection(Ctx)
                    {
                        ButtonText = "Tap Me",
                        HeaderText = "Watch Right"
                    };
                } 
                return _labelButtonSection;
            }
            set { _labelButtonSection = value; }
        }

        public LabelWithLabelSection LabelWithLabelSection
        {
            get
            {
                if (_labelWithLabelSection == null)
                {
                    _labelWithLabelSection = new LabelWithLabelSection(Ctx)
                    {
                        HeaderText = "Just Some",
                        LabelText = "Information"
                    };
                }
                return _labelWithLabelSection;
            }
            set { _labelWithLabelSection = value; }
        }

        public SpinnerSelectionSection SpinnerSection
        {
            get
            {
                if (_spinnerSection == null)
                {
                    _spinnerSection = new SpinnerSelectionSection(Ctx)
                    {
                        HeaderText = "Select Me"
                    };

                    _spinnerSection.Spinner.BindTo(new List<string>() { "Hello, World", "Anything Else", "Finnally" },  s => s, Ctx);
                }
                return _spinnerSection;
            }
            set { _spinnerSection = value; }
        }

        public TextViewSection TextViewSection
        {
            get
            {
                if (_textViewSection == null)
                {
                    _textViewSection = new TextViewSection(Ctx)
                    {
                        HeaderText = "Type Something In"
                    };
                }
                return _textViewSection;
            }
            set { _textViewSection = value; }
        }

        public override void GetContent(List<View> content)
        {
            base.GetContent(content);
            content.Add(LabelButtonSection.ContentView);
            content.Add(TextViewSection.ContentView);
            content.Add(LabelWithLabelSection.ContentView);
            content.Add(SpinnerSection.ContentView);
            content.Add(PhotosSection.ContentView);
        }
    }


    public class FormFragment<T> : FormFragment where T : IMvxViewModel
    {
        public T ViewModel { get; set; }
    }

    public class FormFragment : Fragment
    {
        private List<View> _content;
        private LinearLayout _sectionContainer;
        private ScrollView _sectionScrollableContainer;
        private LinearLayout _mainContainer;

        public List<View> Content
        {
            get { return _content ?? (_content = new List<View>()); }
            set { _content = value; }
        }

        public virtual Context Ctx { get; set; }

        public virtual View HeaderView { get; set; }
        public virtual View FooterView { get; set; }

        public virtual LinearLayout MainContainer
        {
            get
            {
                if (_mainContainer == null)
                {
                    _mainContainer = new LinearLayout(Ctx)
                    {
                        Orientation = Orientation.Vertical,
                        Focusable = true,
                        FocusableInTouchMode = true
                    }.WithDimensionsMatchParent();
                }
                return _mainContainer;
            }
            set { _mainContainer = value; }
        }

        public virtual ScrollView MidScrollableContainer
        {
            get
            {
                if (_sectionScrollableContainer == null)
                {
                    _sectionScrollableContainer = new ScrollView(Ctx)
                    {

                    }.WithLinearWeight(1f)
                        .WithBackground(AppTheme.DeepBackgroundColor)
                        .WithWidthMatchParent();
                    //.WithHeightMatchParent();
                }
                return _sectionScrollableContainer;
            }
            set { _sectionScrollableContainer = value; }
        }

        public virtual LinearLayout SectionsContainer
        {
            get
            {
                if (_sectionContainer == null)
                {
                    _sectionContainer = new LinearLayout(Ctx)
                    {
                        Orientation = Orientation.Vertical
                    }
                        .WithBackground(AppTheme.DeepBackgroundColor)
                        .WithWidthMatchParent()
                        .WithHeightWrapContent();
                        
                }
                return _sectionContainer;
            }
            set { _sectionContainer = value; }
        }

        public virtual void RefreshContent()
        {
            Content.Clear();
            GetContent(Content);
            LayoutForm();
            LayoutSections();
        }

        public virtual void GetContent(List<View> content)
        {
            
        }

        public virtual void LayoutForm()
        {
            MainContainer.RemoveAllViews();
            MidScrollableContainer.RemoveAllViews();

            if(HeaderView != null)
                 MainContainer.AddView(HeaderView.WithLinearMargins(0,0,0,8)); // <--- Insert Header

            MainContainer.AddView(MidScrollableContainer); // <--- Insert Body of the form
            MidScrollableContainer.AddView(SectionsContainer);

            if (FooterView != null)
                 MainContainer.AddView(FooterView); // <--- Insert Footer
        }

        public virtual void LayoutSections()
        {
            SectionsContainer.RemoveAllViews();

            foreach (var view in Content)
            {
                view.Elevation = 4.ToPx();
                SectionsContainer.AddView(view.WithLinearMargins(0,0,0,16));
            }

        }

        public virtual void BindForm()
        {
            
        }

        public ViewBase Parent => Activity as ViewBase;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Ctx = inflater.Context;
            if (Parent?.ActionBar != null)
            {
                Parent.ActionBar.Elevation = 0;
            }
            return MainContainer;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            BindForm();
            RefreshContent();
        }
    }

}