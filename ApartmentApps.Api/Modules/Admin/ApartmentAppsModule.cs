using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class ApartmentAppsModule : Module<PortalConfig>, IMenuItemProvider, IFillActions, IDashboardComponentProvider, IWebJob
    {

        public void PopulateComponents(DashboardArea area, List<ComponentViewModel> dashboardComponents)
        {
            if (!UserContext.IsInRole("Admin") && !UserContext.IsInRole("PropertyAdmin"))
                return;

            var mrRepo = new BaseRepository<MaitenanceRequest>(Kernel.Get<ApplicationDbContext>());

            var totalRequestsAllProperties = mrRepo.Count(p => p.Property.State == PropertyState.Active);

            var activeProperties = mrRepo

                .GroupBy(p => p.Property)
                .Where(p => p.Key.State == PropertyState.Active)
                .Select(x => new Tuple<Property, int>(x.Key, x.Count()))
                .ToArray();

            if (area == DashboardArea.LeftTop)
            {
                dashboardComponents.Add(new DashboardTitleViewModel("Admin Stats", "Note: Only admins can see this.", 0));
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
                    new DashboardPieViewModel("Engaging Properties", "Properties actively using", 1,
                    new DashboardPieViewModel.ChartData() { label = "Active", data = active },
                    new DashboardPieViewModel.ChartData() { label = "In-Active", data = inActive })
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

        public ApartmentAppsModule(IKernel kernel, IUserContext userContext) : base(kernel, null, userContext)
        {
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            if (UserContext.IsInRole("Tester"))
            {
                var viewAsItems = new MenuItemViewModel("View As", "fa-cog", 30);

                viewAsItems.Children.Add(new MenuItemViewModel("Admin", "fa-user", "ViewAsAdmin", "Tester"));
                viewAsItems.Children.Add(new MenuItemViewModel("Property Admin", "fa-user", "ViewAsPropertyAdmin", "Tester"));
                viewAsItems.Children.Add(new MenuItemViewModel("Tech Supervisor", "fa-user", "ViewAsTechSupervisor", "Tester"));
                viewAsItems.Children.Add(new MenuItemViewModel("Tech", "fa-user", "ViewAsTech", "Tester"));
                viewAsItems.Children.Add(new MenuItemViewModel("Officer", "fa-user", "ViewAsOfficer", "Tester"));
                viewAsItems.Children.Add(new MenuItemViewModel("Resident", "fa-user", "ViewAsResident", "Tester"));


                menuItems.Add(viewAsItems);
            }

            var settings = new MenuItemViewModel("Settings", "fa-cog", 30);
            //var settings = new MenuItemViewModel("My Settings", "fa-gear") { Index = Int32.MaxValue };
            foreach (var item in Kernel.GetAll<IConfigProvider>())
            {
                var config = item.ConfigObject as UserEntity;
                if (config != null)
                {
                    settings.Children.Add(new MenuItemViewModel(item.Title, "fa-gear", "Index", item.ConfigType.Name));
                }
            }

            if (UserContext.IsInRole("PropertyAdmin"))
            {


                settings.Children.Add(new MenuItemViewModel("Users", "fa-user", "Index", "UserManagement"));
                settings.Children.Add(new MenuItemViewModel("Courtesy Locations", "fa-location-arrow", "Index",
                    "CourtesyOfficerLocations"));
                settings.Children.Add(new MenuItemViewModel("Buildings", "fa-building", "Index", "Buildings"));
                settings.Children.Add(new MenuItemViewModel("Units", "fa-bed", "Index", "Units"));



            }
            // menuItems.Add(settings);


            menuItems.Add(settings);

            if (UserContext.IsInRole("Admin"))
            {

                var checkins = new MenuItemViewModel("AA Admin", "fa-heartbeat") { Index = Int32.MaxValue };
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
            List<MenuItemViewModel> list = new List<MenuItemViewModel>();
            if (UserContext.IsInRole("Admin"))
            {
                list.Add(new MenuItemViewModel("Marketing", "fa-chart", "ShowDashboard",
                    "Dashboard", new { name = "Admin" }));
            }
            if (UserContext.IsInRole("PropertyAdmin"))
            {
                list.Add(new MenuItemViewModel("Property", "fa-chart", "ShowDashboard",
                    "Dashboard", new { name = "PropertyAdmin" }));
            }
            ModuleHelper.SignalToEnabled<IPopulateDashboardItems>(x => x.PopulateDashboardItems(list));
            if (list.Any())
            {
                var dashboards = new MenuItemViewModel("Dashboard", "fa-chart") { Index = Int32.MinValue };
                foreach (var item in list)
                {
                    dashboards.Children.Add(item);
                }
                menuItems.Add(dashboards);
            }
        }

        public void FillActions(List<ActionLinkModel> actions, object viewModel)
        {
            //   <a class="btn btn-white btn-xs modal-link" href="@Url.Action("Entry", "UserManagement", new {id = item.Id})"><i class="fa fa-edit"></i> Edit</a>
            //< a class="btn btn-white btn-xs" href="@Url.Action("Delete", "UserManagement", new {id = item.Id})"><i class="fa fa-remove"></i> Delete</a>
            if (!UserContext.IsInRole("PropertyAdmin")) return;

            var vm = viewModel as UserBindingModel;
            if (vm != null)
            {
                if (!vm.Archived)
                {
                    actions.Add(new ActionLinkModel("Archive", "Delete", "UserManagement", new { id = vm.Id })
                    {
                        Icon = "fa-remove"
                    });
                    actions.Add(new ActionLinkModel("Hard Reset Password", "HardResetPassword", "UserManagement", new { userId = vm.Id })
                    {
                        Icon = "fa-remove"
                    });
                }

                actions.Add(new ActionLinkModel("Edit", "Entry", "UserManagement", new { id = vm.Id })
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
                actions.Add(new ActionLinkModel("Delete", "Delete", "Units", new { id = unitViewModel.Id })
                {
                    Icon = "fa-remove",
                });
                actions.Add(new ActionLinkModel("Edit", "Entry", "Units", new { id = unitViewModel.Id })
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });
            }
            var buildingViewModel = viewModel as BuildingViewModel;
            if (buildingViewModel != null)
            {
                actions.Add(new ActionLinkModel("Delete", "Delete", "Buildings", new { id = buildingViewModel.Id })
                {
                    Icon = "fa-remove",
                });
                actions.Add(new ActionLinkModel("Edit", "Entry", "Buildings", new { id = buildingViewModel.Id })
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });
            }
            var propertyViewModel = viewModel as PropertyFormBindingModel;
            if (propertyViewModel != null)
            {

                //actions.Add(new ActionLinkModel("Delete", "Delete", "Property", new { id = vm.Id }));
                actions.Add(new ActionLinkModel("Edit", "Entry", "Property", new { id = propertyViewModel.Id })
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });

                actions.Add(new ActionLinkModel("Switch To Property", "ChangeProperty", "Account",
                    new { id = propertyViewModel.Id })
                {
                    Icon = "fa-sign-in",
                });
             
                actions.Add(new ActionLinkModel("Import Residents/Units", "ImportResidentCSV", "Property", new { propertyId = propertyViewModel.Id }));
                actions.Add(new ActionLinkModel("Create Labels CSV", "CreateLabelCSV", "Property", new { propertyId = propertyViewModel.Id }));
                //if (UserContext.IsInRole("Admin"))
                //{
                //    actions.Add(new ActionLinkModel("Clear Property", "ClearProperty", "Account",
                //    new { id = propertyViewModel.Id })
                //    {
                //        Icon = "fa-sign-in",
                //    });
                //}
                
            }
        }

        public void Execute(ILogger logger)
        {
            var unitRepo = this.Kernel.Get<IRepository<Unit>>();
            var userRepo = this.Kernel.Get<IRepository<ApplicationUser>>();
            foreach (var p in unitRepo.GetAll().ToArray())
            {
                var name = $"[{ p.Building.Name }] {p.Name}";
                var user = userRepo.GetAll().FirstOrDefault(x => !x.Archived && x.UnitId == p.Id);
                if (user != null)
                    name += $" ({user.FirstName} {user.LastName})";

                p.CalculatedTitle = name;
                userRepo.Save();
            }
        }
    }
}