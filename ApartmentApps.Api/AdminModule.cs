using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules
{

    public interface IPortalComponent
    {
        ComponentViewModel Execute();
    }

    public interface IPortalComponentTyped<TResultViewModel> where TResultViewModel : ComponentViewModel
    {
        TResultViewModel ExecuteResult();
    }

    public abstract class PortalComponent<TResultViewModel> : IPortalComponent, IPortalComponentTyped<TResultViewModel> where TResultViewModel : ComponentViewModel
    {
        public abstract TResultViewModel ExecuteResult();

        public ComponentViewModel Execute()
        {
            return ExecuteResult();
        }
    }

    public enum DashboardArea
    {
        LeftTop,
        Left,
        RightTop,
        Right
    }
    public interface IDashboardComponentProvider
    {
        void PopulateComponents(DashboardArea areaName, List<ComponentViewModel> dashboardComponents);
    }

    public enum DashboardComponentPosition
    {
        Left,
        Center,
        Right
    }

    public class DashboardStatViewModel : ComponentViewModel
    {
        public string Subtitle { get; set; }
        public string Value { get; set; }
       
    }
    public class ComponentViewModel : BaseViewModel
    {
        //public string Col { get; set; }
        public string Stretch { get; set; }
        public decimal Row { get; set; }
    }

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
    public class DashboardPieViewModel : ComponentViewModel
    {
        private Type _dataType;
        public ChartData[] Data { get; set; }

        public class ChartData
        {
            public string label { get; set; }
            public int data { get; set; }
        }
        public string Subtitle { get; set; }

        public Type DataType
        {
            get
            {
                if (_dataType == null)
                {
                    var firstItem = ListData.FirstOrDefault();
                    if (firstItem != null) return firstItem.GetType();
                }
                return _dataType;
            }
            set { _dataType = value; }
        }

        public IEnumerable<object> ListData { get; set; }

        public DashboardPieViewModel(string title, string subTitle, decimal row, params ChartData[] chartData)
        {
            Data = chartData;
            Stretch = "col-md-12";
            Title = title;
            Subtitle = subTitle;
            Row = row;
        }
    }
    public class CompanySettingsModule : Module<CompanySettingsConfig>, IAdminConfigurable
    {
        public CompanySettingsModule(IKernel kernel, IRepository<CompanySettingsConfig> configRepo, IUserContext userContext) : base(kernel, configRepo, userContext)
        {
        }

        public string SettingsController => "CompanySettingsConfig";
    }

    public class AdminModule : Module<PortalConfig>, IMenuItemProvider, IFillActions, IDashboardComponentProvider
    {

        public void PopulateComponents(DashboardArea area, List<ComponentViewModel> dashboardComponents)
        {
            if (!UserContext.IsInRole("Admin") && !UserContext.IsInRole("PropertyAdmin"))
                return;

            var mrRepo = new BaseRepository<MaitenanceRequest>(Kernel.Get<ApplicationDbContext>());
      
            var totalRequestsAllProperties = mrRepo.Count(p => p.Property.State == PropertyState.Active);
            
            var activeProperties = mrRepo
               
                .GroupBy(p => p.Property)
                .Where(p=>p.Key.State == PropertyState.Active)
                .Select(x=>new Tuple<Property,int>(x.Key,x.Count()))
                .ToArray();

            if (area == DashboardArea.LeftTop)
            {
                dashboardComponents.Add(new DashboardTitleViewModel("Admin Stats","Note: Only admins can see this.",0));
                dashboardComponents.Add(new DashboardStatViewModel()
                {
                    Row = 1,
                    Stretch = "col-md-6",
                    Title = "Total Work Orders",
                    Value = totalRequestsAllProperties.ToString(),
                    Subtitle = "All Properties"
                });
                //dashboardComponents.Add(new DashboardStatViewModel()
                //{
                //    Row = 1,
                //    Stretch = "col-md-6",
                //    Title = "Engaging Properties",
                //    //Subtitle = "Properties that are actively using the app.",
                //    Value = activeProperties.Count(x=>x.Item2 > 0).ToString() ,
                //    Subtitle = $"of {Kernel.Get<IRepository<Property>>().Count(p=>p.State == PropertyState.Active)} active total"
                //});
                var active = activeProperties.Count(x => x.Item2 > 0);
                var inActive = Kernel.Get<IRepository<Property>>().Count(p => p.State == PropertyState.Active) - active;

                dashboardComponents.Add(
                    new DashboardPieViewModel("Engaging Properties","Properties actively using",1,
                    new DashboardPieViewModel.ChartData() {label = "Active", data=active },
                    new DashboardPieViewModel.ChartData() {label = "In-Active", data=inActive })
                    {
                        Stretch = "col-md-6",
                       // ListData = 
                    });

            }
        }

        public override PortalConfig Config => new PortalConfig()
        {
            Enabled = true,
            PropertyId = UserContext.PropertyId,
            Id = 0
        };

        public AdminModule(IKernel kernel, IUserContext userContext) : base(kernel, null, userContext)
        {
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            if (UserContext.IsInRole("PropertyAdmin"))
            {
                var checkins = new MenuItemViewModel("Settings", "fa-cog", 30);

                checkins.Children.Add(new MenuItemViewModel("Users", "fa-user", "Index", "UserManagement"));
                checkins.Children.Add(new MenuItemViewModel("Courtesy Locations", "fa-location-arrow", "Index",
                    "CourtesyOfficerLocations"));
                checkins.Children.Add(new MenuItemViewModel("Buildings", "fa-building", "Index", "Buildings"));
                checkins.Children.Add(new MenuItemViewModel("Units", "fa-bed", "Index", "Units"));
                menuItems.Add(checkins);
            }
            if (UserContext.IsInRole("Admin"))
            {


                var checkins = new MenuItemViewModel("AA Admin", "fa-heartbeat") {Index = Int32.MaxValue};
                foreach (var module in Kernel.GetAll<IModule>().OfType<IAdminConfigurable>())
                {
                    checkins.Children.Add(new MenuItemViewModel(module.Name, "fa-gear", "Index",
                        module.SettingsController));
                }

                checkins.Children.Add(new MenuItemViewModel("Corporations", "fa-suitcase", "Index", "Corporations"));
                checkins.Children.Add(new MenuItemViewModel("Properties", "fa-cubes", "Index", "Property"));
                checkins.Children.Add(new MenuItemViewModel("Entrata Accounts", "fa-group", "Index",
                    "PropertyEntrataInfo"));
                menuItems.Add(checkins);
            }
            if (UserContext.IsInRole("PropertyAdmin") || UserContext.IsInRole("Admin"))
            {
                menuItems.Add(new MenuItemViewModel("Dashboard", "fa-group", "Index", "Dashboard"));
            }
        }

        public void FillActions(List<ActionLinkModel> actions, object viewModel)
        {
            //   <a class="btn btn-white btn-xs modal-link" href="@Url.Action("Entry", "UserManagement", new {id = item.Id})"><i class="fa fa-edit"></i> Edit</a>
            //< a class="btn btn-white btn-xs" href="@Url.Action("Delete", "UserManagement", new {id = item.Id})"><i class="fa fa-remove"></i> Delete</a>

            var vm = viewModel as UserBindingModel;
            if (vm != null)
            {
                if (!vm.Archived)
                {
                    actions.Add(new ActionLinkModel("Archive", "Delete", "UserManagement", new { id = vm.Id })
                    {
                        Icon = "fa-remove"
                    });
                }
              
                actions.Add(new ActionLinkModel("Edit", "Entry", "UserManagement", new {id = vm.Id})
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });

                if (vm.Archived)
                {
                    actions.Add(new ActionLinkModel("Unarchive", "Unarchive", "UserManagement", new { id = vm.Id })
                    {
                        
                    });
                }
            }

            if (!UserContext.IsInRole("Admin")) return;

            var unitViewModel = viewModel as UnitViewModel;
            if (unitViewModel != null)
            {
                actions.Add(new ActionLinkModel("Delete", "Delete", "Units", new {id = unitViewModel.Id})
                {
                    Icon = "fa-remove",
                });
                actions.Add(new ActionLinkModel("Edit", "Entry", "Units", new {id = unitViewModel.Id})
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });
            }
            var buildingViewModel = viewModel as BuildingViewModel;
            if (buildingViewModel != null)
            {
                actions.Add(new ActionLinkModel("Delete", "Delete", "Buildings", new {id = buildingViewModel.Id})
                {
                    Icon = "fa-remove",
                });
                actions.Add(new ActionLinkModel("Edit", "Entry", "Buildings", new {id = buildingViewModel.Id})
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });
            }
            var propertyViewModel = viewModel as PropertyBindingModel;
            if (propertyViewModel != null)
            {

                //actions.Add(new ActionLinkModel("Delete", "Delete", "Property", new { id = vm.Id }));
                actions.Add(new ActionLinkModel("Edit", "Entry", "Property", new {id = propertyViewModel.Id})
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });

                actions.Add(new ActionLinkModel("Switch To Property", "ChangeProperty", "Account",
                    new {id = propertyViewModel.Id})
                {
                    Icon = "fa-sign-in",
                });
              actions.Add(new ActionLinkModel("Import Residents/Units", "ImportResidentCSV", "Property", new { propertyId = propertyViewModel.Id }));

            }
        }

    }
}