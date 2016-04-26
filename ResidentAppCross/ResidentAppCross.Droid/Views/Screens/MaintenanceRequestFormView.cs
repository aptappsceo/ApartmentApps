using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;


namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof (ApplicationViewModel), Resource.Id.application_host_container_primary,true)]
    public class MaintenanceRequestFormView : SectionViewFragment<MaintenanceRequestFormViewModel>
    {
        public override int LayoutId => DefaultLayoutId;

        public HeaderSection HeaderSection { get; set; }
        public LabelButtonSection TypeSelectionSection { get; set; } 
        public SwitchSection EntrancePermissionSection { get; set; } 
        public RadioSection PetTypeSelection { get; set; } 
        public TextSection CommentsSection { get; set; } 
        public ActionBarSection ActionBar { get; set; } 
        public GallerySection PhotoSection { get; set; } 

        public override void Bind()
        {
            base.Bind();
            HeaderSection.TitleLabel.Text = "Request Maintenance";
            TypeSelectionSection.Label.Text = "Request Type:";
        
            var set = this.CreateBindingSet<MaintenanceRequestFormView, MaintenanceRequestFormViewModel>();
            set.Bind(TypeSelectionSection.Button)
                .For(b => b.Text)
                .To(vm => vm.SelectedRequestType.Value)
                .WithFallback("Select");

            set.Bind(EntrancePermissionSection.Switch).For(s => s.Checked).TwoWay().To(vm => vm.EntrancePermission);
            set.Bind(TypeSelectionSection.Button).To(vm => vm.SelectRequestTypeCommand);
            set.Bind(CommentsSection.InputField).TwoWay().To(vm => vm.Comments);
            set.Apply();

            PetTypeSelection.BindToList(ViewModel.PetStatuses, i => i.Title, x => ViewModel.SelectedPetStatus = x.Id);
            PetTypeSelection.Label.Text = "Do you have a pet?";

            PhotoSection.Editable = true;

            CommentsSection.HeaderLabel.Text = "Comments & Details:";

            PhotoSection.Bind(ViewModel.Photos);

            ActionBar.SetItems(new ActionBarSection.ActionBarItem()
            {
                Action = () => ViewModel.DoneCommand.Execute(null),
                Title = "Submit",
            });

            HeaderSection.IconView.SetImageResource(Resource.Drawable.maintenance_plus);
            HeaderSection.IconView.SetColorFilter(Resources.GetColor(Resource.Color.secondary_text_body));

        }


        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(TypeSelectionSection);
            sections.Add(CommentsSection);
            sections.Add(PhotoSection);
            sections.Add(EntrancePermissionSection);
            sections.Add(PetTypeSelection);
            sections.Add(ActionBar);
        }
    }

    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class MaintenanceCheckinDetailsView : SectionViewFragment<MaintenanceCheckinDetailsViewModel>
    {
        public override int LayoutId => DefaultLayoutId;

        public HeaderSection HeaderSection { get; set; }
        public NoneditableTextSection CommentsSection { get; set; }
        public GallerySection PhotoSection { get; set; }

        public override void Bind()
        {
            base.Bind();

            HeaderSection.TitleLabel.Text = "Maintenance Checkin";
            CommentsSection.HeaderLabel.Text = "Comments & Details:";
            CommentsSection.InputField.Text = ViewModel.Checkin.Comments;
            HeaderSection.SubtitleLabel.Text = ViewModel.Checkin.StatusId;

            HeaderSection.IconView.SetImageResource(AppTheme.IconResByMaintenanceState(ViewModel.Checkin.StatusId.AsMaintenanceStatus()));
            var color = Resources.GetColor(Resource.Color.secondary_text_body);
            HeaderSection.IconView.SetColorFilter(color);
            PhotoSection.Bind(ViewModel.CheckinPhotos);
        }


        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(CommentsSection);
            sections.Add(PhotoSection);
        }
    }

    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class IncidentReportCheckinDetailsView : SectionViewFragment<IncidentReportCheckinDetailsViewModel>
    {
        public override int LayoutId => DefaultLayoutId;

        public HeaderSection HeaderSection { get; set; }
        public NoneditableTextSection CommentsSection { get; set; }
        public GallerySection PhotoSection { get; set; }

        public override void Bind()
        {
            base.Bind();

            HeaderSection.TitleLabel.Text = "Incident Checkin";
            CommentsSection.InputField.Text = ViewModel.Checkin.Comments;
            HeaderSection.SubtitleLabel.Text = ViewModel.Checkin.StatusId;
            CommentsSection.HeaderLabel.Text = "Comments & Details:";

            HeaderSection.IconView.SetImageResource(AppTheme.IconResByIncidentState(ViewModel.Checkin.StatusId.AsIncidentStatus()));
            HeaderSection.IconView.SetColorFilter(Resources.GetColor(Resource.Color.secondary_text_body));

            PhotoSection.Bind(ViewModel.CheckinPhotos);

        }


        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(CommentsSection);
            sections.Add(PhotoSection);
        }
    }


    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class PropertyConfigFormView : SectionViewFragment<PropertyConfigFormViewModel>
    {
        public override int LayoutId => DefaultLayoutId;

        public HeaderSection HeaderSection { get; set; }
        public LabelButtonSection TypeSelectionSection { get; set; }
        public MapSection MapSection { get; set; }
        public ActionBarSection ActionBar { get; set; }

        public override void Bind()
        {
            base.Bind();
            MapSection.SetLifecycleProvider(this);
            var invoker = new IOnMapReadyMonoInvoker();
            invoker.MapReady += OnMapReady;
            MapSection.Map.GetMapAsync(invoker);


            HeaderSection.IconView.SetImageResource(Resource.Drawable.home_config);
            HeaderSection.IconView.SetColorFilter(Resources.GetColor(Resource.Color.secondary_text_body));

        }


        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            if (Map != null) sections.Add(MapSection);
            sections.Add(TypeSelectionSection);
            sections.Add(ActionBar);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            Map = googleMap;
            googleMap.UiSettings.MyLocationButtonEnabled = false;
            googleMap.MyLocationEnabled = true;

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(new LatLng(43.1, -87.9), 10);
            googleMap.AnimateCamera(cameraUpdate);

            RefreshContent();
        }

        public override string Title => "Configure Property";

        public GoogleMap Map { get; set; }
    }

    public class IOnMapReadyMonoInvoker : Java.Lang.Object, IOnMapReadyCallback
    {
        public event Action<GoogleMap> MapReady;

        public void OnMapReady(GoogleMap googleMap)
        {
            MapReady?.Invoke(googleMap);
        }
    }

}