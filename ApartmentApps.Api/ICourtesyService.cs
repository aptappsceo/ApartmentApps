using System.Collections.Generic;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface ICourtesyService : IService
    {
        int SubmitIncidentReport(ApplicationUser user, string comments, int incidentReportTypeId, List<byte[]> photos);
        int OpenIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos);
        int PauseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos);
        int CloseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos);
    }
}