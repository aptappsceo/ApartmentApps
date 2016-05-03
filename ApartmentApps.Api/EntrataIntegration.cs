using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Entrata.Client;
using Entrata.Model.Requests;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.OData.Query.SemanticAst;

namespace ApartmentApps.Api
{
    public static class Extensions
    {
        public static string NumbersOnly(this string str)
        {
            var strBuilder = new StringBuilder();
            foreach (var c in str)
            {
                if (char.IsDigit(c))
                {
                    strBuilder.Append(c);
                }
            }
            return strBuilder.ToString();
        }
    }
    public interface IDataImporter
    {
        Task<bool> ImportData(ICreateUser createUser, Property property);
    }

    public interface IUnitImporter
    {
        Task ImportResident(ICreateUser createUser, Property property, IExternalUnitImportInfo item);
    }
    public interface IExternalUnitImportInfo
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string UnitNumber { get; set; }
        string BuildingName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string PostalCode { get; set; }
        string Email { get; set; }
        string MiddleName { get; set; }
        bool IsVacant { get; set; }
        string PhoneNumber { get; set; }
    }

    public class ExternalUnitImportInfo : IExternalUnitImportInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UnitNumber { get; set; }
        public string BuildingName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string MiddleName { get; set; }
        public bool IsVacant { get; set; }
        public string PhoneNumber { get; set; }

    }

    public class UnitImporter : IUnitImporter
    {
        public ApplicationDbContext Context { get; set; }

       

        public UnitImporter(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task ImportResident(ICreateUser createUser, Property property, IExternalUnitImportInfo item)
        {
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
            if (!item.IsVacant)
            {
                var user = await Context.Users.FirstOrDefaultAsync(p => p.Email.ToLower() == item.Email.ToLower());

                if (user == null)
                {
                    user = await createUser.CreateUser(item.Email, "Temp1234!", item.FirstName, item.LastName);
                }
                if (user == null)
                {
                    return;
                }
                user.PropertyId = property.Id;
                if (user.Roles.All(p => p.RoleId != "Resident"))
                {
                    user.Roles.Add(new IdentityUserRole()
                    {
                        RoleId = "Resident",
                        UserId = user.Id
                    });
                }
                user.PhoneNumber = item.PhoneNumber.NumbersOnly();
                user.PropertyId = property.Id;
                user.City = item.City;
                user.Email = item.Email;
                user.FirstName = item.FirstName;
                user.LastName = item.LastName;
                user.MiddleName = item.MiddleName;
                user.PostalCode = item.PostalCode;
                user.State = item.State;
                user.UnitId = unit.Id;
                user.Address = item.Address;
            }
           


            await Context.SaveChangesAsync();
        }
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
            foreach (var info in PropertyContext.PropertyEntrataInfos.ToArray())
            {
                client.EndPoint = info.Endpoint;
                client.Username = info.Username;
                client.Password = info.Password;
                var result = await client.GetCustomers(info.EntrataPropertyId);
                foreach (var item in result.Response.Result.Customers.Customer)
                {

                    // Create the building
                    await ImportCustomer(createUser, property, item);
                }
            }
          
            return true;
        }

        private async Task ImportCustomer(ICreateUser createUser, Property property, Customer item)
        {
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
                return;
            }
            user.PropertyId = property.Id;
            if (!user.Roles.Any(p => p.RoleId == "Resident"))
            {
                user.Roles.Add(new IdentityUserRole()
                {
                    RoleId = "Resident",
                    UserId = user.Id
                });
            }
            user.PhoneNumber = item.PhoneNumber.NumbersOnly();
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

        public void MaintenanceRequestSubmited( MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }

        public void MaintenanceRequestCheckin(MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request)
        {
            
        }

    }
}