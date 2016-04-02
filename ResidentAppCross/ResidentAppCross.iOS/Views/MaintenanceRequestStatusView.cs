﻿using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Client.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using ResidentAppCross.Resources;
using SDWebImage;
using MaintenanceRequestStatus = ResidentAppCross.ViewModels.Screens.MaintenanceRequestStatus;

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
        private UITabBar _typeSelectionSection;
        private TableSection _tableSection;

        public override string Title => "Maintenance Request";

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
                    _typeSelectionSection = new UITabBar().WithHeight(49,1000);
                    _typeSelectionSection.BarStyle = UIBarStyle.BlackOpaque;
                    _typeSelectionSection.TranslatesAutoresizingMaskIntoConstraints = false;
                    _typeSelectionSection.BarTintColor = AppTheme.SecondaryBackgoundColor;
                    _typeSelectionSection.SelectedImageTintColor = UIColor.White;
                    _typeSelectionSection.TintColor = new UIColor(0.8f,0.8f,0.8f,1);
                }
                return _typeSelectionSection;
            }
        }

        public LabelWithButtonSection ScheduleSection
        {
            get
            {
                if (_scheduleSection == null)
                {
                    _scheduleSection = Formals.Create<LabelWithButtonSection>();
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
                    _petStatusSection.Editable = false;
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
                    _photoSection.Editable = false;
                }
                return _photoSection;
            }
        }

        public ButtonToolbarSection ActionsSection
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
                    _tenantDataSection.TenantAvatar.SetImageWithAsyncIndicator(ViewModel.TenantAvatarUrl,UIImage.FromFile("avatar-placeholder.png"));
                }
                return _tenantDataSection;
            }
        }

        public TableSection CheckinsSection
        {
            get
            {
                if (_tableSection == null)
                {
                    _tableSection = Formals.Create<TableSection>(); //Create as usually. 

                    var timelineUndefinedStatusIcon = UIImage.FromBundle("TimelineStatusIcon.png");
                    var timelineMidLine = UIImage.FromFile("TimelineMid.png");
                    var timelineStartLine = UIImage.FromFile("TimelineStart.png");
                    var timelineEndLine = UIImage.FromFile("TimelineEnd.png");

                    var tableDataBinding = new TableDataBinding<HistoryItemCell, MaintenanceCheckinBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.MainLabel.Text = item.StatusId;
                            cell.DateLabel.Text = item.Date?.ToString("g");

                            SharedResources.Icons timelineIconType;

                            if (ViewModel.Checkins.Count == 1)
                                timelineIconType = SharedResources.Icons.Empty;
                            else if (index == 0)
                                timelineIconType = SharedResources.Icons.TimelineTop;
                            else if (index == ViewModel.Checkins.Count - 1)
                                timelineIconType = SharedResources.Icons.TimelineBottom;
                            else
                                timelineIconType = SharedResources.Icons.TimelineMiddle; ;

                            cell.IconView.Image = AppTheme.GetTemplateIcon(timelineIconType, SharedResources.Size.S, true);
                            cell.TintColor = AppTheme.SecondaryBackgoundColor;

                            

                            //                            cell.IconView.SetLayer(AppTheme.GetTemplateIcon(MaintenanceRequestStyling.StateIconByStatus(item.StatusId), SharedResources.Size.S),
                            //                                MaintenanceRequestStyling.ColorByStatus(item.StatusId),12f,12f);
                            var backgroundPad = index == 0 ? 6f : 10f;
                            var iconPad = index == 0 ? 12f : 16f;
                            cell.IconView.SetBackgroundLayer(AppTheme.GetTemplateIcon(SharedResources.Icons.Circle, SharedResources.Size.S, true),
                                MaintenanceRequestStyling.ColorByStatus(item.StatusId), backgroundPad, backgroundPad);
                            cell.IconView.SetBackgroundRounded(AppTheme.SecondaryBackgoundColor);
                            cell.IconView.SetIconLayerLayer(AppTheme.GetTemplateIcon(MaintenanceRequestStyling.StateIconByStatus(item.StatusId), SharedResources.Size.S, true),
                                UIColor.White, iconPad, iconPad);




                        },
                        ItemSelected = item =>
                        {
                            ViewModel.SelectedCheckin = item;
                            ViewModel.ShowCheckinDetailsCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new HistoryItemCell("UITableViewCell_MaintenanceStatusCheckinsTable"), //Define how to create cell, if reusables not found
                        CellIdentifier = "UITableViewCell_MaintenanceStatusCheckinsTable"
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
            var status = ViewModel.CurrentMaintenanceRequestStatus;
            FooterFinishButton.Hidden = status == MaintenanceRequestStatus.Started;
            FooterPauseButton.Hidden = status == MaintenanceRequestStatus.Started;
            FooterStartButton.Hidden = status != MaintenanceRequestStatus.Started;
        }

        public void OnRequestChanged(MaintenanceBindingModel request)
        {
            if (request == null) return;
            HeaderSection.LogoImage.Image = AppTheme.GetTemplateIcon(MaintenanceRequestStyling.HeaderIconByStatus(ViewModel.Request.Status), SharedResources.Size.L);
            HeaderSection.LogoImage.TintColor = MaintenanceRequestStyling.ColorByStatus(ViewModel.Request.Status);
        }

        public override void BindForm()
        {
            base.BindForm();


            ScheduleSection.Label.Text = "Repair Date";
            EntrancePermissionSection.HeaderLabel.Text = "Permission To Enter";
            EntrancePermissionSection.SubHeaderLabel.Text =
                "Do you give a permission for tech guys to enter your apartment when you are not at home?";

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

          
            FooterPauseButton = ActionsSection.AddButton("Pause", style);
            FooterFinishButton = ActionsSection.AddButton("Finish", style);
            FooterStartButton = ActionsSection.AddButton("Scan QR Code", style);

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


            this.OnViewModelEvent<MaintenanceRequestStatusUpdated>(updated =>
            {
                InvokeOnMainThread(() =>
                {
                    RefreshContent();
                    CheckinsSection.ReloadData();
                });
            });

            TabSection.BindTo(new List<MaintenanceRequestStatusDisplayMode>() {MaintenanceRequestStatusDisplayMode.Status, MaintenanceRequestStatusDisplayMode.History},i=>i.ToString(),i=>"MaintenaceIcon",i=>null,
                i =>
                {
                    this.DisplayModel = i;
                      RefreshContent();
                }, MaintenanceRequestStatusDisplayMode.Status);


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

        public MaintenanceRequestStatusDisplayMode DisplayModel { get; set; }

        public override UIView FooterView => TabSection;

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            this.ScrollRectToVisible(new CGRect(0, 0, 0, 0));

            if (DisplayModel == MaintenanceRequestStatusDisplayMode.Status)
            {
                SectionContainerGesturesEnabled = true;
                content.Add(HeaderSection);
                content.Add(ScheduleSection);
                content.Add(TenantDataSection);
                content.Add(CommentsSection);
                content.Add(PhotoSection);
                content.Add(PetStatusSection);
                content.Add(EntrancePermissionSection);
                content.Add(ActionsSection);
            }
            else
            {
                SectionContainerGesturesEnabled = false;
                content.Add(CheckinsSection);
            }
            TenantDataSection.TenantAvatar.ToRounded(UIColor.DarkGray,4f);
        }

        public override void LayoutContent()
        {
            base.LayoutContent();
            if (DisplayModel == MaintenanceRequestStatusDisplayMode.History)
            {
                SectionsContainer.AddConstraints(CheckinsSection.WithSameHeight(SectionsContainer));
            }
        }
    }

    public class HistoryItemCell : UITableViewCell
    {
        public const string CellIdentifier = "HistoryItemCell";

        public HistoryItemCell(string cellId) : base(UITableViewCellStyle.Default, cellId)
        {

            float imageSize = 44f;
            float textualContentPadding = imageSize + 8f + 8f;
            var container = new UIView(ContentView.Frame)
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
            };

            ContentView.AddSubview(container);
            nfloat textualContentPaddingRight = 8f;
            var textualContentWith = container.Frame.Width - textualContentPadding - textualContentPaddingRight;

            MainLabel = new UILabel(new CGRect(textualContentPadding, 6, textualContentWith, 16f))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Font = AppFonts.CellDetails
            };

            DateLabel = new UILabel(new CGRect(textualContentPadding, 24, textualContentWith, 12f))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Font = AppFonts.CellNoteSmall,
                TextColor = UIColor.DarkGray,
                Alpha = 0.6f,
                TextAlignment = UITextAlignment.Left
            };

            var uiImageView = new UIImageView(new CGRect(0, 0, 22, 22))
            {
                Image = AppTheme.GetTemplateIcon(SharedResources.Icons.Forward, SharedResources.Size.S),
                TintColor = AppTheme.SecondaryBackgoundColor.ColorWithAlpha(0.5f),
                ContentMode = UIViewContentMode.ScaleAspectFit
            };

            AccessoryView = uiImageView;

            IconView = new UILayeredIconView(new CGRect(8f, 0f, imageSize, imageSize));

            container.AddSubview(MainLabel);
            container.AddSubview(DateLabel);
            container.AddSubview(IconView);
        }

        public override UITableViewCellSelectionStyle SelectionStyle => UITableViewCellSelectionStyle.Blue;


        public UILabel MainLabel { get; set; }
        public UILayeredIconView IconView { get; set; }
        public UILabel SubLabel { get; set; }
        public UILabel DateLabel { get; set; }
        public static float EstimatedHeight = 44f;
    }

}
