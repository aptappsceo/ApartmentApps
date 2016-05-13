using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
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

            EntrancePermissionSection.SubtitleLabel.Text =
                "Do you give permission for maintenance staff to enter when you are not home?";

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
    public class MessageDetailsView : SectionViewFragment<MessageDetailsViewModel>
    {
        public override int LayoutId => DefaultLayoutId;

        public NoneditableTextSection SubjectSection { get; set; }
        public NoneditableTextSection DateSection { get; set; }
        public NoneditableTextSection MessageSection { get; set; }

        public override void Bind()
        {

            SubjectSection.HeaderLabel.Text = "Subject";
            DateSection.HeaderLabel.Text = "Date";
            MessageSection.HeaderLabel.Text = "Message";

            var set = this.CreateBindingSet<MessageDetailsView, MessageDetailsViewModel>();
            set.Bind(SubjectSection.InputField).For(f=>f.Text).To(vm=>vm.Subject);
            set.Bind(DateSection.InputField).For(f=>f.Text).To(vm=>vm.Date);
            set.Bind(MessageSection.InputField).For(f=>f.Text).To(vm=>vm.Message);
            set.Apply();

        }

        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(SubjectSection);
            sections.Add(DateSection);
            sections.Add(MessageSection);
        }
    }

    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class ChangePasswordView : SectionViewFragment<ChangePasswordViewModel>
    {
        public override int LayoutId => DefaultLayoutId;

        public HeaderSection HeaderSection { get; set; }
        public TextInputSection OldPasswordInput { get; set; }
        public TextInputSection NewPasswordInput { get; set; }
        public TextInputSection NewPasswordConfirmation { get; set; }
        public ActionBarSection ActionBar { get; set; }

        public override void Bind()
        {


            HeaderSection.IconView.Visibility = ViewStates.Invisible;
            HeaderSection.TitleLabel.Text = "Change Password";
            HeaderSection.SubtitleLabel.Text = "Please, fill the information below";

            OldPasswordInput.TextInputLayout.Hint = "Current Password";
            NewPasswordInput.TextInputLayout.Hint = "New Password";
            NewPasswordConfirmation.TextInputLayout.Hint = "Confirm New Password";

            var set = this.CreateBindingSet<ChangePasswordView, ChangePasswordViewModel>();
            set.Bind(OldPasswordInput.TextInput).TwoWay().For(f=>f.Text).To(vm=>vm.OldPassword);
            set.Bind(NewPasswordInput.TextInput).TwoWay().For(f=>f.Text).To(vm=>vm.NewPassword);
            set.Bind(NewPasswordConfirmation.TextInput).TwoWay().For(f=>f.Text).To(vm=>vm.NewPasswordConfirmation );
            set.Apply();

            ActionBar.SetItems(new ActionBarSection.ActionBarItem()
            {
                Action = ()=> { ViewModel.ChangePasswordCommand.Execute(null); },
                Title = "CHANGE PASSWORD"
            });

        }

        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(OldPasswordInput);
            sections.Add(NewPasswordInput);
            sections.Add(NewPasswordConfirmation);
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


    public class IOnMapReadyMonoInvoker : Java.Lang.Object, IOnMapReadyCallback
    {
        public event Action<GoogleMap> MapReady;

        public void OnMapReady(GoogleMap googleMap)
        {
            MapReady?.Invoke(googleMap);
        }
    }

}