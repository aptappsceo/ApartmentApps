using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using ApartmentApps.Client.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;
using MaintenanceRequestStatus = ResidentAppCross.ViewModels.Screens.MaintenanceRequestStatus;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class MaintenanceRequestStatusView : SectionViewFragment<MaintenanceRequestStatusViewModel>
    {

        [Outlet]
        public ViewPager ModePager { get; set; }

        [Outlet]
        public TabLayout ModeTabs { get; set; }

        [Outlet]
        public RecyclerView HistoryPage { get; set; }
        
        public HeaderSection HeaderSection { get; set; }
        public MaintenanceTicketStatusSection MaintenanceTicketStatusSection { get; set; }
        public NoneditableTextSection CommentsSection { get; set; }
        public GallerySection GallerySection { get; set; }
        public UnitInformationSection UnitInformationSection { get; set; }
        public ActionBarSection ActionBarSection { get; set; }

        public override int LayoutId => typeof (IncidentReportStatusView).MatchingLayoutId();

        public override void Bind()
        {
            base.Bind();

            //Header section

            //Setup stuff everytime we update status
            this.OnViewModelEvent<MaintenanceRequestStatusUpdated>(evt =>
            {
                UnitInformationSection.AvatarUrl = ViewModel?.Request?.User.ImageUrl;

                HeaderSection.IconView.SetImageResource(AppTheme.IconResByMaintenanceState(ViewModel.Request.Status.AsMaintenanceStatus()));
                var color =
                    Resources.GetColor(Resource.Color.secondary_text_body);
                HeaderSection.IconView.SetColorFilter(color);

                if(string.IsNullOrEmpty(ViewModel?.Request?.BuildingName?.Trim()))
                HeaderSection.SubtitleLabel.Text = "Unit Infromation Missing";
                else
                HeaderSection.SubtitleLabel.Text = ViewModel.Request.BuildingName;

                MaintenanceTicketStatusSection.PetStatusLabel.Text = ViewModel.Request.PetStatus?.AsPetStatusString();

                if(ViewModel.Request.PermissionToEnter.HasValue)

                    MaintenanceTicketStatusSection.EntranceStatusLabel.Text = ViewModel.Request.PermissionToEnter.Value ? "Yes" : "No";
                else
                    MaintenanceTicketStatusSection.EntranceStatusLabel.Text = "N/A";

                ActionBarSection.Update();
            });

            GallerySection?.Bind(ViewModel.Photos);


            HistoryPage.SetAdapter(new TicketHistoryAdapter<MaintenanceCheckinBindingModel>()
            {
                Items = ViewModel.Checkins,
                TitleSelector = s => s.StatusId,
                SubtitleSelector = s => s.Date?.ToString("g"),
                ItemSelected = item =>
                {
                    ViewModel.SelectedCheckin = item;
                    ViewModel.ShowCheckinDetailsCommand.Execute(null);
                },
                IconResourceSelector = i => AppTheme.StatusIconResByMaintenanceState(i.StatusId.AsMaintenanceStatus())
            });


            ModePager.Adapter = new TicketStatusViewPagerAdapter() { PagesLayout = Layout };
            ModeTabs.SetupWithViewPager(ModePager);
            ModePager.SetCurrentItem(0, true);
            ModePager.ScrollTo(0,0);
            ModeTabs.Invalidate();

            HeaderSection.TitleLabel.Text = "Maintenance Request";

            var set = this.CreateBindingSet<MaintenanceRequestStatusView, MaintenanceRequestStatusViewModel>();

            set.Bind(MaintenanceTicketStatusSection.TypeLabel).For(f => f.Text).To(vm => vm.Request.Name);
            set.Bind(MaintenanceTicketStatusSection.StatusLabel).For(f => f.Text).To(vm => vm.Request.Status);
            set.Bind(CommentsSection.InputField).For(t => t.Text).To(vm => vm.Request.Message).WithFallback("-");

            set.Bind(UnitInformationSection.NameLabel)
                .For(t => t.Text)
                .To(vm => vm.Request.User.FullName)
                .WithFallback("-");
            set.Bind(UnitInformationSection.AddressLabel)
                .For(t => t.Text)
                .To(vm => vm.Request.User.Address)
                .WithFallback("-");
            set.Bind(UnitInformationSection.EmailLabel)
                .For(t => t.Text)
                .To(vm => vm.Request.User.PostalCode)
                .WithFallback("-");
            set.Bind(UnitInformationSection.PhoneLabel)
                .For(t => t.Text)
                .To(vm => vm.Request.User.PhoneNumber)
                .WithFallback("-");

            set.Bind(UnitInformationSection).For(s => s.AvatarUrl).To(vm => vm.Request.User.ImageUrl);
            set.Apply();

            CommentsSection.InputField.Focusable = false;

            HistoryPage.SetLayoutManager(new LinearLayoutManager(Context,LinearLayoutManager.Vertical,false));

            ActionBarSection.SetItems(
                new ActionBarSection.ActionBarItem()
                {
                    Title = "Start",
                    Action = ()=> ViewModel.ScanAndStartCommand.Execute(null),
                    IsAvailable = () => ViewModel.Request != null && ViewModel.ScanAndStartCommand.CanExecute(null)
                },new ActionBarSection.ActionBarItem()
                {
                    Title = "Schedule",
                    Action = ()=> ViewModel.ScheduleCommand.Execute(null),
                    IsAvailable = () => ViewModel.Request != null && ViewModel.ScheduleCommand.CanExecute(null)
                },new ActionBarSection.ActionBarItem()
                {
                    Title = "Finish",
                    Action = ()=> ViewModel.FinishCommmand.Execute(null),
                    IsAvailable = () => ViewModel.Request != null && ViewModel.FinishCommmand.CanExecute(null)
                },new ActionBarSection.ActionBarItem()
                {
                    Title = "Pause",
                    Action = ()=> ViewModel.PauseCommmand.Execute(null),
                    IsAvailable = () => ViewModel.Request != null && ViewModel.PauseCommmand.CanExecute(null)
                }
            );


        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
        }

        public override void OnDetach()
        {
            //ModePager.SetCurrentItem(0, false);
            base.OnDetach();
        }

        public override void UnBind()
        {
            base.UnBind();
        }

        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(MaintenanceTicketStatusSection);
            sections.Add(UnitInformationSection);
            sections.Add(CommentsSection);
            sections.Add(GallerySection);
            if (ViewModel.CanUpdateRequest)
            {
                sections.Add(ActionBarSection);
            }

        }
    }
}