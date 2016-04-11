using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ApartmentApps.Data;
using Entrata.Client;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.Api
{
    public interface IDataImporter
    {
        Task<bool> ImportData(ICreateUser createUser, Property property);
    }
    /// <summary>
    /// Handles the synchronization of entrata and apartment apps.
    /// </summary>
    public class EntrataIntegration : 
        PropertyIntegrationAddon, 
        IMaintenanceSubmissionEvent, 
        IMaintenanceRequestCheckinEvent,
        IDataImporter
    {

        public ApplicationDbContext Context { get; set; }

        public EntrataIntegration(ApplicationDbContext context, IUserContext userContext) : base(userContext)
        {
            Context = context;
        }

        public override bool Filter()
        {
            return UserContext.CurrentUser.Property.EntrataInfo != null;
        }

        public async Task<bool> ImportData(ICreateUser createUser, Property property)
        {
            var client = new EntrataClient();
            var info = property.EntrataInfo;
            client.EndPoint = info.Endpoint;
            client.Username = info.Username;
            client.Password = info.Password;
            var result = await client.GetCustomers(info.EntrataPropertyId);
            foreach (var item in result.Response.Result.Customers.Customer)
            {

                // Create the building
                var building =
                    await Context.Buildings.FirstOrDefaultAsync(p => p.PropertyId == property.Id && p.Name == item.BuildingName);

                if (building == null)
                {
                    building = new Building()
                    {
                        Name = item.BuildingName,
                        PropertyId = property.Id
                    };
                    Context.Buildings.Add(building);
                    await Context.SaveChangesAsync();
                }

                var unit =
                    await Context.Units.FirstOrDefaultAsync(p => p.BuildingId == building.Id && p.Name == item.UnitNumber);
                if (unit == null)
                {
                    unit = new Unit()
                    {
                        Name = item.UnitNumber,
                        BuildingId = building.Id,
                        PropertyId = property.Id
                    };
                    Context.Units.Add(unit);
                    await Context.SaveChangesAsync();
                }

                var user = await Context.Users.FirstOrDefaultAsync(p => p.Email.ToLower() == item.Email.ToLower());

                if (user == null)
                {
                    user = await createUser.CreateUser(item.Email, item.FirstName[0].ToString().ToLower() + item.LastName.ToLower(), item.FirstName, item.LastName);
                }
                if (user == null)
                {
                    continue;
                }
                user.PropertyId = property.Id;
                if (user.Roles.Any(p => p.RoleId == "Resident"))
                {
                    user.Roles.Add(new IdentityUserRole()
                    {
                        RoleId = "Resident",
                        UserId = user.Id
                    });

                }
               
               
                var tenantInfo = await Context.Tenants.FirstOrDefaultAsync(p => p.UserId == user.Id);
                if (tenantInfo == null)
                {
                    tenantInfo = new Tenant();
                    Context.Tenants.Add(tenantInfo);
                }

                tenantInfo.PropertyId = property.Id;
                tenantInfo.BuildingName = item.BuildingName;
                tenantInfo.City = item.City;
                tenantInfo.Email = item.Email;
                tenantInfo.UnitNumber = item.UnitNumber;
                tenantInfo.FirstName = item.FirstName;
                tenantInfo.LastName = item.LastName;
                tenantInfo.Gender = item.Gender;
                tenantInfo.MiddleName = item.MiddleName;
                tenantInfo.PostalCode = item.PostalCode;
                tenantInfo.State = item.State;
                tenantInfo.UserId = user.Id;
                tenantInfo.UnitId = unit.Id;
                tenantInfo.Address = item.Address;

               
                await Context.SaveChangesAsync();
                
            }
            return true;
        }

        public void MaintenanceRequestSubmited( MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }

        public void MaintenanceRequestCheckin(MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request)
        {
            
        }

    }
}