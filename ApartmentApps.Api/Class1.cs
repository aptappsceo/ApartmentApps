using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.API.Service.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;

namespace ApartmentApps.Api
{
    public static class Addons
    {
        public static List<IApartmentAppsAddon> All { get; set; }
        public static void Init(IEnumerable<IApartmentAppsAddon> all)
        {
            All = all.ToList();
        }

        public static void InvokeEvent<TEventInterface>(this IEnumerable<TEventInterface> services, Action<TEventInterface> evt, ApplicationDbContext ctx, ApplicationUser user )
        {
            foreach (var item in services)
            {
                var item1 = item;
                var filter = item as IAddonFilter;
                if (filter != null)
                {
                    if (!filter.Filter(user))
                    {
                        continue;
                    }
                }
                evt(item1);
            }
        }
    }
    public interface IMaintenanceService
    {
        void SubmitRequest();
    }

    public interface IApartmentAppsAddon
    {
   
    }

    public interface IMaintenanceSubmissionEvent
    {
        void MaintenanceRequestSubmited(MaitenanceRequest maitenanceRequest);
    }

    public interface IAddonFilter
    {
        bool Filter(ApplicationUser user);
    }

    public class PropertyIntegrationAddon : IApartmentAppsAddon, IAddonFilter
    {
        public string PropertyAddonName { get; set; }

        public bool Filter(ApplicationUser user)
        {
            return user.Tenant.Property.PropertyAddons.Any(p=>p.AddonType.Name == PropertyAddonName);
        }
    }


}
