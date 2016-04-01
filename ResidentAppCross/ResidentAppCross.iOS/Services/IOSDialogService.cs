using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.iOS;
using MvvmCross.Plugins.PictureChooser.iOS;
using ObjCRuntime;
using ResidentAppCross.Extensions;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using SCLAlertViewLib;
using SharpMobileCode.ModalPicker;
using UIKit;
using ZXing;
using ZXing.Mobile;

namespace ResidentAppCross.iOS.Services
{
    public class IOSDialogService : IDialogService
    {
        private IMvxMainThreadDispatcher _dispatcher;
        private UIImagePickerController _imagePickerController;
        private int _maxPixelDimension;
        private float _percentQuality;
        public UIWindow KeyWindow => UIApplication.SharedApplication.KeyWindow;
        public UINavigationController RootController => KeyWindow.RootViewController as UINavigationController;
        public UIViewController CurrentController => KeyWindow.RootViewController.PresentedViewController;
        public UIViewController TopController => RootController.TopViewController;

        public IMvxMainThreadDispatcher Dispatcher
            => _dispatcher ?? (_dispatcher = MvxSingleton<IMvxMainThreadDispatcher>.Instance);



		public Task<T> OpenSearchableTableSelectionDialog<T>(IList<T> items, string title, Func<T,string> itemTitleSelector, Func<T, string> itemSubtitleSelector = null, object arg = null)
        {
            return Task.Factory.StartNew(() =>
            {

                T result = default(T);
                UITableViewController selectionTable = null;

                ManualResetEvent waitForCompleteEvent = new ManualResetEvent(false);

                Dispatcher.RequestMainThreadAction(() =>
                {
                    ResignFirstReponder();
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
                        Bind = (cell, item, index) => //What to do when cell is created for item
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
							var view = arg as UIView;
							if (arg != null && selectionTable.PopoverPresentationController !=null) {
								selectionTable.PopoverPresentationController.SourceView = view;
								selectionTable.PopoverPresentationController.SourceRect = view.Bounds;
							}

                    TopController.PresentModalViewController(selectionTable, true);
                });

                waitForCompleteEvent.WaitOne();
                selectionTable.Dispose();
                return result;

            });
        }

        private void ResignFirstReponder()
        {
            TopController?.View?.EndEditing(true);
        }

        public Task<DateTime?> OpenDateTimeDialog(string title)
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
                        ResignFirstReponder();

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
                        ResignFirstReponder();

                        modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Select A Date",
                            TopController)
                        {
                            HeaderBackgroundColor = AppTheme.SecondaryBackgoundColor,
                            HeaderTextColor = UIColor.White,
                            TransitioningDelegate = new ModalPickerTransitionDelegate(),
                            ModalPresentationStyle = UIModalPresentationStyle.Custom
                        };

                        modalPicker.DatePicker.Mode = UIDatePickerMode.Date;

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

        public Task<byte[]> OpenImageDialog()
        {
            return Task.Factory.StartNew(() =>
            {
                PhotoPickEvent = new ManualResetEvent(false);
                PhotoData = null;
                Dispatcher.RequestMainThreadAction(() =>
                {
                    ResignFirstReponder();

                    var shouldCancel = true;
                    var newController = new SCLAlertView();

                    if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
                    newController.AddButton("Take Photo", ()=> UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera), () =>
                    {
                        StartImagePickingDialog(UIImagePickerControllerSourceType.Camera);
                        shouldCancel = false;
                    });

                    if(UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.PhotoLibrary))
                    newController.AddButton("Photo Library", () =>
                    {
                        StartImagePickingDialog(UIImagePickerControllerSourceType.PhotoLibrary);
                        shouldCancel = false;
                    });

                    if(UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.SavedPhotosAlbum))
                    newController.AddButton("Saved Photos", () =>
                    {
                        StartImagePickingDialog(UIImagePickerControllerSourceType.SavedPhotosAlbum);
                        shouldCancel = false;
                    });
                     
                    newController.ShouldDismissOnTapOutside = true;
                    newController.ShowAnimationType = SCLAlertViewShowAnimation.FadeIn;
                    newController.HideAnimationType = SCLAlertViewHideAnimation.FadeOut;
                    newController.CustomViewColor = AppTheme.SecondaryBackgoundColor;
                    newController.AlertIsDismissed(() =>
                    {
                        //newController.DismissViewController(true, () => { });
                        NSTimer.CreateScheduledTimer(TimeSpan.FromMilliseconds(50), x =>
                        {
                            if (shouldCancel) PhotoPickEvent.Set();
                        });
                    });
                    newController.ShowEdit(TopController,"Select Photo","What photo source would you like to use?","Cancel",0);

                    //TopController.PresentViewController(newController, true, () => { });

                });
                PhotoPickEvent.WaitOne();
                return PhotoData;
            });
        }

        public UIImagePickerController ImagePickerController
        {
            get
            {
                if (_imagePickerController == null)
                {

                    _imagePickerController = new UIImagePickerController();
                    NavbarStyling.ApplyToNavigationController(_imagePickerController);

                    _imagePickerController.FinishedPickingImage += (o, args) =>
                    {
                        OnImagePick(o, args);
                        PhotoPickEvent?.Set();
                        _imagePickerController.DismissViewController(true, () => { });
                    };
                    _imagePickerController.FinishedPickingMedia += (o, args) =>
                    {
                        OnMediaPick(o, args);
                        PhotoPickEvent?.Set();
                        _imagePickerController.DismissViewController(true, () => { });
                    };
                    _imagePickerController.Canceled += (sender, args) =>
                    {
                        PhotoPickEvent?.Set();
                        _imagePickerController.DismissViewController(true, () => { });
                    };
                }
                return _imagePickerController;
            }
        }

        private void StartImagePickingDialog(UIImagePickerControllerSourceType sourceType)
        {

            ImagePickerController.SourceType = sourceType;
            TopController.PresentViewController(ImagePickerController, true, () => { });
        }

        private void HandleUIImagePick(UIImage image)
        {
            if (image != null)
            {
                int num;
                if (_maxPixelDimension > 0)
                {
                    CGSize size = image.Size;
                    if (!(size.Height > _maxPixelDimension))
                    {
                        size = image.Size;
                        num = size.Width > _maxPixelDimension ? 1 : 0;
                    }
                    else
                        num = 1;
                }
                else
                    num = 0;
                if (num != 0)
                    image = image.ImageToFitSize(new CGSize(_maxPixelDimension, this._maxPixelDimension));
                using (NSData nsData = image.AsJPEG(_percentQuality / 100f))
                {
                    byte[] numArray = new byte[(ulong)nsData.Length];
                    Marshal.Copy(nsData.Bytes, numArray, 0, Convert.ToInt32((ulong)nsData.Length));
                    MemoryStream memoryStream1 = new MemoryStream(numArray, false);

                    PhotoData = memoryStream1.ToArray();
                }
            }
        }

        private ManualResetEvent PhotoPickEvent;
        private byte[] PhotoData;

        private void OnMediaPick(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            HandleUIImagePick(e.OriginalImage ?? e.EditedImage);
        }

        private void OnImagePick(object sender, UIImagePickerImagePickedEventArgs e)
        {
            HandleUIImagePick(e.Image);
        }

    }
}

