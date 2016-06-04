using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.Resources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS.Views
{

    [Register("MessageDetailsView")]
    [NavbarStyling]
    [StatusBarStyling]
    public class MessageDetailsView : BaseForm<MessageDetailsViewModel>
    {
        private TextViewSection _subjectSection;
        private TextViewSection _dateSection;
        private TextViewSection _messageSection;

        public TextViewSection SubjectSection
        {
            get
            {
                if (_subjectSection == null)
                {
                    _subjectSection = Formals.Create<TextViewSection>();
                    _subjectSection.HeightConstraint.Constant = 100;
                    _subjectSection.TextView.Layer.BorderColor = new CGColor(1f,1f,1f);
                    _subjectSection.HeaderLabel.Text = "Subject";

                }
                return _subjectSection;
            }
            set { _subjectSection = value; }
        }

        public TextViewSection DateSection
        {
            get
            {
                if (_dateSection == null)
                {
                    _dateSection = Formals.Create<TextViewSection>();
                    _dateSection.HeightConstraint.Constant = 100;
                    _dateSection.TextView.Layer.BorderColor = new CGColor(1f, 1f, 1f);
                    _dateSection.HeaderLabel.Text = "Date";
                }
                return _dateSection;
            }
            set { _dateSection = value; }
        }

        public TextViewSection MessageSection
        {
            get
            {
                if (_messageSection == null)
                {
                    _messageSection = Formals.Create<TextViewSection>();
                    _messageSection.HeaderLabel.Text = "Message";
                    _messageSection.HeightConstraint.Constant = 300;


                }
                return _messageSection;
            }
            set { _messageSection = value; }
        }


        public override void BindForm()
        {
            base.BindForm();
            var set = this.CreateBindingSet<MessageDetailsView, MessageDetailsViewModel>();
            set.Bind(SubjectSection.TextView).For(f => f.Text).To(vm => vm.Subject);
            set.Bind(DateSection.TextView).For(f => f.Text).To(vm => vm.Date);
            set.Bind(MessageSection.TextView).For(f => f.Text).To(vm => vm.Message);
            set.Apply();
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(SubjectSection);
            content.Add(DateSection);
            content.Add(MessageSection);
        }

    }

    [Register("MaintenanceCheckinDetailsView")]
    [NavbarStyling]
    [StatusBarStyling]
    public class MaintenanceCheckinDetailsView : BaseForm<MaintenanceCheckinDetailsViewModel>
    {
        private HeaderSection _headerSection;
        private PhotoGallerySection _photosSection;
        private TextViewSection _commentsSection;

        public override string Title => "Maintenance";

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
            set { _headerSection = value; }
        }

        public PhotoGallerySection PhotosSection
        {
            get
            {
                if (_photosSection == null)
                {
                    _photosSection = Formals.Create<PhotoGallerySection>();
                    _photosSection.Editable = false;
                }
                return _photosSection;
            }
            set { _photosSection = value; }
        }

        public TextViewSection CommentsSection
        {
            get
            {
                if (_commentsSection == null)
                {
                    _commentsSection = Formals.Create<TextViewSection>();
                    _commentsSection.Editable = false;
                }
                return _commentsSection;
            }
            set { _commentsSection = value; }
        }

        public override void BindForm()
        {
            base.BindForm();
            var set = this.CreateBindingSet<MaintenanceCheckinDetailsView, MaintenanceCheckinDetailsViewModel>();
            set.Bind(CommentsSection.TextView).To(w => w.Checkin.Comments);
            set.Apply();
            PhotosSection.BindViewModel(ViewModel.CheckinPhotos);
            HeaderSection.MainLabel.Text = "Check In";
            HeaderSection.SubLabel.Text = $"State changed to {ViewModel.Checkin.StatusId}";
            HeaderSection.LogoImage.Image = AppTheme.GetTemplateIcon(MaintenanceRequestStyling.HeaderIconByStatus(ViewModel.Checkin.StatusId), SharedResources.Size.L);
            HeaderSection.LogoImage.TintColor = MaintenanceRequestStyling.ColorByStatus(ViewModel.Checkin.StatusId);
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(CommentsSection);
            content.Add(PhotosSection);
        }
    }

    [Register("IncidentReportCheckinDetailsView")]
    [NavbarStyling]
    [StatusBarStyling]
    public class IncidentReportCheckinDetailsView : BaseForm<IncidentReportCheckinDetailsViewModel>
    {
        private HeaderSection _headerSection;
        private PhotoGallerySection _photosSection;
        private TextViewSection _commentsSection;

        public override string Title => "Incident Report";

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    
                    _headerSection.MainLabel.Text = "Checkin";
                    _headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
                    _headerSection.SubLabel.Text = $"State -> {ViewModel.Checkin.StatusId}";
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
                    _photosSection = Formals.Create<PhotoGallerySection>();
                    _photosSection.Editable = false;
                }
                return _photosSection;
            }
            set { _photosSection = value; }
        }

        public TextViewSection CommentsSection
        {
            get
            {
                if (_commentsSection == null)
                {
                    _commentsSection = Formals.Create<TextViewSection>();
                    _commentsSection.HeaderLabel.Text = "Details";
                    _commentsSection.SetEditable(false);
                    _commentsSection.HeightConstraint.Constant = AppTheme.CommentsSectionHeight;
                }
                return _commentsSection;
            }
            set { _commentsSection = value; }
        }

        public override void BindForm()
        {
            base.BindForm();
            var set = this.CreateBindingSet<IncidentReportCheckinDetailsView, IncidentReportCheckinDetailsViewModel>();
            set.Bind(CommentsSection.TextView).To(w => w.Checkin.Comments);
            set.Apply();
            PhotosSection.BindViewModel(ViewModel.CheckinPhotos);

            _headerSection.LogoImage.Image = AppTheme.GetTemplateIcon(IncidentReportStyling.HeaderIconByStatus(ViewModel.Checkin.StatusId), SharedResources.Size.L);
            _headerSection.LogoImage.TintColor = IncidentReportStyling.ColorByStatus(ViewModel.Checkin.StatusId);

        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(CommentsSection);
            content.Add(PhotosSection);
        }
    }

}
