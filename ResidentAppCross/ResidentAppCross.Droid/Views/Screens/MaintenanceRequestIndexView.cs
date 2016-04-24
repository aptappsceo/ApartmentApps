using Android.Support.V7.Widget;
using ApartmentApps.Client.Models;
using MvvmCross.Droid.Shared.Attributes;
using RecyclerViewAnimators.Adapters;
using RecyclerViewAnimators.Animators;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof(ApplicationViewModel),Resource.Id.application_host_container_primary)]
    public class MaintenanceRequestIndexView : ViewFragment<MaintenanceRequestIndexViewModel>
    {

        [Outlet]
        public RecyclerView ListContainer { get; set; }

        public override int LayoutId => typeof (IncidentReportIndexView).MatchingLayoutId();

        public override void Bind()
        {
            base.Bind();

            var adapter = new TicketIndexAdapter<MaintenanceIndexBindingModel>()
            {
                Items = ViewModel.Requests,
                TitleSelector = i=>i.UnitName,
                SubTitleSelector = i=>i.Title,
                DetailsSelector = i =>
                {
                    if (i.StatusId == "Scheduled")
                    {
                        return i.LatestCheckin.Comments?.Trim();
                    } else if (i.LatestCheckin == null)
                    {
                        if (string.IsNullOrEmpty(i.Comments))
                        {
                            return $"Submitted with no comments";
                        }
                        else
                        {
                            return $"Submitted: {i.Comments?.Trim()}";
                        }
                    }
                    else if (string.IsNullOrEmpty(i.LatestCheckin?.Comments))
                    {
                        return $"{i.StatusId} with no comments.";
                    }
                    else
                    {
                        return $"{i.StatusId}: {i.LatestCheckin?.Comments?.Trim()}";
                    }
                },
                ColorResourceSelector = i=> AppTheme.ColorResByMaintenanceState(i.StatusId.AsMaintenanceStatus()),
                DateSelector = i => i.LatestCheckin?.Date?.ToString("g") ?? i.RequestDate?.ToString("g") ?? "-"
            };

            adapter.DetailsClicked += model =>
            {
                ViewModel.SelectedRequest = model;
                ViewModel.OpenSelectedRequestCommand.Execute(null);
            };

            ListContainer.SetAdapter(new AlphaInAnimationAdapter(adapter));
            ListContainer.SetLayoutManager(new LinearLayoutManager(Context,LinearLayoutManager.Vertical,false));
            ListContainer.SetItemAnimator(new SlideInLeftAnimator());

            ViewModel.UpdateRequestsCommand.Execute(null);

        }

    }
}