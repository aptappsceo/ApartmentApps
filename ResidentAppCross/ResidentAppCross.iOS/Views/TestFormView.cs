﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CoreLocation;
using Foundation;
using MapKit;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    [Register("TestFormView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public class TestFormView : BaseForm<TestFormViewModel>
    {

        public TestFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public TestFormView()
        {
        }

        private ButtonToolbarSection _toolbarSection;
        private CallToActionSection _callToActionSection;
        private HeaderSection _headerSection;
        private LabelWithButtonSection _labelWithButtonSection;
        private LabelWithLabelSection _labelWithLabelSection;
        private MapSection _mapSection;
        private PhotoGallerySection _photoGallerySection;
        private SegmentSelectionSection _segmentSelectionSection;
        private ToggleSection _toggleSection;
        private TableSection _tableSection;

        public ButtonToolbarSection ButtonToolbarSection
        {
            get
            {
                if (_toolbarSection == null)
                {
                    _toolbarSection = Formals.Create<ButtonToolbarSection>();
                    _toolbarSection.HeightConstraint.Constant = 80;

                    var style = new UIViewStyle()
                    {
                        BackgroundColor = AppTheme.SecondaryBackgoundColor,
                        ForegroundColor = AppTheme.SecondaryForegroundColor,
                        FontSize = 23.0f
                    };

                    var button = _toolbarSection.AddButton("Button 1", style);
                    button.TouchUpInside += (sender, args) => { Debug.WriteLine("Button Works"); };
                    _toolbarSection.AddButton("Button 2", style);
                    _toolbarSection.AddButton("Button 3", style);

                }
                return _toolbarSection;
            }
        }

        public CallToActionSection CallToActionSection
        {
            get
            {
                if (_callToActionSection == null)
                {
                    _callToActionSection = Formals.Create<CallToActionSection>();
                    _callToActionSection.HeightConstraint.Constant = 80;
                    _callToActionSection.MainButton.SetTitle("Call To Action",UIControlState.Normal);
                }
                return _callToActionSection;
            }
        }

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = 100;
                    _headerSection.LogoImage.Image = UIImage.FromBundle("MaintenaceIcon");
                }
                return _headerSection;
            }
        }

        public LabelWithButtonSection LabelWithButtonSection
        {
            get
            {
                if (_labelWithButtonSection == null)
                {
                    _labelWithButtonSection = Formals.Create<LabelWithButtonSection>();
                    _labelWithButtonSection.HeightConstraint.Constant = 60;
                    _labelWithButtonSection.Label.Text = "Something Here";
                    _labelWithButtonSection.Button.SetTitle("To Select", UIControlState.Normal);
                }
                return _labelWithButtonSection;
            }
        }

        public LabelWithLabelSection LabelWithLabelSection
        {
            get
            {
                if (_labelWithLabelSection == null)
                {
                    _labelWithLabelSection = Formals.Create<LabelWithLabelSection>();
                    _labelWithLabelSection.HeightConstraint.Constant = 60;
                    _labelWithLabelSection.FirstLabel.Text = "Something here";
                    _labelWithLabelSection.SecondLabel.Text = "Already Selected";
                }
                return _labelWithLabelSection;
            }
        }


        public MapSection MapSection
        {
            get
            {
                if (_mapSection == null)
                {
                    _mapSection = Formals.Create<MapSection>();
                    _mapSection.HeightConstraint.Constant = 400;
                    _mapSection.HeaderLabel.Text = "This is map";
                    CLLocationCoordinate2D coords = new CLLocationCoordinate2D(48.857, 2.351);
                    MKCoordinateSpan span = new MKCoordinateSpan(_mapSection.MilesToLatitudeDegrees(20), _mapSection.MilesToLongitudeDegrees(20, coords.Latitude));
                    _mapSection.MapView.Region = new MKCoordinateRegion(coords, span);
                }
                return _mapSection;
            }
        }

        public PhotoGallerySection PhotoGallerySection
        {
            get
            {
                if (_photoGallerySection == null)
                {
                    _photoGallerySection = Formals.Create<PhotoGallerySection>();
                    _photoGallerySection.HeightConstraint.Constant = 200;
                    _photoGallerySection.HeaderLabel.Text = "Some Photos";
                }
                return _photoGallerySection;
            }
        }

        public SegmentSelectionSection SegmentSelectionSection
        {
            get
            {
                if (_segmentSelectionSection == null)
                {
                    _segmentSelectionSection = Formals.Create<SegmentSelectionSection>();
                    _segmentSelectionSection.HeightConstraint.Constant = 120;
                    _segmentSelectionSection.Label.Text = "Segment Selector Section";
                    _segmentSelectionSection.Selector.RemoveAllSegments();
                    _segmentSelectionSection.Selector.InsertSegment("Segment 1",0,false);
                    _segmentSelectionSection.Selector.InsertSegment("Segment 2",1,false);
                    _segmentSelectionSection.Selector.InsertSegment("Segment 3",2,false);
                }
                return _segmentSelectionSection;
            }
        }

        public ToggleSection ToggleSection
        {
            get
            {
                if (_toggleSection == null)
                {
                    _toggleSection = Formals.Create<ToggleSection>();
                    _toggleSection.HeightConstraint.Constant = 150;
                    _toggleSection.HeaderLabel.Text = "Some Switch here";
                    _toggleSection.SubHeaderLabel.Text = "This is a very long text to simulate such behaviour when you gotta tell the user about all the possible consequences of setting the switch to true. Right, this is just a dummy text.";
                }
                return _toggleSection;
            }
        }

        public override float VerticalSectionsSpacing
        {
            get { return 2f; }
            set { }
        }

        public TableSection TableSection
        {
            get
            {
                if (_tableSection == null)
                {
                    _tableSection = Formals.Create<TableSection>();

                    var collection = new[] {
                        new TestDataItem() { Title = "Item 1" },
                        new TestDataItem() { Title = "Editable Item", Editable = true},
                        new TestDataItem() { Title = "Third Item" },
                        new TestDataItem() { Title = "Movable Item" , Moveable = true},
                        new TestDataItem() { Title = "5th Item" },
                        new TestDataItem() { Title = "Last Item" }
                    };

                    var source = new TableSource()
                    {
                        Items = collection.Cast<object>().ToArray(),
                        Binding = new TableDataBinding<TicketIndexTableViewCell, TestDataItem>()
                        {
                            Bind = (cell,item) => { cell.HeaderLabel.Text = item.Title; },
                            IsMoveable = item => item.Moveable,
                            IsEditable = item => item.Editable,
                            IsFocusable = item => item.Focusable
                        }
                    };
                    //_tableSection.Table.EstimatedRowHeight = 250f;
                    //_tableSection.Table.RowHeight = UITableView.AutomaticDimension;
                    _tableSection.Source = source;
                    _tableSection.ReloadData();
                    _tableSection.HeightConstraint.Constant = 200;
                }
                return _tableSection;
            }
        }


        public override void BindForm()
        {
            base.BindForm();
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(TableSection);
            content.Add(LabelWithButtonSection);
            content.Add(PhotoGallerySection);
            content.Add(ToggleSection);
            content.Add(SegmentSelectionSection);
            content.Add(ButtonToolbarSection);
            content.Add(LabelWithLabelSection);
            content.Add(MapSection);
            content.Add(CallToActionSection);
        }
    }
}
