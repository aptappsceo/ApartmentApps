using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentApps.Client.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform.iOS;
using ObjCRuntime;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;
using SharpMobileCode.ModalPicker;
using UIKit;
using ZXing;
using ZXing.Mobile;
using ZXing.QrCode.Internal;

namespace ResidentAppCross.iOS
{

    [Register("MaintenanceRequestStatusView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class MaintenanceRequestStatusView : BaseForm<MaintenanceRequestStatusViewModel>
    {

        public MaintenanceRequestStatusView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public MaintenanceRequestStatusView()
        {
        }

        private HeaderSection _headerSection;
        private LabelWithButtonSection _scheduleSection;
        private ButtonToolbarSection _footerSection;
        private TextViewSection _commentsSection;
        private PhotoGallerySection _photoSection;
        private SegmentSelectionSection _petStatusSection;
        private ToggleSection _entrancePermissionSection;
        private TenantDataSection _tenantDataSection;

        public override string Title => "Maintenance Request";

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.LogoImage.Image = UIImage.FromBundle("MaintenaceIcon");
                    _headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
                }
                return _headerSection;
            }
        }

        public LabelWithButtonSection ScheduleSection
        {
            get
            {
                if (_scheduleSection == null)
                {
                    _scheduleSection = Formals.Create<LabelWithButtonSection>();
                    _scheduleSection.Label.Text = "Repair Date";
                    _scheduleSection.HeightConstraint.Constant = 60;
                }
                return _scheduleSection;
            }
        }

        public SegmentSelectionSection PetStatusSection
        {
            get
            {
                if (_petStatusSection == null)
                {
                    _petStatusSection = Formals.Create<SegmentSelectionSection>();
                    _petStatusSection.Selector.RemoveAllSegments();
                    _petStatusSection.HeightConstraint.Constant = 120;
                    _petStatusSection.Editable = false;
                    _petStatusSection.Selector.ControlStyle = UISegmentedControlStyle.Bezeled;
                }
                return _petStatusSection;
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

        public ButtonToolbarSection FooterSection
        {
            get
            {
                if (_footerSection == null)
                {
                    _footerSection = Formals.Create<ButtonToolbarSection>();
                    _footerSection.HeightConstraint.Constant = 120;
                }
                return _footerSection;
            }
        }

        public ToggleSection EntrancePermissionSection
        {
            get
            {
                if (_entrancePermissionSection == null)
                {
                    _entrancePermissionSection = Formals.Create<ToggleSection>();
                    _entrancePermissionSection.HeaderLabel.Text = "Permission To Enter";
                    _entrancePermissionSection.SubHeaderLabel.Text =
                        "Do you give a permission for tech guys to enter your apartment when you are not at home?";
                    _entrancePermissionSection.HeightConstraint.Constant = 160;
                    _entrancePermissionSection.Editable = false;

                }
                return _entrancePermissionSection;
            }
        }

        public TenantDataSection TenantDataSection
        {
            get
            {
                if(_tenantDataSection == null)
                {
                    _tenantDataSection = Formals.Create<TenantDataSection>();
                    _tenantDataSection.HeaderLabel.Text = "Unit Information";
                    _tenantDataSection.AddressLabel.Text = "795 E DRAGRAM TUCSON AZ 85705 USA";
                    _tenantDataSection.PhoneLabel.Text = "+1 777 777 777";
                    _tenantDataSection.TenantAvatar.Image = UIImage.FromBundle("OfficerIcon");

                    _tenantDataSection.HeightConstraint.Constant = 270;;
                }
                return _tenantDataSection;
            }
        }

        public UIButton FooterPauseButton { get; set; }
        public UIButton FooterFinishButton { get; set; }
        public UIButton FooterStartButton { get; set; }

        public void UpdateFooter()
        {
            var status = ViewModel.CurrentRequestStatus;
            FooterFinishButton.Hidden = status == RequestStatus.Started;
            FooterPauseButton.Hidden = status == RequestStatus.Started;
            FooterStartButton.Hidden = status != RequestStatus.Started;
        }

        public void OnRequestChanged(MaintenanceBindingModel request)
        {

        }

        public override void BindForm()
        {
            base.BindForm();
            var b = this.CreateBindingSet<MaintenanceRequestStatusView, MaintenanceRequestStatusViewModel>();




            //Schedule Section
            b.Bind(ScheduleSection.Button).For("Title").To(vm => vm.SelectScheduleDateActionLabel);
            
            //Footer Section

            var style = new UIViewStyle()
            {
                BackgroundColor = AppTheme.SecondaryBackgoundColor,
                ForegroundColor = AppTheme.SecondaryForegroundColor,
                FontSize = 23.0f
            };

          
            FooterPauseButton = FooterSection.AddButton("Pause", style);
            FooterFinishButton = FooterSection.AddButton("Finish", style);
            FooterStartButton = FooterSection.AddButton("Scan QR Code", style);

            b.Bind(FooterPauseButton).To(vm => vm.PauseCommmand);
            b.Bind(FooterFinishButton).To(vm => vm.FinishCommmand);
            b.Bind(FooterStartButton).To(vm => vm.ScanAndStartCommand);

            b.Bind(FooterFinishButton).For(but => but.Hidden).To(vm => vm.ForbidComplete);
            b.Bind(FooterStartButton).For(but => but.Hidden).To(vm => vm.ForbidStart);
            b.Bind(FooterPauseButton).For(but => but.Hidden).To(vm => vm.ForbidPause);

            //Comments section

            CommentsSection.SetEditable(false);
            b.Bind(CommentsSection.TextView).For(c=>c.Text).To(vm => vm.Request.Message);

            //Photo Section
            PhotoSection.Editable = false;
            PhotoSection.BindViewModel(ViewModel.Photos);
            
            //Header section

            b.Bind(HeaderSection.MainLabel).For(l => l.Text).To(vm => vm.Request.Name);
            b.Bind(HeaderSection.SubLabel).For(l => l.Text).To(vm => vm.Request.Status);

            //Pet section
            PetStatusSection.BindTo(ViewModel.PetStatuses,p=>p.Title,p=> {},0);
            b.Bind(PetStatusSection.Selector).For(s => s.SelectedSegment).To(vm => vm.Request.PetStatus);


            //Tenant section

            b.Bind(TenantDataSection.TenantNameLabel).For(t => t.Text).To(vm => vm.Request.TenantFullName);

            //Date section
            b.Bind(ScheduleSection.Button).To(vm => vm.ScheduleCommand);


            //b.Bind(TenantDataSection.AddressLabel).For(t => t.Text).To(vm => vm.UnitAddressString);
            //b.Bind(TenantDataSection.PhoneLabel).For(t => t.Text).To(vm => vm.Request.TenantPhone)
            //b.Bind(TenantDataSection.TenantAvatar)

            //Entrance Permission section

            //b.Bind(EntrancePermissionSection.Switch).For(s => s.On).To(vm => vm.Request.EntrancePermission);


            b.Apply();




            ViewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Request")
                {
                    this.OnRequestChanged(ViewModel.Request);
                }
            };

            OnRequestChanged(ViewModel.Request);
            // SelectRepairDateButton.TouchUpInside += ShowScheduleDatePicker;
            // FooterStartButton.TouchUpInside += (sender, args) => PushScannerViewController(() => ViewModel.StartOrResumeCommand.Execute(null));

            //  FooterFinishButton.TouchUpInside += (sender, args) => PushScannerViewController(() => ViewModel.FinishCommmand.Execute(null));

            // ViewModel.Photos.RawImages.CollectionChanged += RawImages_CollectionChanged;
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(ScheduleSection);
            content.Add(TenantDataSection);
            content.Add(CommentsSection);
            content.Add(PhotoSection);
            content.Add(PetStatusSection);
            content.Add(EntrancePermissionSection);
            content.Add(FooterSection);
        }

        
    }
}
