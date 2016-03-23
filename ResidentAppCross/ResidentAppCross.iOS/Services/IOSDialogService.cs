using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.iOS;
using ObjCRuntime;
using ResidentAppCross.Extensions;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using SharpMobileCode.ModalPicker;
using UIKit;
using ZXing;
using ZXing.Mobile;

namespace ResidentAppCross.iOS.Services
{
    public class IOSDialogService : IDialogService
    {
        private IMvxMainThreadDispatcher _dispatcher;
        public UIWindow KeyWindow => UIApplication.SharedApplication.KeyWindow;
        public UINavigationController RootController => KeyWindow.RootViewController as UINavigationController;
        public UIViewController CurrentController => KeyWindow.RootViewController.PresentedViewController;
        public UIViewController TopController => RootController.TopViewController;

        public IMvxMainThreadDispatcher Dispatcher
            => _dispatcher ?? (_dispatcher = MvxSingleton<IMvxMainThreadDispatcher>.Instance);



        public Task<T> OpenSearchableTableSelectionDialog<T>(IList<T> items, string title, Func<T,string> itemTitleSelector, Func<T, string> itemSubtitleSelector = null)
        {
            return Task.Factory.StartNew(() =>
            {

                T result = default(T);
                UITableViewController selectionTable = null;

                ManualResetEvent waitForCompleteEvent = new ManualResetEvent(false);

                Dispatcher.RequestMainThreadAction(() =>
                {
                    //Proxy collection to store search resultes
                    var filteredResults = new ObservableCollection<T>();
                    filteredResults.AddRange(items);
                    //Main controller for the tabl
                    selectionTable = new UITableViewController(UITableViewStyle.Grouped)
                    {
                        ModalPresentationStyle = UIModalPresentationStyle.Popover,
                        TableView =
                        {
                            //LayoutMargins = new UIEdgeInsets(25, 25, 0, 50),
                            SeparatorColor = UIColor.Gray,
                            SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine
                        },
                        EdgesForExtendedLayout = UIRectEdge.None,
                        Title = title
                    };

                    var tableView = selectionTable.TableView;

                    var tableDataBinding = new TableDataBinding<UITableViewCell, T>()
                        //Define cell type and data type as type args
                    {
                        Bind = (cell, item) => //What to do when cell is created for item
                        {
                            cell.TextLabel.Text = itemTitleSelector(item);
                            cell.DetailTextLabel.Text = itemSubtitleSelector?.Invoke(item) ?? null;
                        },
                        ItemSelected = item =>
                        {
                            selectionTable.DismissModalViewController(true);
                            waitForCompleteEvent.Set();
                            result = item;
                        },
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator,
                        CellSelector = () => new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCell"),
                        //Define how to create cell, if reusables not found
                    };

                    var source = new GenericTableSource()
                    {
                        Items = filteredResults, //Deliver data
                        Binding = tableDataBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true
                    };

                    tableView.AllowsSelection = true;

                    tableView.Source = source;
                    
                    var searchBar = new UISearchBar()
                    {
                        AutocorrectionType = UITextAutocorrectionType.Yes,
                        KeyboardType = UIKeyboardType.WebSearch
                    };

                    tableView.TableHeaderView = searchBar;
                    searchBar.SizeToFit();
                    searchBar.Placeholder = "Search...";
                    searchBar.OnEditingStopped += (sender, args) =>
                    {
                        searchBar.ResignFirstResponder();
                    };

                    searchBar.TextChanged += (sender, args) =>
                    {
                        filteredResults.Clear();
                        if (string.IsNullOrEmpty(searchBar.Text))
                        {
                            filteredResults.AddRange(items);
                        }
                        else
                        {
                            var lower = searchBar.Text.ToLower();
                            filteredResults.AddRange(items.Where(i => itemTitleSelector(i).ToLower().Contains(lower)));
                        }
                        tableView.ReloadData();
                    };

                    TopController.PresentModalViewController(selectionTable, true);
                });

                waitForCompleteEvent.WaitOne();
                selectionTable.Dispose();
                return result;

            });
        }

        public Task<DateTime?> OpenDateDialog(string title)
        {
            return Task.Factory.StartNew(() =>
            {

                ManualResetEvent waitForCompleteEvent = new ManualResetEvent(false);

                ModalPickerViewController modalPicker = null;

                DateTime? result = null;
                try
                {

                    Dispatcher.RequestMainThreadAction(() =>
                    {
                        modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Select A Date",
                            TopController)
                        {
                            HeaderBackgroundColor = AppTheme.SecondaryBackgoundColor,
                            HeaderTextColor = UIColor.White,
                            TransitioningDelegate = new ModalPickerTransitionDelegate(),
                            ModalPresentationStyle = UIModalPresentationStyle.Custom
                        };

                        modalPicker.DatePicker.Mode = UIDatePickerMode.DateAndTime;

                        modalPicker.OnSelectionConfirmed += (s, ea) =>
                        {
                            RootController.InvokeOnMainThread(() =>
                            {
                                result = modalPicker.DatePicker.Date?.ToDateTimeUtc();
                                waitForCompleteEvent.Set();
                            });
                        };

                        modalPicker.OnSelectionCancelled += (s, ea) =>
                        {
                            Dispatcher.RequestMainThreadAction(() =>
                            {
                                waitForCompleteEvent.Set();
                            });
                        };

                        TopController.PresentModalViewController(modalPicker, true);
                    });

                    waitForCompleteEvent.WaitOne();
                    modalPicker.Dispose();
                    return result;
                }
                catch (Exception ex)
                {
                    return result;
                }
            });

        }
    }
}

