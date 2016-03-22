using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.iOS.Views;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.Sections.CollectionSections;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;
namespace ResidentAppCross.iOS
{
	[Register("IncidentReportFormView")]
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
        public override void GetContent(List<UIView> content)
	    {
	        base.GetContent(content);
           // content.Add(HeaderSection);
            content.Add(SegmentSelectionSection);

	    }
	}
}
