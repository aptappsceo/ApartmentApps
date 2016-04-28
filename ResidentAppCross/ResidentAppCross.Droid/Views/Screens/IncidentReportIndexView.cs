using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ApartmentApps.Client.Models;
using MvvmCross.Binding.BindingContext;
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
    public class IncidentReportIndexView : ViewFragment<IncidentReportIndexViewModel>
    {

        [Outlet]
        public RecyclerView ListContainer { get; set; }

        [Outlet]
        public TextView DescriptionLabel { get; set; }

        public override void Bind()
        {
            base.Bind();

            var adapter = new TicketIndexAdapter<IncidentIndexBindingModel>()
            {
                Items = ViewModel.FilteredIncidents,
                TitleSelector = i => i.UnitName,
                SubTitleSelector = i => i.Title,
                DetailsSelector = i =>
                {
                    if (i.LatestCheckin == null)
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
                DateSelector = i => i.LatestCheckin?.Date?.ToString("g") ?? i.RequestDate?.ToString("g") ?? "-",
                ColorResourceSelector = i=> AppTheme.ColorResByIncidentState(i.StatusId.AsIncidentStatus()),
                IconSelector = i=> AppTheme.IconResByIncidentState(i.StatusId.AsIncidentStatus())
            };

            adapter.DetailsClicked += model =>
            {
                ViewModel.SelectedIncident = model;
                ViewModel.OpenSelectedIncidentCommand.Execute(null);
            };

            var set = this.CreateBindingSet<IncidentReportIndexView, IncidentReportIndexViewModel>();
            set.Bind(DescriptionLabel).For(x => x.Text).To(vm => vm.CurrentFilter.MarkerTitle);
            set.Apply();

            this.OnViewModelEvent<IncidentsIndexFiltersUpdatedEvent>(evt =>
            {
                UpdateSecondaryInformation();
            });
            UpdateSecondaryInformation();

            ListContainer.SetAdapter(new AlphaInAnimationAdapter(adapter));
            ListContainer.SetLayoutManager(new LinearLayoutManager(Context,LinearLayoutManager.Vertical,false));
            ListContainer.SetItemAnimator(new SlideInLeftAnimator());

            ViewModel.UpdateIncidentsCommand.Execute(null);
            if (ViewModel.CurrentFilter == null)
                ViewModel.CurrentFilter = ViewModel.Filters.FirstOrDefault();
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            base.OnCreateOptionsMenu(menu, inflater);

            inflater.Inflate(Resource.Menu.maintenance_request_index_view_menu, menu);
            FilterItem = menu.FindItem(Resource.Id.FilterButton);
            FilterItem.SetTitle(ViewModel?.CurrentFilter?.Title);

            var groupId = ViewModel.GetHashCode();


            foreach (var filter in ViewModel.Filters)
            {
                var item = FilterItem.SubMenu.Add(groupId, filter.GetHashCode(), 0, filter.Title);
                item.SetShowAsAction(ShowAsAction.Never);
                item.SetIcon(filter.Icon.ToDrawableId());
            }
            UpdateTitle();

            var addTicketItem = menu.Add(groupId, Resource.Id.AddButton, 0, "Add");
            addTicketItem.SetIcon(Resource.Drawable.ticket_add_icon);
            addTicketItem.SetShowAsAction(ShowAsAction.Always);

        }

        public override void OnDetach()
        {
            base.OnDetach();
            FilterItem = null;
        }
        public void UpdateSecondaryInformation()
        {
            if (string.IsNullOrEmpty(ViewModel?.CurrentFilter?.MarkerTitle)) DescriptionLabel.Visibility = ViewStates.Gone;
            else DescriptionLabel.Visibility = ViewStates.Visible;
        }
        public IMenuItem FilterItem { get; set; }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (ViewModel.GetHashCode() != item.GroupId) return base.OnOptionsItemSelected(item);

            if (item.ItemId == Resource.Id.AddButton)
            {
                ViewModel.OpenIncidentReportFormCommand.Execute(null);
                return true;
            }
            //filter?
            var filter = ViewModel.Filters.FirstOrDefault(f => f.GetHashCode() == item.ItemId);
            if (filter == null) return base.OnOptionsItemSelected(item);
            FilterItem?.SetTitle(filter.Title);
            ViewModel.CurrentFilter = filter;

            ListContainer.SmoothScrollToPosition(0);

            UpdateTitle();
            return true;


        }


        public override string Title
        {
            get
            {
                if (!string.IsNullOrEmpty(ViewModel?.CurrentFilter?.MarkerTitle))
                {
                    return $"Incident Reports ({ViewModel?.CurrentFilter?.Title ?? "All"})";
                }
                else
                {
                    return $"Incident Reports";
                }
            }
        }

    }
}