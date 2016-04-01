using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using ResidentAppCross.iOS.Extensions;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.Resources;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS.Views
{

    [Register("MaintenanceRequestFormView")]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    [NavbarStyling(Hidden = false)]
	public partial class MaintenanceRequestFormView : BaseForm<MaintenanceRequestFormViewModel>
	{
        private HeaderSection _headerSection;
        private LabelWithButtonSection _requestTypeSection;
        private ToggleSection _entrancePermissionSection;
        private SegmentSelectionSection _petStatusSection;
        private TextViewSection _commentsSection;
        private PhotoGallerySection _photoSection;

//        public new MaintenanceRequestFormViewModel ViewModel
//        {
//            get { return (MaintenanceRequestFormViewModel)base.ViewModel; }
//            set { base.ViewModel = value; }
//        }

        public MaintenanceRequestFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public MaintenanceRequestFormView()
        {
        }

        public override string Title => "Maintenance";


        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                }
                return _headerSection;
            }
        }

        public LabelWithButtonSection RequestTypeSection
        {
            get
            {
                if (_requestTypeSection == null)
                {
                    _requestTypeSection = Formals.Create<LabelWithButtonSection>();
                }
                return _requestTypeSection;
            }
        }

        public SegmentSelectionSection PetStatusSection
        {
            get
            {
                if (_petStatusSection == null)
                {
                    _petStatusSection = Formals.Create<SegmentSelectionSection>();
                    _petStatusSection.Editable = true;
                }
                return _petStatusSection;
            }
        }

        public TextViewSection CommentsSection
        {
            get
            {
                if (_commentsSection == null)
                {
                    _commentsSection = Formals.Create<TextViewSection>();
                    _commentsSection.Editable = true;
                }
                return _commentsSection;
            }
        }

        public PhotoGallerySection PhotoSection
        {
            get
            {
                if (_photoSection == null)
                {
                    _photoSection = Formals.Create<PhotoGallerySection>();
                }
                return _photoSection;
            }
        }

        public ToggleSection EntrancePermissionSection
        {
            get
            {
                if (_entrancePermissionSection == null)
                {
                    _entrancePermissionSection = Formals.Create<ToggleSection>();
                    _entrancePermissionSection.Editable = true;
                }
                return _entrancePermissionSection;
            }
        }

        public override void BindForm()
        {
            base.BindForm();


            HeaderSection.LogoImage.Image = AppTheme.GetTemplateIcon(SharedResources.Icons.MaintenancePlus, SharedResources.Size.X);
            HeaderSection.LogoImage.TintColor = AppTheme.CreateColor;
            HeaderSection.MainLabel.Text = "Request";
            HeaderSection.SubLabel.Text = "Fill the information below";
            RequestTypeSection.Label.Text = "Request Type";
            EntrancePermissionSection.HeaderLabel.Text = "Permission To Enter";
            EntrancePermissionSection.SubHeaderLabel.Text = "Do you give a permission for tech guys to enter your apartment when you are not at home?";
            var b = this.CreateBindingSet<MaintenanceRequestFormView, MaintenanceRequestFormViewModel>();

            //Header Section

            //---

            //Request type section

            b.Bind(RequestTypeSection.Button).For("Title").To(vm => vm.SelectRequestTypeActionTitle);
			b.Bind(RequestTypeSection.Button).To(vm => vm.SelectRequestTypeCommand).CommandParameter(RequestTypeSection.Button);

            //Comments Section

            b.Bind(CommentsSection.TextView).For(v => v.Text).TwoWay().To(vm => vm.Comments);

            //Photo Section

            PhotoSection.BindViewModel(ViewModel.Photos);

            //Entrance permission switch
            b.Bind(EntrancePermissionSection.Switch).For(s=> s.On).TwoWay().To(vm => vm.EntrancePermission);

            // Pet Status section

            PetStatusSection.BindTo(ViewModel.PetStatuses,s=>s.Title,s=>ViewModel.SelectedPetStatus = s.Id, 0);
            b.Bind(PetStatusSection.Selector).For(s => s.SelectedSegment).To(vm => vm.SelectedPetStatus);

            b.Apply();

        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(RequestTypeSection);
            content.Add(CommentsSection);
            content.Add(PhotoSection);
            content.Add(PetStatusSection);
            content.Add(EntrancePermissionSection);
        }


        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem
                ("Done", 
                UIBarButtonItemStyle.Plain, 
                (sender, args) => ViewModel.DoneCommand.Execute(null)), 
                true);

		}
	}
}



