using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using ApartmentApps.Client.Models;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

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
        private TableDataBinding<UITableViewCell, MaintenanceIndexBindingModel> _tableItemsBinding;
        private TableDataBinding<UITableViewCell, RequestsIndexFilter> _tableFilterBinding;
        private GenericTableSource _tableItemSource;
        private GenericTableSource _tableFiltersSource;


        public TableDataBinding<UITableViewCell, MaintenanceIndexBindingModel> TableItemsBinding
        {
            get
            {
                if (_tableItemsBinding == null)
                {
                    _tableItemsBinding = new TableDataBinding<UITableViewCell, MaintenanceIndexBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item) => //What to do when cell is created for item
                        {
                            cell.TextLabel.Text = item.Title;
                            cell.DetailTextLabel.Text = item.Comments;
                            cell.ImageView.Image = UIImage.FromBundle("MaintenaceIcon");
                            cell.TextLabel.MinimumScaleFactor = 0.2f;

                        },
                        ItemSelected = item =>
                        {
                            ViewModel.SelectedRequest = item;
                            ViewModel.OpenSelectedRequestCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCell"), //Define how to create cell, if reusables not found
                    };
                }
                return _tableItemsBinding;
            }
            set { _tableItemsBinding = value; }
        }

        public TableDataBinding<UITableViewCell, RequestsIndexFilter> TableFilterBinding
        {
            get
            {
                if (_tableFilterBinding == null)
                {
                    _tableFilterBinding = new TableDataBinding<UITableViewCell, RequestsIndexFilter>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item) => //What to do when cell is created for item
                        {
                            cell.TextLabel.Text = item.Title;
                            cell.ImageView.Image = UIImage.FromBundle("MaintenaceIcon");
                            cell.TextLabel.MinimumScaleFactor = 0.2f;
                        },
                        ItemSelected = item =>
                        {
                            ViewModel.CurrentFilter = item;
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCell"), //Define how to create cell, if reusables not found
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
                    _tableSection = Formals.Create<TableSection>(); //Create as usually. 
                    _tableSection.Table.AllowsSelection = true; //Step 1. Look at the end of BindForm method for step 2
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
                    _callToActionSection.MainButton.SetTitle("Scan QR Code",UIControlState.Normal);
                    _callToActionSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;

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

            //Update table data when collection changes. Heads up for Main Thread!

            this.OnViewModelEvent<RequestsIndexFiltersUpdatedEvent>(_ =>
            {
                InvokeOnMainThread(() =>
                {
                    if(ViewModel.CurrentFilter != null) SetTableToDisplayItems();
                    else SetTableToDisplayFilters();
                });
            });

            this.OnViewModelEvent<RequestsIndexUpdateStarted>(_ =>
            {
                InvokeOnMainThread(()=> TableSection.SetLoading(true));
            });

            this.OnViewModelEvent<RequestsIndexUpdateFinished>(_ =>
            {
                InvokeOnMainThread(()=> TableSection.SetLoading(false));
            });


            // Plus button to the top right
            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem
                (
                    UIBarButtonSystemItem.Add,
                    (sender, args) =>
                    {
                        ViewModel.OpenMaintenanceRequestFormCommand.Execute(null);
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


            SetTableToDisplayFilters();
            //Every form is placed inside of ScrollView (called SectionContainer);
            //ScrollView and nested TableView do not come along very well:
            //Row Selection will only work if you tap and hold the row for a few seconds.
            //This is caused by gesture recognizers on the scroll view.

            //In this particular form, ScrollView does nothing, since form has fixed height
            //So I just remove all gesture recognizers.

            foreach (var uiGestureRecognizer in SectionsContainer.GestureRecognizers)
            {
                SectionsContainer.RemoveGestureRecognizer(uiGestureRecognizer);
            }

        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(TableSection);
            content.Add(CallToActionSection);
        }

        public void SetTableToDisplayFilters()
        {

            TableSection.Source = TableFiltersSource;
            TableSection.ReloadDataAnimated(UIViewAnimationOptions.TransitionCurlDown);
        }

        public void SetTableToDisplayItems()
        {

            TableSection.Source = TableItemSource;
            TableSection.ReloadDataAnimated(UIViewAnimationOptions.TransitionCurlUp);
        }

//
        public override void LayoutContent()
        {

            View.AddConstraints(
                    TableSection.AtTopOf(View),
                    TableSection.AtLeftOf(View),
                    TableSection.AtRightOf(View)
                );

            View.AddConstraints(
                    CallToActionSection.Below(TableSection),
                    CallToActionSection.AtLeftOf(View),
                    CallToActionSection.AtRightOf(View),
                    CallToActionSection.AtBottomOf(View)
                );
        }
    }
}
