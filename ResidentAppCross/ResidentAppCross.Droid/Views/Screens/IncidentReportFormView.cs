using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class IncidentReportFormView : SectionViewFragment<IncidentReportFormViewModel>
    {
        public override int LayoutId => DefaultLayoutId;

        public HeaderSection HeaderSection { get; set; }
        public RadioSection IncidentReportTypeSelection { get; set; }
        public TextSection CommentsSection { get; set; }
        public ActionBarSection ActionBar { get; set; }
        public GallerySection PhotoSection { get; set; }

        public override void Bind()
        {
            base.Bind();

            var set = this.CreateBindingSet<IncidentReportFormView, IncidentReportFormViewModel>();
            HeaderSection.TitleLabel.Text = "Report Incident";

            set.Bind(CommentsSection.InputField).TwoWay().To(vm => vm.Comments);
            set.Apply();

            IncidentReportTypeSelection.BindToList(ViewModel.IncidentReportTypes, i => i.Title, x => ViewModel.SelectIncidentReportTypeId = x.Id);

            IncidentReportTypeSelection.Label.Text = "What kind of problem you want to report?";

            CommentsSection.HeaderLabel.Text = "Comments & Details:";

            PhotoSection.Bind(ViewModel.Photos);
            PhotoSection.Editable = true;
            ActionBar.SetItems(new ActionBarSection.ActionBarItem()
            {
                Action = () => ViewModel.DoneCommand.Execute(null),
                Title = "Submit"
            });

            HeaderSection.IconView.SetImageResource(Resource.Drawable.police_plus);
            HeaderSection.IconView.SetColorFilter(Resources.GetColor(Resource.Color.secondary_text_body));
        }


        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(IncidentReportTypeSelection);
            sections.Add(CommentsSection);
            sections.Add(PhotoSection);
            sections.Add(ActionBar);
        }
    }
}