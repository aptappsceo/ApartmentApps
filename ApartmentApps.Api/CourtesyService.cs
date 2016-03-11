using System;
using System.Collections.Generic;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class CourtesyService : ICourtesyService
    {
        public int SubmitIncidentReport(ApplicationUser user, string comments, int incidentReportTypeId, List<byte[]> photos)
        {
            throw new NotImplementedException();
        }

        public int OpenIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos)
        {
            throw new NotImplementedException();
        }

        public int PauseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos)
        {
            throw new NotImplementedException();
        }

        public int CloseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos)
        {
            throw new NotImplementedException();
        }
    }
}