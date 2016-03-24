using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.Sections.CollectionSections;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;
using UIKit;
namespace ResidentAppCross.iOS
{
	[Register("IncidentReportFormView")]
	[NavbarStyling]
	[StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
	public class IncidentReportFormView : BaseForm<IncidentReportFormViewModel>
	{
	    private SegmentSelectionSection _segmentSelectionSection;
	    private HeaderSection _headerSection;

	    public IncidentReportFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
		{
		}

		public IncidentReportFormView()
		{
		}
    
        public SegmentSelectionSection SegmentSelectionSection
        {
            get
            {
                if (_segmentSelectionSection == null)
                {
                    _segmentSelectionSection = Formals.Create<SegmentSelectionSection>();
                    _segmentSelectionSection.HeightConstraint.Constant = 120;
                    _segmentSelectionSection.Label.Text = "Incident Type";
                    _segmentSelectionSection.Selector.RemoveAllSegments();
                    _segmentSelectionSection.Selector.InsertSegment("Noise", 0, false);
                    _segmentSelectionSection.Selector.InsertSegment("Parking", 1, false);
                    _segmentSelectionSection.Selector.InsertSegment("Visual Disturbance", 2, false);
                    _segmentSelectionSection.Selector.InsertSegment("Other", 3, false);
                }
                return _segmentSelectionSection;
            }
        }
    
     
        private SegmentSelectionSection _incidentReportTypeSegment;
        private TextViewSection _commentsSection;
        private PhotoGallerySection _photoSection;

        //        public new MaintenanceRequestFormViewModel ViewModel
        //        {
        //            get { return (MaintenanceRequestFormViewModel)base.ViewModel; }
        //            set { base.ViewModel = value; }
        //        }

     

        public override string Title => "Courtesy Officer";

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.LogoImage.Image = UIImage.FromBundle("MaintenaceIcon");
                    _headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
                    _headerSection.MainLabel.Text = "Report Incident";
                    _headerSection.SubLabel.Text = "Fill the information below";
                }
                return _headerSection;
            }
        }

        public SegmentSelectionSection IncidentReportTypeSegment
        {
            get
            {
                if (_incidentReportTypeSegment == null)
                {
                    _incidentReportTypeSegment = Formals.Create<SegmentSelectionSection>();
                    _incidentReportTypeSegment.Selector.RemoveAllSegments();
                    _incidentReportTypeSegment.HeightConstraint.Constant = 120;
                    _incidentReportTypeSegment.Editable = true;
                    _incidentReportTypeSegment.Selector.ControlStyle = UISegmentedControlStyle.Bezeled;
                }
                return _incidentReportTypeSegment;
            }
        }

        public TextViewSection CommentsSection
        {
            get
            {
                if (_commentsSection == null)
                {
                    _commentsSection = Formals.Create<TextViewSection>();
                    _commentsSection.HeightConstraint.Constant = 200;
                    _commentsSection.HeaderLabel.Text = "Details & Comments";
                    _commentsSection.SetEditable(true);
                }
                return _commentsSection;
            }
        }

        public PhotoGallerySection PhotoSection
        {
            get
            {
                if (_photoSection == null)
                {
                    _photoSection = Formals.Create<PhotoGallerySection>();
                }
                return _photoSection;
            }
        }


  
        public override void BindForm()
        {
            base.BindForm();

            var b = this.CreateBindingSet<IncidentReportFormView, IncidentReportFormViewModel>();

            IncidentReportTypeSegment.BindTo(ViewModel.IncidentReportTypes, s => s.Title, s => ViewModel.SelectIncidentReportTypeId = s.Id, 0);
            b.Bind(SegmentSelectionSection.Selector).For(s => s.SelectedSegment).To(vm => vm.SelectIncidentReportTypeId);


            //Comments Section

            b.Bind(CommentsSection.TextView).For(v => v.Text).TwoWay().To(vm => vm.Comments);

            //Photo Section

            PhotoSection.BindViewModel(ViewModel.Photos);
            b.Apply();

        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(IncidentReportTypeSegment);
            content.Add(CommentsSection);
            content.Add(PhotoSection);
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem
                ("Done",
                UIBarButtonItemStyle.Plain,
                (sender, args) => ViewModel.DoneCommand.Execute(null)),
                true);

        }
        
	}
}
