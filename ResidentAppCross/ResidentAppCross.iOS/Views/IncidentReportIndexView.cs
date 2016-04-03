using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ApartmentApps.Client.Models;
using Cirrious.FluentLayouts.Touch;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.iOS.Views;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.Sections.CollectionSections;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.Resources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;
using MaintenanceRequestStatus = ResidentAppCross.ViewModels.Screens.MaintenanceRequestStatus;

namespace ResidentAppCross.iOS
{
	
	[Register("IncidentReportIndexView")]
	[NavbarStyling]
	[StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
	partial class IncidentReportIndexView : BaseForm<IncidentReportIndexViewModel>
	{

        private TableSection _tableSection;
        private SegmentSelectionSection _filterSection;
        private CallToActionSection _callToActionSection;
	    private TableDataBinding<TicketItemCell, IncidentIndexBindingModel> _tableItemsBinding;
	    private TableDataBinding<FilterTableCell, IncidentIndexFilter> _tableFilterBinding;
	    private GenericTableSource _tableItemSource;
	    private GenericTableSource _tableFiltersSource;
	    private Dictionary<string, UIImage> _statusImages;


	    public override string Title => "Incident Reports";


        public Dictionary<string, UIImage> StatusImages
        {
            get { return _statusImages ?? (_statusImages = new Dictionary<string, UIImage>()); }
            set { _statusImages = value; }
        }

        public UIImage GetImageByStatus(string status)
        {
            UIImage img;
            if (!StatusImages.TryGetValue(status, out img))
            {
                img =
                    StatusImages[status] =
                        AppTheme.GetTemplateIcon(IncidentReportStyling.ListIconByStatus(status),
                            SharedResources.Size.S);
            }
            return img;
        }


        public TableDataBinding<TicketItemCell, IncidentIndexBindingModel> TableItemsBinding
        {
            get
            {
                if (_tableItemsBinding == null)
                {
                    _tableItemsBinding = new TableDataBinding<TicketItemCell, IncidentIndexBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.MainLabel.Text = "Unit " + item.UnitName;

                            cell.SubLabel.Text = $"{item.Title}";

                            if (!string.IsNullOrEmpty(item.LatestCheckin.Comments.Trim()))
                            {
                                cell.NotesLabel.Text = $"{item.StatusId}: {item.LatestCheckin.Comments}";
                            }
                            else
                            {
                                cell.NotesLabel.Text = $"{item.StatusId} with no comments";
                            }

                            cell.IconView.Image = GetImageByStatus(item.StatusId);
                            cell.IconView.TintColor = IncidentReportStyling.ColorByStatus(item.StatusId);
                            cell.DateLabel.Text = item.LatestCheckin?.Date?.ToString("g");
                        },
                        CellHeight = (item, index) => { return TicketItemCell.FullHeight; },
                        ItemSelected = item =>
                        {
                            ViewModel.SelectedIncident = item;
                            ViewModel.OpenSelectedIncidentCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new TicketItemCell("UITableViewCell_IncidentIndexItemsTable"), //Define how to create cell, if reusables not found
                        CellIdentifier = "UITableViewCell_IncidentIndexItemsTable"
                    };
                }
                return _tableItemsBinding;
            }
            set { _tableItemsBinding = value; }
        }

        public TableDataBinding<FilterTableCell, IncidentIndexFilter> TableFilterBinding
        {
            get
            {
                if (_tableFilterBinding == null)
                {
                    _tableFilterBinding = new TableDataBinding<FilterTableCell, IncidentIndexFilter>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.MainLabel.Text = $"{item.Title} ({ViewModel.Incidents.Count(r => item.FilterExpression(r))})";
                            cell.IconView.Image = AppTheme.GetTemplateIcon(item.Icon, SharedResources.Size.S);
                            cell.IconView.TintColor = AppTheme.PrimaryIconColor;
                        },
                        ItemSelected = item =>
                        {
                            ViewModel.CurrentFilter = item;
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new FilterTableCell("UITableViewCell_IncidentIndexFiltersTable"),
                        CellIdentifier = "UITableViewCell_IncidentIndexFiltersTable" //Define how to create cell, if reusables not found
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
                        Items = ViewModel.FilteredIncidents, //Deliver data
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
                    _callToActionSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;

                }
                return _callToActionSection;
            }
        }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            ViewModel.UpdateIncidentsCommand.Execute(null);

        }

        public override void BindForm()
        {
            base.BindForm();


            this.OnViewModelEventMainThread<IncidentsIndexFiltersUpdatedEvent>(_ =>
            {             
                    if (ViewModel.CurrentFilter != null) SetTableToDisplayItems();
                    else SetTableToDisplayFilters();
            });

            this.OnViewModelEventMainThread<IncidentsIndexUpdateStarted>(_ =>
            {
                TableSection.SetLoading(true);
            });

            this.OnViewModelEventMainThread<IncidentsIndexUpdateFinished>(_ =>
            {
                TableSection.SetLoading(false);
            });



            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem
              (
                  UIBarButtonSystemItem.Add,
                  (sender, args) =>
                  {
                      ViewModel.OpenIncidentReportFormCommand.Execute(null);
                  }),
              true);


            NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem
               (
               "Back", UIBarButtonItemStyle.Plain,
               (sender, args) =>
               {
                   if (ViewModel.CurrentFilter == null)
                       NavigationController.PopViewController(true);
                   else ViewModel.CurrentFilter = null;
               }), true);


            SectionContainerGesturesEnabled = false;
            SetTableToDisplayFilters();

        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(TableSection);
        }

        public void SetTableToDisplayFilters()
        {
            TableSection.Source = TableFiltersSource;
            TableSection.ReloadDataAnimated(UIViewAnimationOptions.TransitionCrossDissolve);
        }

        public void SetTableToDisplayItems()
        {

            TableSection.Source = TableItemSource;
            TableSection.ReloadDataAnimated(UIViewAnimationOptions.TransitionCrossDissolve);
        }

        //
        public override void LayoutContent()
        {

//            View.AddConstraints(
//                    FilterSection.AtTopOf(View),
//                    FilterSection.AtLeftOf(View),
//                    FilterSection.AtRightOf(View)
//                );
//
//            View.AddConstraints(
//                    TableSection.Below(FilterSection),
//                    TableSection.AtLeftOf(View),
//                    TableSection.AtRightOf(View)
//                );

            View.AddConstraints(
                    TableSection.AtTopOf(View),
                    TableSection.AtLeftOf(View),
                    TableSection.AtRightOf(View),
                    TableSection.AtBottomOf(View)
                );
        }
    }

    public static class IncidentReportStyling
    {
        public static SharedResources.Icons ListIconByStatus(string status)
        {
            IncidentReportStatus val;
            if (!Enum.TryParse(status, out val))
            {
                throw new Exception("Unrecognized Report Status: " + status);
            }
            return ListIconByStatus(val);
        }

        public static SharedResources.Icons ListIconByStatus(IncidentReportStatus val)
        {
            switch (val)
            {
                case IncidentReportStatus.Complete:
                    return SharedResources.Icons.CourtesyComplete;
                case IncidentReportStatus.Paused:
                    return SharedResources.Icons.CourtesyPaused;
                case IncidentReportStatus.Open:
                    return SharedResources.Icons.CourtesyInProgress;
                case IncidentReportStatus.Reported:
                    return SharedResources.Icons.CourtesyPending;
                default:
                    throw new ArgumentOutOfRangeException(nameof(val), val, null);
            }
        }

        public static SharedResources.Icons HeaderIconByStatus(string status)
        {
            IncidentReportStatus val;
            if (!Enum.TryParse(status, out val))
            {
                throw new Exception("Unrecognized Report Status: " + status);
            }
            return HeaderIconByStatus(val);
        }

        public static SharedResources.Icons HeaderIconByStatus(IncidentReportStatus val)
        {
            switch (val)
            {
                case IncidentReportStatus.Complete:
                    return SharedResources.Icons.PoliceOk;
                case IncidentReportStatus.Paused:
                    return SharedResources.Icons.PolicePause;
                case IncidentReportStatus.Open:
                    return SharedResources.Icons.PolicePlay;
                case IncidentReportStatus.Reported:
                    return SharedResources.Icons.PoliceExclamation;
                default:
                    throw new ArgumentOutOfRangeException(nameof(val), val, null);
            }
        }

        public static UIColor ColorByStatus(string status)
        {
            IncidentReportStatus val;
            if (!Enum.TryParse(status, out val))
            {
                throw new Exception("Unrecognized Report Status: " + status);
            }
            return ColorByStatus(val);
        }

        public static UIColor ColorByStatus(IncidentReportStatus val)
        {
            switch (val)
            {
                case IncidentReportStatus.Complete:
                    return AppTheme.CompleteColor;
                case IncidentReportStatus.Paused:
                    return AppTheme.PausedColor;
                case IncidentReportStatus.Open:
                    return AppTheme.InProgressColor;
                case IncidentReportStatus.Reported:
                    return AppTheme.PendingColor;
                default:
                    throw new ArgumentOutOfRangeException(nameof(val), val, null);
            }
        }
        public static SharedResources.Icons StateIconByStatus(string status)
        {
            IncidentReportStatus val;
            if (!Enum.TryParse(status, out val))
            {
                throw new Exception("Unrecognized Report Status: " + status);
            }
            return StateIconByStatus(val);
        }

        public static SharedResources.Icons StateIconByStatus(IncidentReportStatus val)
        {
            switch (val)
            {
                case IncidentReportStatus.Complete:
                    return SharedResources.Icons.Ok;
                case IncidentReportStatus.Paused:
                    return SharedResources.Icons.Pause;
                case IncidentReportStatus.Open:
                    return SharedResources.Icons.Play;
                case IncidentReportStatus.Reported:
                    return SharedResources.Icons.QuestionMark;
                default:
                    throw new ArgumentOutOfRangeException(nameof(val), val, null);
            }
        }
    }
}
