using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            
            context.Roles.AddOrUpdate(
                  new IdentityRole { Id = "Maintenance", Name = "Maintenance" },
                  new IdentityRole { Id = "Resident", Name = "Resident" },
                  new IdentityRole { Id = "Officer", Name = "Officer" },
                  new IdentityRole { Id = "PropertyAdmin", Name = "PropertyAdmin" },
                  new IdentityRole { Id = "Admin", Name = "Admin" }
            );
            var user = context.Users.FirstOrDefault(p => p.Email == "micahosborne@gmail.com");
            if (user != null)
            {
               user.Roles.Add(new IdentityUserRole() {RoleId = "Admin",UserId = user.Id});
               user.Roles.Add(new IdentityUserRole() {RoleId = "PropertyAdmin",UserId = user.Id});
               user.Roles.Add(new IdentityUserRole() {RoleId = "Officer",UserId = user.Id});
               user.Roles.Add(new IdentityUserRole() {RoleId = "Resident",UserId = user.Id});
               user.Roles.Add(new IdentityUserRole() {RoleId = "Maintenance",UserId = user.Id});
            }
            context.MaintenanceRequestStatuses.AddOrUpdate(
                new MaintenanceRequestStatus { Name = "Submitted" },
                new MaintenanceRequestStatus { Name = "Scheduled" },
                new MaintenanceRequestStatus { Name = "Started" },
                new MaintenanceRequestStatus { Name = "Paused" },
                new MaintenanceRequestStatus { Name = "Complete" }
            );
            context.MaitenanceRequestTypes.AddOrUpdate(
                new MaitenanceRequestType() { Name = "Alarm" },
                new MaitenanceRequestType() { Name = "APEX Meter" },
                new MaitenanceRequestType() { Name = "Appliances" },
                new MaitenanceRequestType() { Name = "Bathroom" },
                new MaitenanceRequestType() { Name = "Bedroom Door" },
                new MaitenanceRequestType() { Name = "Bird Droppings" },
                new MaitenanceRequestType() { Name = "Blinds" },
                new MaitenanceRequestType() { Name = "Buildings" },
                new MaitenanceRequestType() { Name = "Cabinets" },
                new MaitenanceRequestType() { Name = "Carpets" },
                new MaitenanceRequestType() { Name = "Ceiling" },
                new MaitenanceRequestType() { Name = "Ceiling Fan" },
                new MaitenanceRequestType() { Name = "Ceramic Tile" },
                new MaitenanceRequestType() { Name = "Clean" },
                new MaitenanceRequestType() { Name = "Clean for Turnkey" },
                new MaitenanceRequestType() { Name = "Clean Stairwell" },
                new MaitenanceRequestType() { Name = "Clogged Bathtub/Sink" },
                new MaitenanceRequestType() { Name = "Clogged Toilet" },
                new MaitenanceRequestType() { Name = "Closet Issue" },
                new MaitenanceRequestType() { Name = "Clubhouse" },
                new MaitenanceRequestType() { Name = "Common Areas" },
                new MaitenanceRequestType() { Name = "Doors" },
                new MaitenanceRequestType() { Name = "Drywall" },
                new MaitenanceRequestType() { Name = "Electrical" },
                new MaitenanceRequestType() { Name = "Eviction" },
                new MaitenanceRequestType() { Name = "Exterior Front Entry" },
                new MaitenanceRequestType() { Name = "Exterior Lights" },
                new MaitenanceRequestType() { Name = "Fire Panel" },
                new MaitenanceRequestType() { Name = "Fireplace" },
                new MaitenanceRequestType() { Name = "Fitness Center" },
                new MaitenanceRequestType() { Name = "Flooring" },
                new MaitenanceRequestType() { Name = "Foyer" },
                new MaitenanceRequestType() { Name = "Front Entry" },
                new MaitenanceRequestType() { Name = "Garage" },
                new MaitenanceRequestType() { Name = "Garbage Disposal" },
                new MaitenanceRequestType() { Name = "Gate" },
                new MaitenanceRequestType() { Name = "Grounds" },
                new MaitenanceRequestType() { Name = "Guest Bathroom" },
                new MaitenanceRequestType() { Name = "Gutters" },
                new MaitenanceRequestType() { Name = "Hardware" },
                new MaitenanceRequestType() { Name = "HVAC" },
                new MaitenanceRequestType() { Name = "Inspection Move-in" },
                new MaitenanceRequestType() { Name = "Inspection Move-out" },
                new MaitenanceRequestType() { Name = "Inspection Patio" },
                new MaitenanceRequestType() { Name = "Inspection Property" },
                new MaitenanceRequestType() { Name = "Key FOB/Card" },
                new MaitenanceRequestType() { Name = "Keys Needed" },
                new MaitenanceRequestType() { Name = "Kitchen" },
                new MaitenanceRequestType() { Name = "Kitchen Countertop" },
                new MaitenanceRequestType() { Name = "Kitchen Sink" },
                new MaitenanceRequestType() { Name = "Landscaping" },
                new MaitenanceRequestType() { Name = "Laundry Facility" },
                new MaitenanceRequestType() { Name = "Leaks" },
                new MaitenanceRequestType() { Name = "Leasing Office" },
                new MaitenanceRequestType() { Name = "Lights" },
                new MaitenanceRequestType() { Name = "Lock/Key" },
                new MaitenanceRequestType() { Name = "Mail Kiosk/Center" },
                new MaitenanceRequestType() { Name = "Make-Ready" },
                new MaitenanceRequestType() { Name = "MC Country" },
                new MaitenanceRequestType() { Name = "Mini Model" },
                new MaitenanceRequestType() { Name = "Move In Maint" },
                new MaitenanceRequestType() { Name = "Move Out Maint" },
                new MaitenanceRequestType() { Name = "Office" },
                new MaitenanceRequestType() { Name = "Order Maint Supplie" },
                new MaitenanceRequestType() { Name = "Parking Lot" },
                new MaitenanceRequestType() { Name = "Patio" },
                new MaitenanceRequestType() { Name = "Per Manager Request" },
                new MaitenanceRequestType() { Name = "Pest Control" },
                new MaitenanceRequestType() { Name = "Pet" },
                new MaitenanceRequestType() { Name = "Photos" },
                new MaitenanceRequestType() { Name = "Playground" },
                new MaitenanceRequestType() { Name = "Plumbing" },
                new MaitenanceRequestType() { Name = "Pool" },
                new MaitenanceRequestType() { Name = "Pressure Wash" },
                new MaitenanceRequestType() { Name = "Preventative" },
                new MaitenanceRequestType() { Name = "Punchout" },
                new MaitenanceRequestType() { Name = "Retention Pond" },
                new MaitenanceRequestType() { Name = "Roof" },
                new MaitenanceRequestType() { Name = "Roof Leak" },
                new MaitenanceRequestType() { Name = "Sliding Doors" },
                new MaitenanceRequestType() { Name = "Smoke Detector" },
                new MaitenanceRequestType() { Name = "Stairs" },
                new MaitenanceRequestType() { Name = "Tennis Court Net" },
                new MaitenanceRequestType() { Name = "Touch-Clean" },
                new MaitenanceRequestType() { Name = "Trash Can" },
                new MaitenanceRequestType() { Name = "Trash Compactor" },
                new MaitenanceRequestType() { Name = "Trash Out Vacant" },
                new MaitenanceRequestType() { Name = "Utility Room" },
                new MaitenanceRequestType() { Name = "Vent(s)" },
                new MaitenanceRequestType() { Name = "Walls and Ceiling" },
                new MaitenanceRequestType() { Name = "Warranty" },
                new MaitenanceRequestType() { Name = "Windows" },
                new MaitenanceRequestType() { Name = "Misc/Other" },
                new MaitenanceRequestType() { Name = "None" }
                );
        }
    }
}
