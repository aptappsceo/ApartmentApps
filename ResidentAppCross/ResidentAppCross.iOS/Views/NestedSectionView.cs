using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    [Register("NestedSectionView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    partial class NestedSectionView : BaseForm<NestedSectionsViewModel>
    {
        private ContainerSection _containerSection;
        private SegmentSelectionSection _incidentReportTypeSegment;
        private TextViewSection _commentsSection;
        private ContainerSection _containerSection2;
        public override string Title => "Inspection";


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

        public ContainerSection ContainerSection
        {
            get
            {
                if (_containerSection == null)
                {
                    _containerSection = Formals.Create<ContainerSection>();
                }
                return _containerSection;
            }
        }

        public ContainerSection ContainerSection2
        {
            get
            {
                if (_containerSection2 == null)
                {
                    _containerSection2 = Formals.Create<ContainerSection>();
                }
                return _containerSection2;
            } 
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            ContainerSection.Clear();
            ContainerSection.Add(IncidentReportTypeSegment);
            ContainerSection.Add(CommentsSection);
            ContainerSection.RefreshContent();
        
            content.Add(ContainerSection);
        }

    }
}
