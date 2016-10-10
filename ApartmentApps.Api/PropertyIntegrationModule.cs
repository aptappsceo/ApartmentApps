using System;
using System.Linq;
using System.Threading.Tasks;
using ApartmentApps.Api.Auth;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;

namespace ApartmentApps.Api
{
    public class PropertyIntegrationModule<TConfig> : Module<TConfig>, IWebJob, ICreateUser where TConfig : ModuleConfig, new()
    {
        public ApplicationDbContext DbContext { get; set; }
        protected readonly PropertyContext _context;
        private readonly DefaultUserManager _manager;

        public PropertyIntegrationModule(ApplicationDbContext dbContext, PropertyContext context, DefaultUserManager manager, IRepository<TConfig> configRepo, IUserContext userContext, IKernel kernel) : base(kernel, configRepo, userContext)
        {
            DbContext = dbContext;
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
            int unitId, string phoneNumber, string city, string email, string firstName, string lastName, string middleName, string gender, string postalCode, string state, string address)
        {
            ImportCustomer(this, unitId, phoneNumber, city, email, firstName, lastName, middleName, gender, postalCode, state, address);
        }

        protected ApplicationUser ImportCustomer(ICreateUser createUser,
            int unitId, string phoneNumber, string city, string email, string firstName, string lastName, string middleName, string gender, string postalCode, string state, string address)
        {
            if (string.IsNullOrEmpty(email)) return null;

            var user = DbContext.Users.FirstOrDefault(p => p.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                user = createUser.CreateUser(email, "Temp1234!", firstName, lastName).Result;
            }
            if (user == null)
            {
                return user;
            }
            user.PropertyId = UserContext.PropertyId;
            if (!user.Roles.Any(p => p.RoleId == "Resident"))
            {
                user.Roles.Add(new IdentityUserRole()
                {
                    RoleId = "Resident",
                    UserId = user.Id
                });
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                user.PhoneNumber = phoneNumber.NumbersOnly();
            }

            user.PropertyId = UserContext.PropertyId;
            user.City = city;
            user.Email = email;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Gender = gender;
            user.MiddleName = middleName;
            user.PostalCode = postalCode;
            user.State = state;
            user.UnitId = unitId;
            user.Address = address;
            _context.SaveChanges();
            return user;
        }

        public TimeSpan Frequency => new TimeSpan(1, 0, 0, 0);
        public int JobStartHour => 1;
        public int JobStartMinute => 0;

        public virtual void Execute(ILogger logger)
        {

        }
    }
}