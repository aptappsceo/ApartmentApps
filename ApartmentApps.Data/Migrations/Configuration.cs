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
            //var user = context.Users.FirstOrDefault(p => p.Email == "micahosborne@gmail.com");
            //if (user != null)
            //{
            //   user.Roles.Add(new IdentityUserRole() {RoleId = "Admin",UserId = user.Id});
            //   user.Roles.Add(new IdentityUserRole() {RoleId = "PropertyAdmin",UserId = user.Id});
            //   user.Roles.Add(new IdentityUserRole() {RoleId = "Officer",UserId = user.Id});
            //   user.Roles.Add(new IdentityUserRole() {RoleId = "Resident",UserId = user.Id});
            //   user.Roles.Add(new IdentityUserRole() {RoleId = "Maintenance",UserId = user.Id});
            //}
            context.MaintenanceRequestStatuses.AddOrUpdate(
                new MaintenanceRequestStatus { Name = "Submitted" },
                new MaintenanceRequestStatus { Name = "Scheduled" },
                new MaintenanceRequestStatus { Name = "Started" },
                new MaintenanceRequestStatus { Name = "Paused" },
                new MaintenanceRequestStatus { Name = "Complete" }
            );
            context.IncidentReportStatuses.AddOrUpdate(
                new IncidentReportStatus { Name = "Reported" },
                new IncidentReportStatus { Name = "Open" },
                new IncidentReportStatus { Name = "Paused" },
                new IncidentReportStatus { Name = "Complete" }
            );
            //context.MaitenanceRequestTypes.AddOrUpdate(
            //    new MaitenanceRequestType() { Id=1, Name = "Alarm" },
            //    new MaitenanceRequestType() { Id = 2, Name = "APEX Meter" },
            //    new MaitenanceRequestType() { Id = 3, Name = "Appliances" },
            //    new MaitenanceRequestType() {Id=4,Name = "Bathroom" },
            //    new MaitenanceRequestType() {Id=5,Name = "Bedroom Door" },
            //    new MaitenanceRequestType() {Id=6,Name = "Bird Droppings" },
            //    new MaitenanceRequestType() {Id=7,Name = "Blinds" },
            //    new MaitenanceRequestType() {Id=8,Name = "Buildings" },
            //    new MaitenanceRequestType() {Id=9,Name = "Cabinets" },
            //    new MaitenanceRequestType() {Id=10,Name = "Carpets" },
            //    new MaitenanceRequestType() {Id=11,Name = "Ceiling" },
            //    new MaitenanceRequestType() {Id=12,Name = "Ceiling Fan" },
            //    new MaitenanceRequestType() {Id=13,Name = "Ceramic Tile" },
            //    new MaitenanceRequestType() {Id=14,Name = "Clean" },
            //    new MaitenanceRequestType() {Id=15,Name = "Clean for Turnkey" },
            //    new MaitenanceRequestType() {Id=16,Name = "Clean Stairwell" },
            //    new MaitenanceRequestType() {Id=17,Name = "Clogged Bathtub/Sink" },
            //    new MaitenanceRequestType() {Id=18,Name = "Clogged Toilet" },
            //    new MaitenanceRequestType() {Id=19,Name = "Closet Issue" },
            //    new MaitenanceRequestType() {Id=20,Name = "Clubhouse" },
            //    new MaitenanceRequestType() {Id=21,Name = "Common Areas" },
            //    new MaitenanceRequestType() {Id=22,Name = "Doors" },
            //    new MaitenanceRequestType() {Id=23,Name = "Drywall" },
            //    new MaitenanceRequestType() {Id=24,Name = "Electrical" },
            //    new MaitenanceRequestType() {Id=25,Name = "Eviction" },
            //    new MaitenanceRequestType() {Id=26,Name = "Exterior Front Entry" },
            //    new MaitenanceRequestType() {Id=27,Name = "Exterior Lights" },
            //    new MaitenanceRequestType() {Id=28,Name = "Fire Panel" },
            //    new MaitenanceRequestType() {Id=29,Name = "Fireplace" },
            //    new MaitenanceRequestType() {Id=30,Name = "Fitness Center" },
            //    new MaitenanceRequestType() {Id=31,Name = "Flooring" },
            //    new MaitenanceRequestType() {Id=32,Name = "Foyer" },
            //    new MaitenanceRequestType() {Id=33,Name = "Front Entry" },
            //    new MaitenanceRequestType() {Id=34,Name = "Garage" },
            //    new MaitenanceRequestType() {Id=35,Name = "Garbage Disposal" },
            //    new MaitenanceRequestType() {Id=36,Name = "Gate" },
            //    new MaitenanceRequestType() {Id=37,Name = "Grounds" },
            //    new MaitenanceRequestType() {Id=38,Name = "Guest Bathroom" },
            //    new MaitenanceRequestType() {Id=39,Name = "Gutters" },
            //    new MaitenanceRequestType() {Id=40,Name = "Hardware" },
            //    new MaitenanceRequestType() {Id=41,Name = "HVAC" },
            //    new MaitenanceRequestType() {Id=42,Name = "Inspection Move-in" },
            //    new MaitenanceRequestType() {Id=43,Name = "Inspection Move-out" },
            //    new MaitenanceRequestType() {Id=44,Name = "Inspection Patio" },
            //    new MaitenanceRequestType() {Id=45,Name = "Inspection Property" },
            //    new MaitenanceRequestType() {Id=46,Name = "Key FOB/Card" },
            //    new MaitenanceRequestType() {Id=47,Name = "Keys Needed" },
            //    new MaitenanceRequestType() {Id=48,Name = "Kitchen" },
            //    new MaitenanceRequestType() {Id=49,Name = "Kitchen Countertop" },
            //    new MaitenanceRequestType() {Id=50,Name = "Kitchen Sink" },
            //    new MaitenanceRequestType() {Id=51,Name = "Landscaping" },
            //    new MaitenanceRequestType() {Id=52,Name = "Laundry Facility" },
            //    new MaitenanceRequestType() {Id=53,Name = "Leaks" },
            //    new MaitenanceRequestType() {Id=54,Name = "Leasing Office" },
            //    new MaitenanceRequestType() {Id=55,Name = "Lights" },
            //    new MaitenanceRequestType() {Id=56,Name = "Lock/Key" },
            //    new MaitenanceRequestType() {Id=57,Name = "Mail Kiosk/Center" },
            //    new MaitenanceRequestType() {Id=58,Name = "Make-Ready" },
            //    new MaitenanceRequestType() {Id=59,Name = "MC Country" },
            //    new MaitenanceRequestType() {Id=60,Name = "Mini Model" },
            //    new MaitenanceRequestType() {Id=61,Name = "Move In Maint" },
            //    new MaitenanceRequestType() {Id=62,Name = "Move Out Maint" },
            //    new MaitenanceRequestType() {Id=63,Name = "Office" },
            //    new MaitenanceRequestType() {Id=64,Name = "Order Maint Supplie" },
            //    new MaitenanceRequestType() {Id=65,Name = "Parking Lot" },
            //    new MaitenanceRequestType() {Id=66,Name = "Patio" },
            //    new MaitenanceRequestType() {Id=67,Name = "Per Manager Request" },
            //    new MaitenanceRequestType() {Id=68,Name = "Pest Control" },
            //    new MaitenanceRequestType() {Id=69,Name = "Pet" },
            //    new MaitenanceRequestType() {Id=70,Name = "Photos" },
            //    new MaitenanceRequestType() {Id=71,Name = "Playground" },
            //    new MaitenanceRequestType() {Id=72,Name = "Plumbing" },
            //    new MaitenanceRequestType() {Id=73,Name = "Pool" },
            //    new MaitenanceRequestType() {Id=74,Name = "Pressure Wash" },
            //    new MaitenanceRequestType() {Id=75,Name = "Preventative" },
            //    new MaitenanceRequestType() {Id=76,Name = "Punchout" },
            //    new MaitenanceRequestType() {Id=77,Name = "Retention Pond" },
            //    new MaitenanceRequestType() {Id=78,Name = "Roof" },
            //    new MaitenanceRequestType() {Id=79,Name = "Roof Leak" },
            //    new MaitenanceRequestType() {Id=80,Name = "Sliding Doors" },
            //    new MaitenanceRequestType() {Id=81,Name = "Smoke Detector" },
            //    new MaitenanceRequestType() {Id=82,Name = "Stairs" },
            //    new MaitenanceRequestType() {Id=83,Name = "Tennis Court Net" },
            //    new MaitenanceRequestType() {Id=84,Name = "Touch-Clean" },
            //    new MaitenanceRequestType() {Id=85,Name = "Trash Can" },
            //    new MaitenanceRequestType() {Id=86,Name = "Trash Compactor" },
            //    new MaitenanceRequestType() {Id=87,Name = "Trash Out Vacant" },
            //    new MaitenanceRequestType() {Id=88,Name = "Utility Room" },
            //    new MaitenanceRequestType() {Id=89,Name = "Vent(s)" },
            //    new MaitenanceRequestType() {Id=90,Name = "Walls and Ceiling" },
            //    new MaitenanceRequestType() {Id=91,Name = "Warranty" },
            //    new MaitenanceRequestType() {Id=92,Name = "Windows" },
            //    new MaitenanceRequestType() {Id=93,Name = "Misc/Other" },
            //    new MaitenanceRequestType() {Id=94,Name = "None" }
            //    );
        }
    }
}
