using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentApps.Client.Models;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform.iOS;
using ObjCRuntime;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.Resources;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;
using SharpMobileCode.ModalPicker;
using UIKit;
using ZXing;
using ZXing.Mobile;
using ZXing.QrCode.Internal;
using MaintenanceRequestStatus = ResidentAppCross.ViewModels.Screens.MaintenanceRequestStatus;

namespace ResidentAppCross.iOS
{
    [Register("IncidentReportStatusView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class IncidentReportStatusView : BaseForm<IncidentReportStatusViewModel>
    {

        public IncidentReportStatusView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public IncidentReportStatusView()
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
        private UITabBar _typeSelectionSection;
        private TableSection _tableSection;
        private Dictionary<string, UIImage> _historyStatusImages;

        public override string Title => "Incident Details";

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

        public UITabBar TabSection
        {
            get
            {
                if (_typeSelectionSection == null)
                {
                    _typeSelectionSection = new UITabBar().WithHeight(49, 1000);
                    _typeSelectionSection.BarStyle = UIBarStyle.BlackOpaque;
                    _typeSelectionSection.TranslatesAutoresizingMaskIntoConstraints = false;
                    _typeSelectionSection.BarTintColor = AppTheme.SecondaryBackgoundColor;
                  //  _typeSelectionSection.SelectedImageTintColor = UIColor.White;
                    _typeSelectionSection.TintColor = UIColor.White;
                }
                return _typeSelectionSection;
            }
        }

        public LabelWithButtonSection UnitSection
        {
            get
            {
                if (_scheduleSection == null)
                {
                    _scheduleSection = Formals.Create<LabelWithButtonSection>();
                    _scheduleSection.Label.Text = "Unit";
                }
                return _scheduleSection;
            }
        }


        public TextViewSection CommentsSection
        {
            get
            {
                if (_commentsSection == null)
                {
                    _commentsSection = Formals.Create<TextViewSection>();
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
                        "Do you give a permission for the officer to enter your apartment when you are not at home?";
                    _entrancePermissionSection.Editable = false;

                }
                return _entrancePermissionSection;
            }
        }

        public TenantDataSection TenantDataSection
        {
            get
            {
                if (_tenantDataSection == null)
                {
                    _tenantDataSection = Formals.Create<TenantDataSection>();
                    _tenantDataSection.TenantAvatar.Image = UIImage.FromFile("avatar-placeholder.png");
                }
                return _tenantDataSection;
            }
        }

        public Dictionary<string, UIImage> HistoryStatusImages
        {
            get { return _historyStatusImages ?? (_historyStatusImages = new Dictionary<string, UIImage>()); }
            set { _historyStatusImages = value; }
        }

        public UIImage GetHistoryImageByStatus(string status)
        {
            UIImage img;
            if (!HistoryStatusImages.TryGetValue(status, out img))
            {
                img =
                    HistoryStatusImages[status] =
                        AppTheme.GetTemplateIcon(IncidentReportStyling.StateIconByStatus(status),
                            SharedResources.Size.S,true);
            }
            return img;
        }


        public TableSection CheckinsSection
        {
            get
            {
                if (_tableSection == null)
                {
                    _tableSection = Formals.Create<TableSection>(); //Create as usually. 

                    var tlEmpty = AppTheme.GetTemplateIcon(SharedResources.Icons.Empty, SharedResources.Size.S, true);
                    var tlTop = AppTheme.GetTemplateIcon(SharedResources.Icons.TimelineTop, SharedResources.Size.S, true);
                    var tlBottom = AppTheme.GetTemplateIcon(SharedResources.Icons.TimelineBottom, SharedResources.Size.S, true);
                    var tlMid = AppTheme.GetTemplateIcon(SharedResources.Icons.TimelineMiddle, SharedResources.Size.S, true);
                    var circleIcon = AppTheme.GetTemplateIcon(SharedResources.Icons.Circle, SharedResources.Size.S, true);

                    var tableDataBinding = new TableDataBinding<HistoryItemCell, IncidentCheckinBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.MainLabel.Text = item.StatusId;
                            cell.DateLabel.Text = item.Date?.ToString("g");

                            if (ViewModel.Checkins.Count == 1)
                                cell.IconView.Image = tlEmpty;
                            else if (index == 0)
                                cell.IconView.Image = tlTop;
                            else if (index == ViewModel.Checkins.Count - 1)
                                cell.IconView.Image = tlBottom;
                            else
                                cell.IconView.Image = tlMid;

                            cell.TintColor = AppTheme.SecondaryBackgoundColor;



                            //                            cell.IconView.SetLayer(AppTheme.GetTemplateIcon(MaintenanceRequestStyling.StateIconByStatus(item.StatusId), SharedResources.Size.S),
                            //                                MaintenanceRequestStyling.ColorByStatus(item.StatusId),12f,12f);
                            var backgroundPad = index == 0 ? 6f : 10f;
                            var iconPad = index == 0 ? 12f : 16f;
                            cell.IconView.SetBackgroundLayer(circleIcon, IncidentReportStyling.ColorByStatus(item.StatusId), backgroundPad, backgroundPad);
                            cell.IconView.SetBackgroundRounded(AppTheme.SecondaryBackgoundColor);
                            cell.IconView.SetIconLayerLayer(GetHistoryImageByStatus(item.StatusId), UIColor.White, iconPad, iconPad);
                        },
                        ItemSelected = item =>
                        {
                            ViewModel.SelectedCheckin = item;
                            ViewModel.ShowCheckinDetailsCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new HistoryItemCell("UITableViewCell_IncidentDetailsCheckinsTable"), //Define how to create cell, if reusables not found
                        CellIdentifier = "UITableViewCell_IncidentDetailsCheckinsTable"
                    };


                    var source = new GenericTableSource()
                    {
                        Items = ViewModel.Checkins, //Deliver data
                        Binding = tableDataBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true
                    };

                    _tableSection.Table.SeparatorStyle = UITableViewCellSeparatorStyle.None;

                    _tableSection.Table.AllowsSelection = true; //Step 1. Look at the end of BindForm method for step 2
                    _tableSection.Source = source;
                    _tableSection.ReloadData();

                }
                return _tableSection;
            }
        }

        public UIButton FooterPauseButton { get; set; }
        public UIButton FooterFinishButton { get; set; }
        public UIButton FooterStartButton { get; set; }

        public void UpdateFooter()
        {
            FooterFinishButton.Hidden = !ViewModel.CloseIncidentCommand.CanExecute(null);
            FooterPauseButton.Hidden = !ViewModel.PauseIncidentCommmand.CanExecute(null); 
            FooterStartButton.Hidden = !ViewModel.OpenIncidentCommand.CanExecute(null); 
        }


        public override void BindForm()
        {
            base.BindForm();
            //UnitSection.Label.Text = "Report Date";
       

            this.OnViewModelEventMainThread<IncidentReportStatusUpdated>(_ =>
            {
                if (ViewModel.Request != null)
                {
                    HeaderSection.LogoImage.Image = AppTheme.GetTemplateIcon(IncidentReportStyling.HeaderIconByStatus(ViewModel.Request.Status),SharedResources.Size.L);
                    HeaderSection.LogoImage.TintColor = IncidentReportStyling.ColorByStatus(ViewModel.Request.Status);
                    if (!string.IsNullOrEmpty(ViewModel.Request.Requester.ImageUrl))
                    {
                        TenantDataSection.TenantAvatar.SetImageWithAsyncIndicator(ViewModel.Request.Requester.ImageUrl,
                            UIImage.FromFile("avatar-placeholder.png"));
                    }
                    else
                    {
                        TenantDataSection.TenantAvatar.Image = UIImage.FromFile("avatar-placeholder.png");
                    }

                }
                CheckinsSection.ReloadData();
                RefreshContent();
                UpdateFooter();
            });


            var b = this.CreateBindingSet<IncidentReportStatusView, IncidentReportStatusViewModel>();




            //Schedule Section
            b.Bind(UnitSection.Button).For("Title").To(vm => vm.Request.UnitName);
            if (this.ViewModel.CanUpdateRequest)
                b.Bind(UnitSection.Button).To(vm => vm.SetUnitCommand);
            //Footer Section

            var style = new UIViewStyle()
            {
                BackgroundColor = AppTheme.SecondaryBackgoundColor,
                ForegroundColor = AppTheme.SecondaryForegroundColor,
                FontSize = 23.0f
            };

				FooterPauseButton = FooterSection.AddButton("Pause", style);
				FooterFinishButton = FooterSection.AddButton("Close", style);
				FooterStartButton = FooterSection.AddButton("Open", style);

          



            //Comments section

            CommentsSection.SetEditable(false);
            b.Bind(CommentsSection.TextView).For(c => c.Text).To(vm => vm.Request.Comments);

            //Photo Section
            PhotoSection.Editable = false;
            PhotoSection.BindViewModel(ViewModel.Photos);

            //Header section

            b.Bind(HeaderSection.MainLabel).For(l => l.Text).To(vm => vm.Request.IncidentType);
            b.Bind(HeaderSection.SubLabel).For(l => l.Text).To(vm => vm.Request.Status);

            //Tenant section
            b.Bind(TenantDataSection.TenantNameLabel).For(t => t.Text).To(vm => vm.Request.Requester.FullName);
            b.Bind(TenantDataSection.AddressLabel).For(t => t.Text).To(vm => vm.Request.BuildingName);
            b.Bind(TenantDataSection.PhoneLabel).For(t => t.Text).To(vm => vm.Request.Requester.PhoneNumber);

            //Date section
            //b.Bind(UnitSection.Button).To(vm => vm.ScheduleCommand);


            //b.Bind(TenantDataSection.AddressLabel).For(t => t.Text).To(vm => vm.UnitAddressString);
            //b.Bind(TenantDataSection.PhoneLabel).For(t => t.Text).To(vm => vm.Request.TenantPhone)
            //b.Bind(TenantDataSection.TenantAvatar)

            //Entrance Permission section

            //b.Bind(EntrancePermissionSection.Switch).For(s => s.On).To(vm => vm.Request.EntrancePermission);
            if (ViewModel.CanUpdateRequest)
            {
            FooterPauseButton.TouchUpInside += (sender, args) => ViewModel.PauseIncidentCommmand.Execute(null);
            FooterFinishButton.TouchUpInside += (sender, args) => ViewModel.CloseIncidentCommand.Execute(null);
            FooterStartButton.TouchUpInside += (sender, args) => ViewModel.OpenIncidentCommand.Execute(null);
            //this.DelayBind(() =>
            //{
            //    b.Bind(FooterPauseButton).To(vm => vm.PauseIncidentCommmand);
            //    b.Bind(FooterFinishButton).To(vm => vm.CloseIncidentCommand);
            //    b.Bind(FooterStartButton).To(vm => vm.OpenIncidentCommand);
            //});
              
            }


            b.Apply();


            TabSection.BindTo(new List<IncidentReportStatusDisplayMode>() { IncidentReportStatusDisplayMode.Status, IncidentReportStatusDisplayMode.History }, i => i.ToString(), i =>
            {
                switch (i)
                {
                    case IncidentReportStatusDisplayMode.Status:
                        return SharedResources.Icons.Details;
                    case IncidentReportStatusDisplayMode.History:
                        return SharedResources.Icons.Past;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i), i, null);
                }
            }, i => null,
              i =>
              {
                  this.DisplayMode = i;
                  RefreshContent();
              }, IncidentReportStatusDisplayMode.Status);

            //ViewModel.PropertyChanged += (sender, args) =>
            //{
            //    if (args.PropertyName == "Request")
            //    {
            //        this.OnRequestChanged(ViewModel.Request);
            //    }
            //};

            //OnRequestChanged(ViewModel.Request);
            // SelectRepairDateButton.TouchUpInside += ShowScheduleDatePicker;
            // FooterStartButton.TouchUpInside += (sender, args) => PushScannerViewController(() => ViewModel.StartOrResumeCommand.Execute(null));

            //  FooterFinishButton.TouchUpInside += (sender, args) => PushScannerViewController(() => ViewModel.CloseIncidentCommand.Execute(null));

            // ViewModel.Photos.RawImages.CollectionChanged += RawImages_CollectionChanged;
        }

        public IncidentReportStatusDisplayMode DisplayMode { get; set; }

        public override UIView FooterView => TabSection;

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            this.ScrollRectToVisible(new CGRect(0, 0, 0, 0));

            if (DisplayMode == IncidentReportStatusDisplayMode.Status)
            {
                SectionContainerGesturesEnabled = true;
                content.Add(HeaderSection);
                content.Add(UnitSection);
                content.Add(TenantDataSection);
                content.Add(CommentsSection);
                content.Add(PhotoSection);
                //content.Add(EntrancePermissionSection);

                if (!FooterFinishButton.Hidden || !FooterPauseButton.Hidden || !FooterStartButton.Hidden)
                {
                    if (ViewModel.CanUpdateRequest)
                        content.Add(FooterSection);
                }
                    
            }
            else
            {
                SectionContainerGesturesEnabled = false;
                content.Add(CheckinsSection);
            }
        }

        public override void LayoutContent()
        {
            base.LayoutContent();
            if (DisplayMode == IncidentReportStatusDisplayMode.History)
            {
                SectionsContainer.AddConstraints(CheckinsSection.WithSameHeight(SectionsContainer));
            }
        }
    }
}
