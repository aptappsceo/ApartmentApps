using System.Collections.Generic;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface ICourtesyService : IService
    {
        int SubmitIncidentReport(ApplicationUser user, string comments, IncidentType incidentReportTypeId, List<byte[]> images);
        bool OpenIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos);
        bool PauseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos);
        bool CloseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos);
    }
}