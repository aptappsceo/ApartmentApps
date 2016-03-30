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
using ResidentAppCross.ViewModels.Screens;
using UIKit;
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
	    private TableDataBinding<UITableViewCell, IncidentIndexBindingModel> _tableItemsBinding;
	    private TableDataBinding<UITableViewCell, IncidentIndexFilter> _tableFilterBinding;
	    private GenericTableSource _tableItemSource;
	    private GenericTableSource _tableFiltersSource;


	    public TableDataBinding<UITableViewCell, IncidentIndexBindingModel> TableItemsBinding
        {
            get
            {
                if (_tableItemsBinding == null)
                {
                    _tableItemsBinding = new TableDataBinding<UITableViewCell, IncidentIndexBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.TextLabel.Text = item.Title;
                            cell.DetailTextLabel.Text = item.Comments;
                            cell.ImageView.Image = UIImage.FromBundle("OfficerIcon");
                            cell.TextLabel.MinimumScaleFactor = 0.2f;
                        },
                        ItemSelected = item =>
                        {
                            ViewModel.SelectedIncident = item;
                            ViewModel.OpenSelectedIncidentCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCell_IncidentIndexItemsTable"), //Define how to create cell, if reusables not found
                        CellIdentifier = "UITableViewCell_IncidentIndexItemsTable"
                    };
                }
                return _tableItemsBinding;
            }
            set { _tableItemsBinding = value; }
        }

        public TableDataBinding<UITableViewCell, IncidentIndexFilter> TableFilterBinding
        {
            get
            {
                if (_tableFilterBinding == null)
                {
                    _tableFilterBinding = new TableDataBinding<UITableViewCell, IncidentIndexFilter>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.TextLabel.Text = $"{item.Title} ({ViewModel.Incidents.Count(r => item.FilterExpression(r))})";
                            cell.ImageView.Image = UIImage.FromBundle("MaintenaceIcon");
                            cell.TextLabel.MinimumScaleFactor = 0.2f;
                        },
                        ItemSelected = item =>
                        {
                            ViewModel.CurrentFilter = item;
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCell_IncidentIndexFiltersTable"),
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
}
