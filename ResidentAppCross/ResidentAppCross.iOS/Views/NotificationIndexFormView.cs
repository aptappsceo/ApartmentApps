using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ApartmentApps.Client.Models;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using MvvmCross.Plugins.PictureChooser.iOS;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.Resources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    [Register("NotificationIndexFormView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public class NotificationIndexFormView : BaseForm<NotificationIndexFormViewModel>
    {
        public NotificationIndexFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public NotificationIndexFormView()
        {
        }

        public override string Title => "Alerts";

        private UITabBar _typeSelectionSection;
        private SegmentSelectionSection _filterSection;
        private TableSection _tableSection;

        public SegmentSelectionSection FilterSection
        {
            get
            {
                if (_filterSection == null)
                {
                    _filterSection = Formals.Create<SegmentSelectionSection>();
                    _filterSection.HideTitle(true);
                }
                return _filterSection;
            }
        }

        public TableSection TableSection
        {
            get
            {

                var maintenanceReadIcon = AppTheme.GetTemplateIcon(SharedResources.Icons.MessageMaintenanceRead,
                    SharedResources.Size.S);
                var maintenanceUnReadIcon = AppTheme.GetTemplateIcon(SharedResources.Icons.MessageMaintenance,
                    SharedResources.Size.S);

                var policeUnReadIcon = AppTheme.GetTemplateIcon(SharedResources.Icons.MessagePolice,
                    SharedResources.Size.S);

                var policeReadIcon = AppTheme.GetTemplateIcon(SharedResources.Icons.MessagePoliceRead,
                    SharedResources.Size.S);

                


                if (_tableSection == null)
                {
                    _tableSection = Formals.Create<TableSection>(); //Create as usually. 

                    var tableDataBinding = new TableDataBinding<UITableViewCell, AlertBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.TextLabel.Text = item.Title;
                            cell.DetailTextLabel.Text = item.Message;

                            if (item.Type == "Maintenance")
                            {
                                if (item.HasRead ?? false)
                                {
                                    cell.ImageView.Image = maintenanceReadIcon;
                                }
                                else
                                {
                                    cell.ImageView.Image = maintenanceUnReadIcon;
                                }
                            } else if (item.Type == "Courtesy")
                            {
                                if (item.HasRead ?? false)
                                {
                                    cell.ImageView.Image = policeReadIcon;
                                }
                                else
                                {
                                    cell.ImageView.Image = policeUnReadIcon;
                                }
                            }
                            else
                            {
                                cell.ImageView.Image = null;
                            }

                            cell.TextLabel.MinimumScaleFactor = 0.2f;
                        },

                        ItemSelected = item =>
                        {
                            ViewModel.SelectedNotification = item;
                            ViewModel.OpenSelectedNotificationDetailsCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCell"), //Define how to create cell, if reusables not found
                    };

                    var source = new GenericTableSource()
                    {
                        Items = ViewModel.FilteredNotifications, //Deliver data
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


//        public UITabBar TabSection
//        {
//            get
//            {
//                if (_typeSelectionSection == null)
//                {
//                    _typeSelectionSection = new UITabBar().WithHeight(49,1000);
//                    _typeSelectionSection.BarStyle = UIBarStyle.BlackOpaque;
//                    _typeSelectionSection.TranslatesAutoresizingMaskIntoConstraints = false;
//                    _typeSelectionSection.BarTintColor = AppTheme.SecondaryBackgoundColor;
//                    _typeSelectionSection.SelectedImageTintColor = UIColor.White;
//                    _typeSelectionSection.TintColor = new UIColor(0.8f,0.8f,0.8f,1);
//                    UITabBarItem item;
//                    _typeSelectionSection.SetItems(new[]
//                    {
//                        new UITabBarItem("Maintenance",UIImage.FromBundle("MaintenaceIcon").ImageToFitSize(new CGSize(30,30)),0), 
//                        new UITabBarItem("Courtesy",UIImage.FromBundle("OfficerIcon").ImageToFitSize(new CGSize(30,30)),1), 
//                    },true );
//
//                    foreach (var uiTabBarItem in _typeSelectionSection.Items)
//                    {
//                        uiTabBarItem.BadgeValue = "+1";
//                        var attributes = uiTabBarItem.GetTitleTextAttributes(UIControlState.Normal);
//                        attributes.Font = UIFont.SystemFontOfSize(15);
//                        uiTabBarItem.SetTitleTextAttributes(attributes,UIControlState.Normal);
//                    }
//
//                }
//                return _typeSelectionSection;
//            }
//        }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            ViewModel.UpdateNotificationsCommand.Execute(null);
        }

        public override void BindForm()
        {
            base.BindForm();

            this.OnViewModelEvent<NotificationFiltersUpdatedEvent>(_ =>
            {
                InvokeOnMainThread(() => TableSection.Table.ReloadData());
            });

            FilterSection.BindTo(
                ViewModel.NotificationStatusFilters, //What collection to use
                f => f.Title, //How to extract title
                f => ViewModel.CurrentNotificationStatusFilter = f, //What to do when item selected
                0); //First segment

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
        }

        public override void LayoutContent()
        {
            View.AddConstraints(
               TableSection.AtTopOf(View),
               TableSection.AtLeftOf(View),
               TableSection.AtRightOf(View)
           );

            View.AddConstraints(
                FilterSection.Below(TableSection),
                FilterSection.AtLeftOf(View),
                FilterSection.AtRightOf(View),
                FilterSection.AtBottomOf(View)
            );

        }

    }

    public static class UITabBarExtensions
    {
        public static void BindTo<T>(this UITabBar tabbar, IList<T> items, Func<T,string> itemTitleSelector, Func<T, SharedResources.Icons> itemImageSelector, Func<T,string> itemBadgeSelector, Action<T> itemSelectedHandler, T selectedItem)
        {
            var index = 0;
            UITabBarItem selectedUiItem = null;
            var uiItems =
                items.Select(i =>
                {
                    var fromBundle = AppTheme.GetTemplateIcon(itemImageSelector(i),SharedResources.Size.XS);
                    var uiTabBarItem = new UITabBarItem(
                        itemTitleSelector(i),
                        //null,
                        fromBundle, index++)
                    {
                        BadgeValue = itemBadgeSelector(i)
                    };
                    if (selectedItem.Equals(i)) selectedUiItem = uiTabBarItem;
                    return uiTabBarItem;
                }).ToArray();

            tabbar.SetItems(uiItems,true);
            tabbar.SelectedItem = selectedUiItem;
            tabbar.ItemSelected += (sender, args) => { itemSelectedHandler(items[(int)tabbar.SelectedItem.Tag]); };


        }
    }
}
