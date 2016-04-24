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

            set.Bind(CommentsSection.TextInput).TwoWay().To(vm => vm.Comments);
            set.Apply();

            IncidentReportTypeSelection.BindToList(ViewModel.IncidentReportTypes, i => i.Title, x => ViewModel.SelectIncidentReportTypeId = x.Id);

            IncidentReportTypeSelection.Label.Text = "What kind of problem you want to report?";

            CommentsSection.HeaderLabel.Text = "Comments & Details:";

            PhotoSection.Bind(ViewModel.Photos);

            ActionBar.SetItems(new ActionBarSection.ActionBarItem()
            {
                Action = () => ViewModel.DoneCommand.Execute(null),
                Title = "Submit"
            });
        }


        public override void GetContent(List<FragmentSection> sections)
        {
            base.GetContent(sections);
            sections.Add(HeaderSection);
            sections.Add(CommentsSection);
            sections.Add(PhotoSection);
            sections.Add(IncidentReportTypeSelection);
            sections.Add(ActionBar);
        }
    }
}