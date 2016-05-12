using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Droid.Views
{
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
            set.Bind(CommentsSection.InputField).TwoWay().To(vm => vm.Comments);
            set.Apply();

            CommentsSection.HeaderLabel.Text = "Comments & Details:";

            PhotoSection.Bind(ViewModel.Photos);
            PhotoSection.Editable = true;
            ActionBar.SetItems(new ActionBarSection.ActionBarItem()
            {
                Action = () => ViewModel.SubmitCheckinCommand.Execute(null),
                Title = ViewModel.ActionText,
            });
        }

        public override string Title => "Courtesy Checkins";

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