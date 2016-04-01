using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using CoreGraphics;
using MvvmCross.Platform;
using MvvmCross.Plugins.PictureChooser.iOS;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class PhotoGallerySection : SectionViewBase
	{
	    private int _maxPixelDimension = 1024;
	    private float _percentQuality = 64f;
	    private UIImagePickerController _imagePickerController;
	    private bool _editable;
	    private IDialogService _dialogService;

	    public PhotoGallerySection()
	    {
	    }

	    public PhotoGallerySection (IntPtr handle) : base (handle)
		{
		}

	    public IDialogService DialogService
	    {
	        get { return _dialogService ?? (_dialogService = Mvx.Resolve<IDialogService>()); }
	        set { _dialogService = value; }
	    }

	    public bool Editable
	    {
	        get { return _editable; }
	        set
	        {
	            _editable = value;
	            AddPhotoButton.Hidden = !value;
	        }
	    }


	    public override void AwakeFromNib()
	    {
	        base.AwakeFromNib();
	        HeaderLabel.Font = AppFonts.SectionHeader;
	        AddPhotoButton.Font = AppFonts.SectionHeader;
            AddPhotoButton.SetTitleColor(AppTheme.FormControlColor, UIControlState.Normal);

        }

        public UICollectionView PhotoContainer => _photoContainer;
	    public UILabel HeaderLabel => _headerLabel;
	    public UIButton AddPhotoButton => _addPhotoButton;

	    public void BindViewModel(ImageBundleViewModel viewModel)
	    {
	        Source = viewModel;
            viewModel.RawImages.CollectionChanged += SourceChanged;

            PhotoContainer.RegisterClassForCell(typeof(PhotoGalleryCells), (NSString)PhotoGalleryCells.CellIdentifier);
            PhotoContainer.Source = new PhotoGallerySource(viewModel);
            
            PhotoContainer.BackgroundColor = UIColor.White;

            AddPhotoButton.TouchUpInside += async (sender, args) =>
            {
                var image = await DialogService.OpenImageDialog();
                if (image != null)
                {
                    Source.RawImages.Add(new ImageBundleItemViewModel()
                    {
                        Data = image
                    });
                }
                //StartImageSourceSelectionDialog();
	        };

            UpdatePhotos();
	    }

	    public ImageBundleViewModel Source { get; set; }

	    private void SourceChanged(object sender, NotifyCollectionChangedEventArgs e)
	    {
            UpdateThrottleTimer?.Dispose();
            InvokeOnMainThread(() =>
	        {
	            UpdateThrottleTimer = NSTimer.CreateScheduledTimer(TimeSpan.FromMilliseconds(100f), x =>
	            {
                    UpdatePhotos();
                });
	        });
	    }

	    public NSTimer UpdateThrottleTimer { get; set; }

	    private void UpdatePhotos()
	    {

            PhotoContainer.LayoutSubviews();
            PhotoContainer.ReloadData();
	        PhotoContainer.ClipsToBounds = false;
            var hasPhotos = Source.RawImages.Any();
            PhotoContainer.Hidden = !hasPhotos;
            HeaderLabel.Text = hasPhotos ? "Photos:" : "No Photos";
        }
	}
}
