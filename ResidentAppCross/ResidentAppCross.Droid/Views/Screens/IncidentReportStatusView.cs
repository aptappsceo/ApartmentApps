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
using Android.Views;
using Android.Widget;
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
        
        public HeaderSection HeaderSection { get; set; }
        public TicketStatusSection TicketStatusSection { get; set; }
        public TextSection TextSection { get; set; }

        public override void Bind()
        {
            base.Bind();

            ModePager.Adapter = new IncidentReportStatusViewPagerAdapter() { PagesLayout = Layout };
            ModeTabs.SetupWithViewPager(ModePager);
            ModeTabs.Invalidate();

            HeaderSection.TitleLabel.Text = "Incident Report";
            HeaderSection.SubtitleLabel.Text = "Blablabla";

            var set = this.CreateBindingSet<IncidentReportStatusView, IncidentReportStatusViewModel>();

            set.Bind(TicketStatusSection.TypeLabel).For(f => f.Text).To(vm => vm.Request.IncidentType);
            set.Bind(TicketStatusSection.StatusLabel).For(f => f.Text).To(vm => vm.Request.Status);
            set.Bind(TicketStatusSection.LastRevisionLabel).For(f => f.Text).To(vm => vm.LastRevisionDate).WithFallback("-");

            set.Apply();

            TextSection.TextInput.Focusable = false;
            TextSection.TextInput.Text = Resources.GetString(Resource.String.lorem_ipsum);

        }

        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(TicketStatusSection);
            sections.Add(TextSection);
        }
    }




    public class IncidentReportStatusViewPagerAdapter : PagerAdapter
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
            if (position == 0) resId = Resource.Id.IncidentReportStatusView_StatusPage;
            else if (position == 1) resId = Resource.Id.IncidentReportStatusView_HistoryPage;
            else throw new Exception("Fuck");
            return PagesLayout?.FindViewById(resId);
        }
    }

}