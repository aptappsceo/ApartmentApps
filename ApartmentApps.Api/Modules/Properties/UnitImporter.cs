using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ApartmentApps.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.Api
{
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
}