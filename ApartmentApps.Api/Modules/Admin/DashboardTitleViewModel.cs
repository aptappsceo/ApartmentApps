namespace ApartmentApps.Api.Modules
{
    public class DashboardTitleViewModel : ComponentViewModel
    {
        public string Subtitle { get; set; }
        public DashboardTitleViewModel(string title, string subTitle, decimal row)
        {
            Stretch = "col-md-12";
            Title = title;
            Subtitle = subTitle;
            Row = row;
        }
    }
}