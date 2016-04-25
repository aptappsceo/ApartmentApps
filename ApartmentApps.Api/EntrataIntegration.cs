using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
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
        public PropertyContext PropertyContext { get; set; }

        public EntrataIntegration(Property property, ApplicationDbContext context,PropertyContext propertyContext, IUserContext userContext) : base(property, userContext)
        {
            Context = context;
            PropertyContext = propertyContext;
        }

        public override bool Filter()
        {
            return PropertyContext.PropertyEntrataInfos.Any();
        }

        public async Task<bool> ImportData(ICreateUser createUser, Property property)
        {
            var client = new EntrataClient();
            var info = PropertyContext.PropertyEntrataInfos.FirstOrDefault();
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
                    user = await createUser.CreateUser(item.Email, "Temp1234!", item.FirstName, item.LastName);
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

                user.PropertyId = property.Id;
                user.City = item.City;
                user.Email = item.Email;
                user.FirstName = item.FirstName;
                user.LastName = item.LastName;
                user.Gender = item.Gender;
                user.MiddleName = item.MiddleName;
                user.PostalCode = item.PostalCode;
                user.State = item.State;
                user.UnitId = unit.Id;
                user.Address = item.Address;

               
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