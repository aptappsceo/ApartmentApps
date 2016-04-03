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
using ResidentAppCross.Resources;
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

	    private HeaderSection _headerSection;

	    public IncidentReportFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
		{
		}

		public IncidentReportFormView()
		{
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
                    _incidentReportTypeSegment.Editable = true;
                    _incidentReportTypeSegment.Selector.ApportionsSegmentWidthsByContent = true;
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
                    _commentsSection.Editable = true;
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


            HeaderSection.LogoImage.Image = AppTheme.GetTemplateIcon(SharedResources.Icons.PolicePlus, SharedResources.Size.L);
            HeaderSection.LogoImage.TintColor = AppTheme.CreateColor;
            HeaderSection.MainLabel.Text = "Report Incident";
            HeaderSection.SubLabel.Text = "Fill the information below";
            IncidentReportTypeSegment.Label.Text = "Incident Type";

            var b = this.CreateBindingSet<IncidentReportFormView, IncidentReportFormViewModel>();

            IncidentReportTypeSegment.BindTo(ViewModel.IncidentReportTypes, s => s.Title, s => ViewModel.SelectIncidentReportTypeId = s.Id, 0);
            //b.Bind(SegmentSelectionSection.Selector).For(s => s.SelectedSegment).To(vm => vm.SelectIncidentReportTypeId);


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
