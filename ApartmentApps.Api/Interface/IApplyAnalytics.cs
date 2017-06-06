using System;

namespace ApartmentApps.Api.Modules
{
    public interface IApplyAnalytics
    {
        void ApplyAnalytics(AnalyticsModule module, AnalyticsItem analyticsItem, DateTime startDate);
    }
}