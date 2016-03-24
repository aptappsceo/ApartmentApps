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

        public TableSection TableSection
        {
            get
            {
                if (_tableSection == null)
                {
                    _tableSection = Formals.Create<TableSection>(); //Create as usually. 

                    var tableDataBinding = new TableDataBinding<UITableViewCell, MaintenanceIndexBindingModel>() //Define cell type and data type as type args
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

                    var source = new GenericTableSource()
                    {
                        Items = ViewModel.FilteredRequests, //Deliver data
                        Binding = tableDataBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true
                    };


                    _tableSection.Table.AllowsSelection = true; //Step 1. Look at the end of BindForm method for step 2
                    _tableSection.Source = source;
                    _tableSection.ReloadData();

                }
                return _tableSection;
            }
        }

        public SegmentSelectionSection FilterSection
        {
            get
            {
                if (_filterSection == null)
                {
                    _filterSection = Formals.Create<SegmentSelectionSection>();
                    _filterSection.HeightConstraint.Constant = 60;
                    _filterSection.HideTitle(true);
                    _filterSection.Selector.ApportionsSegmentWidthsByContent = true;
                }
                return _filterSection;
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
            ViewModel.FilteredRequests.CollectionChanged += (sender, args) =>
            {
                InvokeOnMainThread(()=>TableSection.Table.ReloadData());
            };

            FilterSection.BindTo(
                ViewModel.Filters, //What collection to use
                f=>f.Title, //How to extract title
                f => ViewModel.CurrentFilter = f, //What to do when item selected
                0); //First segment

            // Plus button to the top right
            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem
                (
                    UIBarButtonSystemItem.Add,
                    (sender, args) =>
                    {
                        ViewModel.OpenMaintenanceRequestFormCommand.Execute(null);
                    }),
                true);


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

            content.Add(FilterSection);
            content.Add(TableSection);
            content.Add(CallToActionSection);
        }
//
        public override void LayoutContent()
        {

            View.AddConstraints(
                    FilterSection.AtTopOf(View),
                    FilterSection.AtLeftOf(View),
                    FilterSection.AtRightOf(View)
                );

            View.AddConstraints(
                    TableSection.Below(FilterSection),
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
