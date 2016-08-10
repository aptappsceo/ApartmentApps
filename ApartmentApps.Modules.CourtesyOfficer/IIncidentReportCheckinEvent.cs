using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IIncidentReportCheckinEvent
    {
        void IncidentReportCheckin( IncidentReportCheckin incidentReportCheckin, IncidentReport incidentReport);
    }
}