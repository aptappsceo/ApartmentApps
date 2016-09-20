using System.Collections.Generic;
using ApartmentApps.Data;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api
{
    public interface IIncidentsService : IService
    {
        int SubmitIncidentReport(ApplicationUser user, string comments, IncidentType incidentReportTypeId, List<byte[]> images, int unitId = 0);
        bool OpenIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos);
        bool PauseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos);
        bool CloseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos);
    }
}