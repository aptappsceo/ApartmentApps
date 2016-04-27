using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ApartmentApps.Client.Models;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class IncidentReportStatusView : SectionViewFragment<IncidentReportStatusViewModel>
    {
        private HeaderSection _headerSection;

        [Outlet]
        public ViewPager ModePager { get; set; }

        [Outlet]
        public TabLayout ModeTabs { get; set; }

        [Outlet]
        public RecyclerView HistoryPage { get; set; }
        
        public HeaderSection HeaderSection { get; set; }
        public IncidentTicketStatusSection IncidentTicketStatusSection { get; set; }
        public NoneditableTextSection CommentsSection { get; set; }
        public GallerySection GallerySection { get; set; }
        public UnitInformationSection UnitInformationSection { get; set; }
        public ActionBarSection ActionBarSection { get; set; }

        public override void Bind()
        {
            base.Bind();

            //Header section

            //Setup stuff everytime we update status
            this.OnViewModelEvent<IncidentReportStatusUpdated>(evt =>
            {
                ActionBarSection.Update();
                //UnitInformationSection.AvatarUrl = ViewModel?.Request?.User.ImageUrl;


                HeaderSection.IconView.SetImageResource(AppTheme.IconResByIncidentState(ViewModel.Request.Status.AsIncidentStatus()));
                var color = Resources.GetColor(Resource.Color.secondary_text_body);
                HeaderSection.IconView.SetColorFilter(color);

                if (string.IsNullOrEmpty(ViewModel?.Request?.BuildingName?.Trim()))
                    HeaderSection.SubtitleLabel.Text = "Unit Infromation Missing";
                else
                    HeaderSection.SubtitleLabel.Text = ViewModel.Request.BuildingName;

            });

            GallerySection?.Bind(ViewModel.Photos);


            HistoryPage.SetAdapter(new TicketHistoryAdapter<IncidentCheckinBindingModel>()
            {
                Items = ViewModel.Checkins,
                TitleSelector = s => s.StatusId,
                SubtitleSelector = s => s.Date?.ToString("g"),
                ItemSelected = item =>
                {
                    ViewModel.SelectedCheckin = item;
                    ViewModel.ShowCheckinDetailsCommand.Execute(null);
                },
                IconResourceSelector = i => AppTheme.StatusIconResByIncidentState(i.StatusId.AsIncidentStatus())
            });


            ModePager.Adapter = new TicketStatusViewPagerAdapter() { PagesLayout = Layout };
            ModePager.SetCurrentItem(0,false);
            ModeTabs.SetupWithViewPager(ModePager);
            ModeTabs.Invalidate();

            HeaderSection.TitleLabel.Text = "Incident Report";

            var set = this.CreateBindingSet<IncidentReportStatusView, IncidentReportStatusViewModel>();

            set.Bind(IncidentTicketStatusSection.TypeLabel).For(f => f.Text).To(vm => vm.Request.IncidentType);
            set.Bind(IncidentTicketStatusSection.StatusLabel).For(f => f.Text).To(vm => vm.Request.Status);
            //et.Bind(MaintenanceTicketStatusSection.CreatedOnLabel).For(f => f.Text).To(vm => vm.ScheduleDateLabel).WithFallback("-");
            set.Bind(CommentsSection.InputField).For(t => t.Text).To(vm => vm.Request.Comments).WithFallback("-");
            set.Bind(UnitInformationSection).For(s => s.AvatarUrl).To(vm => vm.Request.Requester.ImageUrl);


            set.Bind(UnitInformationSection.NameLabel)
              .For(t => t.Text)
              .To(vm => vm.Request.Requester.FullName)
              .WithFallback("-");
            set.Bind(UnitInformationSection.AddressLabel)
                .For(t => t.Text)
                .To(vm => vm.Request.Requester.Address)
                .WithFallback("-");
            set.Bind(UnitInformationSection.EmailLabel)
                .For(t => t.Text)
                .To(vm => vm.Request.Requester.PostalCode)
                .WithFallback("-");
            set.Bind(UnitInformationSection.PhoneLabel)
                .For(t => t.Text)
                .To(vm => vm.Request.Requester.PhoneNumber)
                .WithFallback("-");

            set.Apply();

            //CommentsSection.InputField.Focusable = false;

            HistoryPage.SetLayoutManager(new LinearLayoutManager(Context, LinearLayoutManager.Vertical, false));

            ActionBarSection.SetItems(
                new ActionBarSection.ActionBarItem()
                {
                    Title = "Open",
                    Action = () => ViewModel.OpenIncidentCommand.Execute(null),
                    IsAvailable = () => ViewModel.Request != null && ViewModel.OpenIncidentCommand.CanExecute(null)
                }, new ActionBarSection.ActionBarItem()
                {
                    Title = "Close",
                    Action = () => ViewModel.CloseIncidentCommand.Execute(null),
                    IsAvailable = () => ViewModel.Request != null && ViewModel.CloseIncidentCommand.CanExecute(null)
                }, new ActionBarSection.ActionBarItem()
                {
                    Title = "Pause",
                    Action = () => ViewModel.PauseIncidentCommmand.Execute(null),
                    IsAvailable = () => ViewModel.Request != null && ViewModel.PauseIncidentCommmand.CanExecute(null)
                }
            );


        }


        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(IncidentTicketStatusSection);
            sections.Add(UnitInformationSection);
            sections.Add(CommentsSection);
            sections.Add(GallerySection);
            if (ViewModel.CanUpdateRequest)
            {
                sections.Add(ActionBarSection);
            }

        }
    }

    public class TicketStatusViewPagerAdapter : PagerAdapter
    {

        public View PagesLayout { get; set; }

        public override bool IsViewFromObject(View view, Object objectValue)
        {
            return view == ((View) objectValue);
        }
        
        public override int Count => 2;

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            string res = "Fuck";
            if (position == 0) res = "Status";
            else if (position == 1) res = "History";
            return new Java.Lang.String(res); ;
        }

        public override Object InstantiateItem(View container, int position)
        {
            int resId = 0;
            if (position == 0) resId = Resource.Id.StatusPage;
            else if (position == 1) resId = Resource.Id.HistoryPage;
            else throw new Exception("Fuck");
            return PagesLayout?.FindViewById(resId);
        }
    }
}