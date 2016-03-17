using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using MvvmCross.Platform;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class PhotoGallerySection : SectionViewBase
	{
	    public PhotoGallerySection()
	    {
	    }

	    public PhotoGallerySection (IntPtr handle) : base (handle)
		{
		}

	    public UICollectionView PhotoContainer => _photoContainer;
	    public UILabel HeaderLabel => _headerLabel;
	    public UIButton AddPhotoButton => _addPhotoButton;

	    public void BindViewModel(ImageBundleViewModel viewModel)
	    {
	        Source = viewModel;
            viewModel.RawImages.CollectionChanged += SourceChanged;
	        AddPhotoButton.TouchUpInside += (sender, args) =>
	        {
	            StartImagePickingDialog();
	        };
	        UpdatePhotos();

	    }

	    private void StartImageSourceSelectionDialog()
	    {
            var controller = new UIAlertController();
            controller.Title = "Select Endpoint";
            controller.AddAction(UIAlertAction.Create("Select Photo", UIAlertActionStyle.Default, x =>
            {
                StartImagePickingDialog();
            }));

            controller.AddAction(UIAlertAction.Create("Take Photo", UIAlertActionStyle.Default,
            x =>
            {

            }));

            controller.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel,
            x =>
            {
            }));

            ParentController.PresentViewController(controller, true, () => { });
        }

	    private void StartImagePickingDialog()
	    {
            var controller= new UIImagePickerController();
            NavbarStyling.ApplyToNavigationController(controller);
            controller.SourceType = UIImagePickerControllerSourceType.Camera;
	        foreach (var mediaType in controller.MediaTypes)
	        {
	            Debug.WriteLine("Media Type: "+mediaType);
	        } 
            ParentController.PresentViewController(controller,true,()=> {});
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
            var hasPhotos = Source.RawImages.Any();
            PhotoContainer.Hidden = !hasPhotos;
            HeaderLabel.Text = hasPhotos ? "Photos:" : "No Photos Attached.";
            PhotoContainer.ReloadData();
            PhotoContainer.LayoutSubviews();
        }
	}
}
