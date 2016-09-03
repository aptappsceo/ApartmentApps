namespace ApartmentApps.Api.Modules
{
    public static class LeaseExtensions
    {
        
        
        public static UserLeaseInfoBindingModel ToUserLeaseInfoBindingModel(this UserLeaseInfo lease, PaymentsConfig config, IBlobStorageService blobStorage)
        {
            return null;
        }

        public static bool IsIntervalSet(this UserLeaseInfo lease)
        {
            return lease.IntervalDays.HasValue || lease.IntervalMonths.HasValue || lease.IntervalYears.HasValue;
        }

        public static bool IsIntervalSet(this CreateUserLeaseInfoBindingModel lease)
        {
            return lease.IntervalDays.HasValue || lease.IntervalMonths.HasValue || lease.IntervalYears.HasValue;
        }

    }
}