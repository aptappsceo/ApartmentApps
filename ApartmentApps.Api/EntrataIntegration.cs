using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.Auth;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Entrata.Client;
using Entrata.Model.Requests;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.OData.Query.SemanticAst;
//using Yardi.Client.ResidentData;
//using Yardi.Client.ResidentTransactions;

namespace ApartmentApps.Api
{
    public static class Extensions
    {
        public static string NumbersOnly(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
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

    [Persistant]
    public class YardiConfig : ModuleConfig
    {

    }
    public class YardiModule : PropertyIntegrationModule<YardiConfig>
    {
        public YardiModule(PropertyContext context, DefaultUserManager manager, IRepository<YardiConfig> configRepo, IUserContext userContext) : base(context, manager, configRepo, userContext)
        {
        }

        public override void Execute(ILogger logger)
        {
            var config = Config;
            //var req = new GetUnitInformation_LoginRequest(new GetUnitInformation_LoginRequestBody());

            //var xml = (new GetChargeTypes_LoginResponseBody()).GetChargeTypes_LoginResult.Value;
            //var client = new ItfResidentDataSoapClient();


            //var client = new ItfResidentTransactions2_0SoapClient();
            //client.GetUnitInformation_Login("apartmentappbp", "67621", "YCSQL5TEST_2K8R2", "afqoml_70dev", "SQL Server",
            //    "", "Apartment App Payments", "");


        }


    }

    [Persistant]
    public class EntrataConfig : ModuleConfig
    {
        
    }

    public class EntrataModule : PropertyIntegrationModule<EntrataConfig>
    {
        public EntrataModule(PropertyContext context, DefaultUserManager manager,  IRepository<EntrataConfig> configRepo, IUserContext userContext) : base(context, manager, configRepo, userContext)
        {
        }

        public override void Execute(ILogger logger)
        {
            foreach (var item in _context.PropertyEntrataInfos)
            {
                var entrataClient = new EntrataClient()
                {
                    Username = item.Username,
                    Password = item.Password,
                    EndPoint = item.Endpoint
                };
                var result = entrataClient.GetMitsUnits(item.EntrataPropertyId).Result;
                foreach (var property in result.response.result.PhysicalProperty.Property)
                {
                    foreach (var ilsUnit in property.ILS_Unit.Select(p=>p.Units.Unit))
                    {
                        ImportUnit(logger, ilsUnit.BuildingName,ilsUnit.MarketingName);
                    }
                }

                var customers =
                    entrataClient.GetCustomers(item.EntrataPropertyId).Result.Response.Result.Customers.Customer;
                foreach (var customer in customers)
                {

                    Building building;
                    Unit unit;
                    ImportUnit(logger,customer.BuildingName,customer.UnitNumber,out unit, out building);

                    ImportCustomer(this, UserContext.CurrentUser.Property,unit.Id, customer.PhoneNumber.NumbersOnly(),customer.City, customer.Email, customer.FirstName, customer.LastName,customer.MiddleName,customer.Gender,customer.PostalCode,customer.State,customer.Address);

                }
            }

        }

        
    }

    public class PropertyIntegrationModule<TConfig> : Module<TConfig>, IWebJob, ICreateUser where TConfig : ModuleConfig, new()
    {
        protected readonly PropertyContext _context;
        private readonly DefaultUserManager _manager;
     
        public PropertyIntegrationModule(PropertyContext context, DefaultUserManager manager, IRepository<TConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
            _context = context;
            _manager = manager;
         
        }

        protected void ImportUnit(ILogger logger, string buildingName, string unitName)
        {
            Building building;
            ImportUnit(logger, buildingName, unitName, out building);
        }

        protected void ImportUnit(ILogger logger, string buildingName, string unitName, out Building building)
        {
            Unit unit;
            ImportUnit(logger, buildingName, unitName, out unit, out building);
        }

        protected void ImportUnit(ILogger logger, string buildingName, string unitName, out Unit unit, out Building building)
        {
            building = _context.Buildings.FirstOrDefault(p => p.Name == buildingName);

            if (building == null)
            {
                building = new Building()
                {
                    Name = buildingName,
                };
                _context.Buildings.Add(building);
                _context.SaveChanges();
            }
            var buildingId = building.Id;
            unit =
                _context.Units.FirstOrDefault(p => p.BuildingId == buildingId && p.Name == unitName);
            if (unit == null)
            {
                unit = new Unit()
                {
                    Name = unitName,
                    BuildingId = building.Id,
                };
                _context.Units.Add(unit);
                _context.SaveChanges();
            }
            logger.Info("Synced unit {0}", unitName);
        }
        public async Task<ApplicationUser> CreateUser(string email, string password, string firstName, string lastName)
        {
            return await _manager.CreateUser(email, password, firstName, lastName);
        }

        protected void ImportCustomer(Property property,  
            int unitId, string phoneNumber, string city, string email, string firstName, string lastName,string middleName, string gender,string postalCode, string state, string address)
        {
            ImportCustomer(this, property, unitId, phoneNumber, city, email, firstName, lastName, middleName, gender, postalCode, state, address);
        }

        protected void ImportCustomer(ICreateUser createUser, Property property,  
            int unitId, string phoneNumber, string city, string email, string firstName, string lastName,string middleName, string gender,string postalCode, string state, string address)
        {
           
            var user = _context.Users.FirstOrDefault(p => p.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                user = createUser.CreateUser(email, "Temp1234!", firstName, lastName).Result;
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
            user.PhoneNumber = phoneNumber.NumbersOnly();
            user.PropertyId = property.Id;
            user.City = city;
            user.Email =email;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Gender = gender;
            user.MiddleName = middleName;
            user.PostalCode = postalCode;
            user.State = state;
            user.UnitId = unitId;
            user.Address = address;
            _context.SaveChanges();
        }
        public virtual void Execute(ILogger logger)
        {
            
        }
    }

    ///// <summary>
    ///// Handles the synchronization of entrata and apartment apps.
    ///// </summary>
    //public class EntrataIntegration : 
    //    PropertyIntegrationAddon, 
    //    IMaintenanceSubmissionEvent, 
    //    IMaintenanceRequestCheckinEvent,
    //    IDataImporter
    //{

    //    public ApplicationDbContext Context { get; set; }
    //    public PropertyContext PropertyContext { get; set; }

    //    public EntrataIntegration(Property property, ApplicationDbContext context,PropertyContext propertyContext, IUserContext userContext) : base(property, userContext)
    //    {
    //        Context = context;
    //        PropertyContext = propertyContext;
    //    }

    //    public override bool Filter()
    //    {
    //        return PropertyContext.PropertyEntrataInfos.Any();
    //    }

     

    //    public void MaintenanceRequestSubmited( MaitenanceRequest maitenanceRequest)
    //    {
    //        // Sync with entrata on work order
    //    }

    //    public void MaintenanceRequestCheckin(MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request)
    //    {
            
    //    }

    //}
}