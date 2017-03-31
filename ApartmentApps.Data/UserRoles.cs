using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Data
{
    public static class UserRoles
    {
        public const string Admin = nameof(Admin);
        public const string Maintenance = nameof(Maintenance);
        public const string MaintenanceSupervisor = nameof(MaintenanceSupervisor);
        public const string Officer = nameof(Officer);
        public const string PropertyAdmin = nameof(PropertyAdmin);
        public const string Resident = nameof(Resident);
        public const string Tester = nameof(Tester);
    }


}
