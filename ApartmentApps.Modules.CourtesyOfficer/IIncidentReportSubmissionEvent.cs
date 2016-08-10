using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IIncidentReportSubmissionEvent
    {
        void IncidentReportSubmited( IncidentReport incidentReport);
    }
}