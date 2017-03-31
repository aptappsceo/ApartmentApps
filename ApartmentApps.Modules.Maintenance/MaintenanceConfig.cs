using System.ComponentModel;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class MaintenanceConfig : PropertyModuleConfig
    {
        public bool SupervisorMode { get; set; }

        [DisplayName("Resident Emergency Instructions")]
        public string ResidentEmergencyInstructions { get; set; }

        [DisplayName("Resident Custom Instructions #1")]
        [Description("Instructions in case resident gave no permission to enter for maintenance staff.")]
        public string ResidentNoPermissionToEnterInstructions { get; set; }

        [DisplayName("Maintenance Service Phone Number")]
        public string MaintenancePhoneNumber { get; set; }
        [DisplayName("Should we verify bard codes on the doors for this property?")]
        public bool VerifyBarCodes { get; set; }
    }
}