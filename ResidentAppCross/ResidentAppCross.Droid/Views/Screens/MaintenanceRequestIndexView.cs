using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ApartmentApps.Client.Models;
using Java.Lang;
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
    public class MaintenanceRequestIndexView : ViewFragment<MaintenanceRequestIndexViewModel>
    {

        [Outlet]
        public RecyclerView ListContainer { get; set; }

        [Outlet]
        public TextView DescriptionLabel { get; set; }

        public override int LayoutId => typeof (IncidentReportIndexView).MatchingLayoutId();

        public override void Bind()
        {
            base.Bind();

            var adapter = new TicketIndexAdapter<MaintenanceIndexBindingModel>()
            {
                Items = ViewModel.FilteredRequests,
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
                IconSelector = i=> AppTheme.IconResByMaintenanceState(i.StatusId.AsMaintenanceStatus()),
                DateSelector = i => i.LatestCheckin?.Date?.ToString("g") ?? i.RequestDate?.ToString("g") ?? "-"
            };

            ListContainer.SetAdapter(new AlphaInAnimationAdapter(adapter));
            ListContainer.SetLayoutManager(new LinearLayoutManager(Context, LinearLayoutManager.Vertical, false));
            ListContainer.SetItemAnimator(new SlideInLeftAnimator());

            adapter.DetailsClicked += model =>
            {
                ViewModel.SelectedRequest = model;
                ViewModel.OpenSelectedRequestCommand.Execute(null);
            };

            var set = this.CreateBindingSet<MaintenanceRequestIndexView, MaintenanceRequestIndexViewModel>();
            set.Bind(DescriptionLabel).For(x => x.Text).To(vm => vm.CurrentFilter.MarkerTitle);
            set.Apply();
            
            this.OnViewModelEvent<RequestsIndexFiltersUpdatedEvent>(evt =>
            {
                UpdateSecondaryInformation();
            });
            UpdateSecondaryInformation();

    

            ViewModel.UpdateRequestsCommand.Execute(null);


            if(ViewModel.CurrentFilter == null)
            ViewModel.CurrentFilter = ViewModel.Filters.FirstOrDefault();


        }

        public void UpdateSecondaryInformation()
        {
            if (string.IsNullOrEmpty(ViewModel?.CurrentFilter?.MarkerTitle)) DescriptionLabel.Visibility = ViewStates.Gone;
            else DescriptionLabel.Visibility = ViewStates.Visible;
        }
        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            base.OnCreateOptionsMenu(menu, inflater);

            inflater.Inflate(Resource.Menu.maintenance_request_index_view_menu,menu);
            FilterItem = menu.FindItem(Resource.Id.FilterButton);
            FilterItem.SetTitle(ViewModel?.CurrentFilter?.Title);
            var groupId = ViewModel.GetHashCode();

            foreach (var filter in ViewModel.Filters)
            {
                var item = FilterItem.SubMenu.Add(groupId,filter.GetHashCode(),0,filter.Title);
                item.SetShowAsAction(ShowAsAction.Never);
                item.SetIcon(filter.Icon.ToDrawableId());
            }

            var addTicketItem = menu.Add(groupId, Resource.Id.AddButton, 0, "Add");
            addTicketItem.SetIcon(Resource.Drawable.ticket_add_icon);
            addTicketItem.SetShowAsAction(ShowAsAction.Always);
        }

        public override void OnDetach()
        {
            base.OnDetach();
            FilterItem = null;
        }

        public IMenuItem FilterItem { get; set; }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (ViewModel.GetHashCode() != item.GroupId) return base.OnOptionsItemSelected(item);

            if (item.ItemId == Resource.Id.AddButton)
            {
                ViewModel.OpenMaintenanceRequestFormCommand.Execute(null);
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
                    return $"Maintenance Requests";
            }
        }


    }

    public static class StringExtensions
    {
        public static ICharSequence ToJString(this string str)
        {
            return new Java.Lang.String(str);
        }        
    }
}