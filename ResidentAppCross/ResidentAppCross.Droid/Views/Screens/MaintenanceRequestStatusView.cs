using System;
using System.Collections.Generic;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using ApartmentApps.Client.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
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
        public TicketStatusSection TicketStatusSection { get; set; }
        public TextSection CommentsSection { get; set; }
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
                ActionBarSection.Update();
                UnitInformationSection.AvatarUrl = ViewModel?.Request?.User.ImageUrl;
            });

            GallerySection?.Bind(ViewModel.Photos);


            HistoryPage.SetAdapter(new TicketHistoryAdapter<MaintenanceCheckinBindingModel>()
            {
                Items = ViewModel.Checkins,
                TitleSelector = s => s.StatusId,
                SubtitleSelector = s => s.Date?.ToString("g")
            });


            ModePager.Adapter = new TicketStatusViewPagerAdapter() { PagesLayout = Layout };
            ModeTabs.SetupWithViewPager(ModePager);
            ModeTabs.Invalidate();

            HeaderSection.TitleLabel.Text = "Maintenance Request";
            HeaderSection.SubtitleLabel.Text = "Submitted 12.02.2016 12:20 AM";

            var set = this.CreateBindingSet<MaintenanceRequestStatusView, MaintenanceRequestStatusViewModel>();

            set.Bind(TicketStatusSection.TypeLabel).For(f => f.Text).To(vm => vm.Request.Name);
            set.Bind(TicketStatusSection.StatusLabel).For(f => f.Text).To(vm => vm.Request.Status);
            set.Bind(TicketStatusSection.CreatedOnLabel).For(f => f.Text).To(vm => vm.ScheduleDateLabel).WithFallback("-");
            set.Bind(CommentsSection.TextInput).For(t => t.Text).To(vm => vm.Request.Message).WithFallback("-");
            set.Bind(UnitInformationSection).For(s => s.AvatarUrl).To(vm => vm.Request.User.ImageUrl);
            set.Apply();

            CommentsSection.TextInput.Focusable = false;

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

        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(TicketStatusSection);
            if (ViewModel.CanUpdateRequest)
            {
                sections.Add(ActionBarSection);
            }
            sections.Add(UnitInformationSection);
            sections.Add(CommentsSection);
            sections.Add(GallerySection);
            
        }
    }

    [MvxFragment(typeof (ApplicationViewModel), Resource.Id.application_host_container_primary,true)]
    public class CheckinFormView : SectionViewFragment<CheckinFormViewModel>
    {
        public override int LayoutId => DefaultLayoutId;

        public HeaderSection HeaderSection { get; set; }
        public TextSection CommentsSection { get; set; }
        public ActionBarSection ActionBar { get; set; }
        public GallerySection PhotoSection { get; set; }

        public override void Bind()
        {
            base.Bind();


            HeaderSection.TitleLabel.Text = ViewModel.HeaderText;
            HeaderSection.SubtitleLabel.Text = "Fill in any additional notes";


            var set = this.CreateBindingSet<CheckinFormView, CheckinFormViewModel>();
            set.Bind(CommentsSection.TextInput).TwoWay().To(vm => vm.Comments);
            set.Apply();

            CommentsSection.HeaderLabel.Text = "Comments & Details:";

            PhotoSection.Bind(ViewModel.Photos);

            ActionBar.SetItems(new ActionBarSection.ActionBarItem()
            {
                Action = () => ViewModel.SubmitCheckinCommand.Execute(null),
                Title = ViewModel.ActionText,
            });
        }


        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(CommentsSection);
            sections.Add(PhotoSection);
            sections.Add(ActionBar);
        }
    }
}