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
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary)]
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
        public TicketStatusSection TicketStatusSection { get; set; }
        public TextSection TextSection { get; set; }
        public GallerySection GallerySection { get; set; }

        public override void Bind()
        {
            base.Bind();


            this.OnViewModelEvent<IncidentReportStatusUpdated>(evt =>
            {
                GallerySection?.Bind(ImageGalleryUtils.GetTestAsyncImages());
                HistoryPage.SetAdapter(new TicketHistoryAdapter<IncidentCheckinBindingModel>()
                {
                    Items = ViewModel.Checkins,
                    TitleSelector = s=>s.StatusId,
                    SubtitleSelector = s=>s.Date?.ToString("g")
                });
            });


            ModePager.Adapter = new TicketStatusViewPagerAdapter() { PagesLayout = Layout };
            ModeTabs.SetupWithViewPager(ModePager);
            ModeTabs.Invalidate();

            HeaderSection.TitleLabel.Text = "Incident Report";
            HeaderSection.SubtitleLabel.Text = "Blablabla";

            var set = this.CreateBindingSet<IncidentReportStatusView, IncidentReportStatusViewModel>();

            set.Bind(TicketStatusSection.TypeLabel).For(f => f.Text).To(vm => vm.Request.IncidentType);
            set.Bind(TicketStatusSection.StatusLabel).For(f => f.Text).To(vm => vm.Request.Status);
            set.Bind(TicketStatusSection.CreatedOnLabel).For(f => f.Text).To(vm => vm.CreatedDate).WithFallback("-");

            set.Apply();

            TextSection.TextInput.Focusable = false;
            TextSection.TextInput.Text = Resources.GetString(Resource.String.lorem_ipsum);

            HistoryPage.SetLayoutManager(new LinearLayoutManager(Context,LinearLayoutManager.Vertical,false));

        }



        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(TicketStatusSection);
            sections.Add(TextSection);
            sections.Add(GallerySection);
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