using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof (ApplicationViewModel), Resource.Id.application_host_container_primary)]
    public class MaterialPlaygroundFragment1 : ViewFragment<DevelopmentViewModel1>
    {
        private Switch _toolbarToggle;
     

        public override int LayoutId => Resource.Layout.material_playground_fragment_1;

        public Switch ToolbarToggle
        {
            get { return _toolbarToggle ?? (_toolbarToggle = Layout.FindViewById<Switch>(Resource.Id.show_toolbar_switch)); }
            set { _toolbarToggle = value; }
        }

        public override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            ToolbarToggle.Checked = true;
            ToolbarToggle.CheckedChange += (sender, args) =>
            {
                if (ToolbarToggle.Checked)
                {
                    Toolbar.Show();
                }
                else
                {
                    Toolbar.Hide();
                }
            };

            for (int i = 0; i < 15; i++)
            {
                Layout.AddView(new TextView(Context)
                {
                    Text = "Mega Trolololo"
                }.WithWidthMatchParent().WithHeight(40));
            }

        }
    }
}