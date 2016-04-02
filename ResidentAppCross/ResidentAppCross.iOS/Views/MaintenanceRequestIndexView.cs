using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ApartmentApps.Client.Models;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.Resources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;
using MaintenanceRequestStatus = ResidentAppCross.ViewModels.Screens.MaintenanceRequestStatus;

namespace ResidentAppCross.iOS.Views
{
    [Register("MaintenanceRequestIndexView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public class MaintenanceRequestIndexView : BaseForm<MaintenanceRequestIndexViewModel>
    {
        private TableSection _tableSection;
        private SegmentSelectionSection _filterSection;
        private CallToActionSection _callToActionSection;
        private TableDataBinding<TicketItemCell, MaintenanceIndexBindingModel> _tableItemsBinding;
        private TableDataBinding<FilterTableCell, RequestsIndexFilter> _tableFilterBinding;
        private GenericTableSource _tableItemSource;
        private GenericTableSource _tableFiltersSource;
        private Dictionary<string, UIImage> _statusImages;

        public override string Title => "Maintenance Requests";

        public Dictionary<string, UIImage> StatusImages
        {
            get { return _statusImages ?? (_statusImages = new Dictionary<string, UIImage>()); }
            set  { _statusImages = value; }
        }

        public UIImage GetImageByStatus(string status)
        {
            UIImage img;
            if (!StatusImages.TryGetValue(status, out img))
            {
                img =
                    StatusImages[status] =
                        AppTheme.GetTemplateIcon(MaintenanceRequestStyling.ListIconByStatus(status),
                            SharedResources.Size.S);
            }
            return img;
        }


        public TableDataBinding<TicketItemCell, MaintenanceIndexBindingModel> TableItemsBinding
        {
            get
            {
                if (_tableItemsBinding == null)
                {
                    _tableItemsBinding = new TableDataBinding<TicketItemCell, MaintenanceIndexBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item,index) => //What to do when cell is created for item
                        {
                            cell.MainLabel.Text = "Unit 1234";

                            cell.SubLabel.Text = $"{item.Title}";

                            if (item.StatusId == "Scheduled")
                            {
                                cell.NotesLabel.Text = $"Scheduled for 28/1/2 12:00 PM";
                            }
                            else
                            {
                                cell.NotesLabel.Text = $"{item.StatusId} with no comments";
                            }

                            cell.IconView.Image = GetImageByStatus(item.StatusId);
                            cell.IconView.TintColor = MaintenanceRequestStyling.ColorByStatus(item.StatusId);
                            cell.DateLabel.Text = "24/1/2 6:64 PM";

                        },
                        CellHeight = (item, index) => { return TicketItemCell.FullHeight; },
                        ItemSelected = item =>
                        {
                            ViewModel.SelectedRequest = item;
                            ViewModel.OpenSelectedRequestCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new TicketItemCell("UITableViewCell_MaintenanceIndexItemsTable"), //Define how to create cell, if reusables not found
                        CellIdentifier = "UITableViewCell_MaintenanceIndexItemsTable"
                    };
                }
                return _tableItemsBinding;
            }
            set { _tableItemsBinding = value; }
        }

        public TableDataBinding<FilterTableCell, RequestsIndexFilter> TableFilterBinding
        {
            get
            {
                if (_tableFilterBinding == null)
                {
                    _tableFilterBinding = new TableDataBinding<FilterTableCell, RequestsIndexFilter>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.MainLabel.Text = $"{item.Title} ({ViewModel.Requests.Count(r => item.FilterExpression(r))})";
                            cell.IconView.Image = AppTheme.GetTemplateIcon(item.Icon, SharedResources.Size.S);
                            cell.IconView.TintColor = AppTheme.PrimaryIconColor;
                        },
                        ItemSelected = item => { ViewModel.CurrentFilter = item; }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new FilterTableCell("UITableViewCell_MaintenanceIndexFiltersTable"), CellIdentifier = "UITableViewCell_MaintenanceIndexFiltersTable" //Define how to create cell, if reusables not found
                    };
                }
                return _tableFilterBinding;
            }
            set { _tableFilterBinding = value; }
        }

        public GenericTableSource TableItemSource
        {
            get
            {
                if (_tableItemSource == null)
                {
                    _tableItemSource = new GenericTableSource()
                    {
                        Items = ViewModel.FilteredRequests, //Deliver data
                        Binding = TableItemsBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true
                    };
                }
                return _tableItemSource;
            }
            set { _tableItemSource = value; }
        }

        public GenericTableSource TableFiltersSource
        {
            get
            {
                if (_tableFiltersSource == null)
                {
                    _tableFiltersSource = new GenericTableSource()
                    {
                        Items = ViewModel.Filters, //Deliver data
                        Binding = TableFilterBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true
                    };
                }
                return _tableFiltersSource;
            }
            set { _tableFiltersSource = value; }
        }

        public TableSection TableSection
        {
            get
            {
                if (_tableSection == null)
                {
                    _tableSection = Formals.Create<TableSection>();
                    _tableSection.Table.AllowsSelection = true;
                    _tableSection.Source = TableFiltersSource;
                    _tableSection.Table.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
                    _tableSection.ReloadData();
                }
                return _tableSection;
            }
        }

        public CallToActionSection CallToActionSection
        {
            get
            {
                if (_callToActionSection == null)
                {
                    _callToActionSection = Formals.Create<CallToActionSection>();
                    _callToActionSection.MainButton.SetTitle("Scan QR Code", UIControlState.Normal);
                }
                return _callToActionSection;
            }
        }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            ViewModel.UpdateRequestsCommand.Execute(null);
        }

        public override void BindForm()
        {
            base.BindForm();
            View.BackgroundColor = AppTheme.DeepBackgroundColor;
            //Update table data when collection changes. Heads up for Main Thread!

            this.OnViewModelEventMainThread<RequestsIndexFiltersUpdatedEvent>(_ =>
            {
                if (ViewModel.CurrentFilter != null) SetTableToDisplayItems();
                else SetTableToDisplayFilters();
            });

            this.OnViewModelEventMainThread<RequestsIndexUpdateStarted>(_ => { TableSection.SetLoading(true); });
            this.OnViewModelEventMainThread<RequestsIndexUpdateFinished>(_ => { TableSection.SetLoading(false); });

            // Plus button to the top right
            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, args) => { ViewModel.OpenMaintenanceRequestFormCommand.Execute(null); }), true);

            SetTableToDisplayFilters();
            SectionContainerGesturesEnabled = false;
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(TableSection);
            //content.Add(CallToActionSection);
        }

        public void SetTableToDisplayFilters()
        {
            TableSection.Source = TableFiltersSource;
            TableSection.ReloadDataAnimated(UIViewAnimationOptions.TransitionCrossDissolve);
            NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem("Back", UIBarButtonItemStyle.Plain, GoBackButtonHandler), true);
        }

        public void SetTableToDisplayItems()
        {
            TableSection.Source = TableItemSource;
            TableSection.ReloadDataAnimated(UIViewAnimationOptions.TransitionCrossDissolve);
            NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem("Filters", UIBarButtonItemStyle.Plain, GoBackButtonHandler), true);
        }

        private void GoBackButtonHandler(object sender, EventArgs args)
        {
            if (ViewModel.CurrentFilter == null)
            {
                NavigationController.PopViewController(true);
                return;
            }
            ViewModel.CurrentFilter = null;
        }

//
        public override void LayoutContent()
        {
            View.AddConstraints(TableSection.AtTopOf(View), 
                TableSection.AtLeftOf(View), 
                TableSection.AtRightOf(View),
                TableSection.AtBottomOf(View));

            //View.AddConstraints(CallToActionSection.Below(TableSection), CallToActionSection.AtLeftOf(View), CallToActionSection.AtRightOf(View), CallToActionSection.AtBottomOf(View));
        }
    }


    public class FilterTableCell : UITableViewCell
    {
        public const string CellIdentifier = "FilterTableCell";

        public FilterTableCell(string cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            MainLabel = new UILabel(new CGRect(44 + 15f + 8f, 0, ContentView.Frame.Width, 44))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
            };

            IconView = new UIImageView(new CGRect(15f, 0, 44, 44).PadInside(6f, 6f));

            ContentView.AddSubview(MainLabel);
            ContentView.AddSubview(IconView);
        }

        public UILabel MainLabel { get; set; }
        public UIImageView IconView { get; set; }
    }

    public class TicketItemCell : UITableViewCell
    {
        public const string CellIdentifier = "TicketItemCell";

        public TicketItemCell(string cellId) : base(UITableViewCellStyle.Default, cellId)
        {

            float imageSize = 55f;
            float textualContentPadding = imageSize + 8f + 8f;
            var container = new UIView(ContentView.Frame)
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
            };

            ContentView.AddSubview(container);
            nfloat textualContentPaddingRight = 8f;
            var textualContentWith = container.Frame.Width - textualContentPadding - textualContentPaddingRight;
            MainLabel = new UILabel(new CGRect(textualContentPadding, 9, textualContentWith, 30f))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Font = AppFonts.CellHeader
            };


            SubLabel = new UILabel(new CGRect(textualContentPadding, 30 + 9, textualContentWith, 20f))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Font = AppFonts.CellDetails
            };

            NotesLabel = new UILabel(new CGRect(14f, 55 + 9, container.Frame.Width-14f-8f, 20f))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Font = AppFonts.CellNote,
                TextColor = UIColor.DarkGray,
                Alpha = 0.6f,

            };

            DateLabel = new UILabel(new CGRect(textualContentPadding, 9, textualContentWith, 30f))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Font = AppFonts.CellNote,
                TextColor = UIColor.DarkGray,
                Alpha = 0.6f,
                TextAlignment = UITextAlignment.Right
            };

            //            var uiImageView = new UIImageView(new CGRect(0, 13, 22, 22))
            //            {
            //                Image = AppTheme.GetIcon(SharedResources.Icons.Forward, SharedResources.Size.S),
            //                TintColor= AppTheme.SecondaryBackgoundColor,
            //                ContentMode = UIViewContentMode.ScaleAspectFit
            //            };
            //
            //            var accessoryContainer = new UIView(new CGRect(0, 0, 22, 75f))
            //            {
            //            };
            //            AccessoryView = accessoryContainer;
            //            accessoryContainer.Add(uiImageView);


            var uiImageView = new UIImageView(new CGRect(0, 0, 22, 22))
            {
                Image = AppTheme.GetTemplateIcon(SharedResources.Icons.Forward, SharedResources.Size.S),
                Alpha = 0.5f,
                TintColor= AppTheme.SecondaryBackgoundColor,
                ContentMode = UIViewContentMode.ScaleAspectFit
            };

            AccessoryView = uiImageView;


            IconView = new UILayeredIconView(new CGRect(8f, 9f, imageSize, imageSize).PadInside(6f, 6f));

         //   ContentView?.Shadow(UIColor.Black,new CGSize(2, 2),0.5f,2f);
         //   AccessoryView.BackgroundColor = UIColor.White;
            container.AddSubview(MainLabel);
            container.AddSubview(SubLabel);
            container.AddSubview(DateLabel);
            container.AddSubview(IconView);
            container.AddSubview(NotesLabel);
        }

        public UILabel NotesLabel { get; set; }

        public override UITableViewCellSelectionStyle SelectionStyle => UITableViewCellSelectionStyle.Blue;

        public UILabel MainLabel { get; set; }
        public UILayeredIconView IconView { get; set; }
        public UILabel SubLabel { get; set; }
        public UILabel DateLabel { get; set; }
        public static float FullHeight = 90f;
        public static float ReducedHeight = 75f;
    }


    public static class MaintenanceRequestStyling
    {
        public static SharedResources.Icons ListIconByStatus(string status)
        {
            MaintenanceRequestStatus val;
            if (!Enum.TryParse(status, out val))
            {
                throw new Exception("Unrecognized Maintenance Request Status: " + status);
            }
            return ListIconByStatus(val);
        }


        public static SharedResources.Icons ListIconByStatus(MaintenanceRequestStatus val)
        {
            switch (val)
            {
                case MaintenanceRequestStatus.Complete:
                    return SharedResources.Icons.MaintenanceComplete;
                case MaintenanceRequestStatus.Paused:
                    return SharedResources.Icons.MaintenancePaused;
                case MaintenanceRequestStatus.Scheduled:
                    return SharedResources.Icons.MaintenanceScheduled;
                case MaintenanceRequestStatus.Started:
                    return SharedResources.Icons.MaintenanceInProgress;
                case MaintenanceRequestStatus.Submitted:
                    return SharedResources.Icons.MaintenancePending;
                default:
                    throw new ArgumentOutOfRangeException(nameof(val), val, null);
            }
        }


        public static SharedResources.Icons HeaderIconByStatus(string status)
        {
            MaintenanceRequestStatus val;
            if (!Enum.TryParse(status, out val))
            {
                throw new Exception("Unrecognized Maintenance Request Status: " + status);
            }
            return HeaderIconByStatus(val);
        }


        public static SharedResources.Icons HeaderIconByStatus(MaintenanceRequestStatus val)
        {
            switch (val)
            {
                case MaintenanceRequestStatus.Complete:
                    return SharedResources.Icons.MaintenanceOk;
                case MaintenanceRequestStatus.Paused:
                    return SharedResources.Icons.MaintenancePause;
                case MaintenanceRequestStatus.Scheduled:
                    return SharedResources.Icons.MaintenanceCalendar;
                case MaintenanceRequestStatus.Started:
                    return SharedResources.Icons.MaintenancePlay;
                case MaintenanceRequestStatus.Submitted:
                    return SharedResources.Icons.MaintenanceExclamation;
                default:
                    throw new ArgumentOutOfRangeException(nameof(val), val, null);
            }
        }


        public static SharedResources.Icons StateIconByStatus(string status)
        {
            MaintenanceRequestStatus val;
            if (!Enum.TryParse(status, out val))
            {
                throw new Exception("Unrecognized Maintenance Request Status: " + status);
            }
            return StateIconByStatus(val);
        }

        public static SharedResources.Icons StateIconByStatus(MaintenanceRequestStatus val)
        {
            switch (val)
            {
                case MaintenanceRequestStatus.Complete:
                    return SharedResources.Icons.Ok;
                case MaintenanceRequestStatus.Paused:
                    return SharedResources.Icons.Pause;
                case MaintenanceRequestStatus.Scheduled:
                    return SharedResources.Icons.Calendar;
                case MaintenanceRequestStatus.Started:
                    return SharedResources.Icons.Play;
                case MaintenanceRequestStatus.Submitted:
                    return SharedResources.Icons.Comment;
                default:
                    throw new ArgumentOutOfRangeException(nameof(val), val, null);
            }
        }

        public static UIColor ColorByStatus(string status)
        {
            MaintenanceRequestStatus val;
            if (!Enum.TryParse(status, out val))
            {
                throw new Exception("Unrecognized Maintenance Request Status: " + status);
            }
            return ColorByStatus(val);
        }

        public static UIColor ColorByStatus(MaintenanceRequestStatus val)
        {
            switch (val)
            {
                case MaintenanceRequestStatus.Complete:
                    return AppTheme.CompleteColor;
                case MaintenanceRequestStatus.Paused:
                    return AppTheme.PausedColor;
                case MaintenanceRequestStatus.Scheduled:
                    return AppTheme.ScheduledColor;
                case MaintenanceRequestStatus.Started:
                    return AppTheme.InProgressColor;
                case MaintenanceRequestStatus.Submitted:
                    return AppTheme.PendingColor;
                default:
                    throw new ArgumentOutOfRangeException(nameof(val), val, null);
            }
        }
    }
}
