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

	    public PhotoGallerySection()
	    {
	    }

	    public PhotoGallerySection (IntPtr handle) : base (handle)
		{
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

            AddPhotoButton.TouchUpInside += (sender, args) =>
	        {
                StartImageSourceSelectionDialog();
	        };
	        UpdatePhotos();

	    }

	    private void StartImageSourceSelectionDialog()
	    {
            var controller = new UIAlertController();

            controller.AddAction(UIAlertAction.Create("Take Photo", UIAlertActionStyle.Default, x =>
            {
                StartImagePickingDialog(UIImagePickerControllerSourceType.Camera);
            }));

            controller.AddAction(UIAlertAction.Create("Photo Library", UIAlertActionStyle.Default, x =>
            {
                StartImagePickingDialog(UIImagePickerControllerSourceType.PhotoLibrary);
            }));

            controller.AddAction(UIAlertAction.Create("Saved Photos", UIAlertActionStyle.Default,
            x =>
            {
                StartImagePickingDialog(UIImagePickerControllerSourceType.SavedPhotosAlbum);
            }));

            controller.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel,
            x =>
            {
                controller.DismissViewController(true,()=> {});
            }));

            ParentController.PresentViewController(controller, true, () => { });
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
                        _imagePickerController.DismissViewController(true, () => { });
                    };
                    _imagePickerController.FinishedPickingMedia += (o, args) =>
                    {
                        OnMediaPick(o, args);
                        _imagePickerController.DismissViewController(true, () => { });
                    };
                    _imagePickerController.Canceled += (sender, args) =>
                    {
                        _imagePickerController.DismissViewController(true, () => { });
                    };
                }
                return _imagePickerController;
	        }
	    }

	    private void StartImagePickingDialog(UIImagePickerControllerSourceType sourceType) {

            ImagePickerController.SourceType = sourceType;
            ParentController.PresentViewController(ImagePickerController, true,()=> {});
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

                    OnImageAdded(memoryStream1.ToArray());

                }
            }
        }

	    private void OnMediaPick(object sender, UIImagePickerMediaPickedEventArgs e)
	    {
	        HandleUIImagePick(e.OriginalImage ?? e.EditedImage);
	    }

	    private void OnImagePick(object sender, UIImagePickerImagePickedEventArgs e)
	    {
            HandleUIImagePick(e.Image);            
        }

	    private void OnImageAdded(byte[] image)
	    {
	        Source.RawImages.Add(new ImageBundleItemViewModel()
	        {
	            Data = image
	        });
	    }

	    public ImageBundleViewModel Source { get; set; }

	    private void SourceChanged(object sender, NotifyCollectionChangedEventArgs e)
	    {
            InvokeOnMainThread(UpdatePhotos);
        }

	    private void UpdatePhotos()
	    {

            PhotoContainer.LayoutSubviews();
            PhotoContainer.ReloadData();

            var hasPhotos = Source.RawImages.Any();
            PhotoContainer.Hidden = !hasPhotos;
            HeaderLabel.Text = hasPhotos ? "Photos:" : "No Photos";
        }
	}
}
