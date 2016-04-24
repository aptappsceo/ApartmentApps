using Android.Support.V7.Widget;
using ApartmentApps.Client.Models;
using MvvmCross.Droid.Shared.Attributes;
using RecyclerViewAnimators.Adapters;
using RecyclerViewAnimators.Animators;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof(ApplicationViewModel),Resource.Id.application_host_container_primary)]
    public class IncidentReportIndexView : ViewFragment<IncidentReportIndexViewModel>
    {

        [Outlet]
        public RecyclerView ListContainer { get; set; }

        public override void Bind()
        {
            base.Bind();

            var adapter = new TicketIndexAdapter<IncidentIndexBindingModel>()
            {
                Items = ViewModel.Incidents,
                TitleSelector = i => i.UnitName,
                SubTitleSelector = i => i.Title,
                DetailsSelector = i =>
                {
                    if (i.LatestCheckin == null)
                    {
                        return $"Reported: {i.Comments}";
                    }
                    else if (string.IsNullOrEmpty(i.LatestCheckin.Comments.Trim()))
                    {
                        return $"{i.StatusId} with no comments.";
                    }
                    else
                    {
                        return $"{i.StatusId}: {i.LatestCheckin.Comments.Trim()}";
                    }
                },
                DateSelector = i => i.LatestCheckin?.Date?.ToString("g") ?? i.RequestDate?.ToString("g") ?? "-"
            };

            adapter.DetailsClicked += model =>
            {
                ViewModel.SelectedIncident = model;
                ViewModel.OpenSelectedIncidentCommand.Execute(null);
            };

            ListContainer.SetAdapter(new AlphaInAnimationAdapter(adapter));
            ListContainer.SetLayoutManager(new LinearLayoutManager(Context,LinearLayoutManager.Vertical,false));
            ListContainer.SetItemAnimator(new SlideInLeftAnimator());

            ViewModel.UpdateIncidentsCommand.Execute(null);

        }

    }
}