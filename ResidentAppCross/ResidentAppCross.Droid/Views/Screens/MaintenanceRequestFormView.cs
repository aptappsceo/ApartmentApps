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

            TypeSelectionSection.Label.Text = "Request Type:";

            var set = this.CreateBindingSet<MaintenanceRequestFormView, MaintenanceRequestFormViewModel>();
            set.Bind(TypeSelectionSection.Button)
                .For(b => b.Text)
                .To(vm => vm.SelectedRequestType.Value)
                .WithFallback("Select");

            set.Bind(EntrancePermissionSection.Switch).For(s => s.Checked).TwoWay().To(vm => vm.EntrancePermission);
            set.Bind(TypeSelectionSection.Button).To(vm => vm.SelectRequestTypeCommand);
            set.Bind(CommentsSection.TextInput).TwoWay().To(vm => vm.Comments);
            set.Apply();

            PetTypeSelection.BindToList(ViewModel.PetStatuses, i => i.Title, x => ViewModel.SelectedPetStatus = x.Id);
            PetTypeSelection.Label.Text = "Do you have a pet?";


            CommentsSection.HeaderLabel.Text = "Comments & Details:";

            PhotoSection.Bind(ViewModel.Photos);

            ActionBar.SetItems(new ActionBarSection.ActionBarItem()
            {
                Action = () => ViewModel.DoneCommand.Execute(null),
                Title = "Submit",
            });
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
    public class PropertyConfigForm : SectionViewFragment<PropertyConfigFormViewModel>, IOnMapReadyCallback
    {
        public override int LayoutId => DefaultLayoutId;

        public HeaderSection HeaderSection { get; set; }
        public LabelButtonSection TypeSelectionSection { get; set; }
        public MapSection MapSection { get; set; }
        public ActionBarSection ActionBar { get; set; }

        public override void Bind()
        {
            base.Bind();
            MapSection.Map.GetMapAsync(this);
        }


        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(MapSection);
            sections.Add(TypeSelectionSection);
            sections.Add(ActionBar);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            Console.WriteLine("blabla");
        }
    }

}