using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;

namespace ApartmentApps.Modules.CourtesyOfficer
{
    public static class ModelExtensions
    {
        public static IncidentCheckinBindingModel ToIncidentCheckinBindingModel(this IncidentReportCheckin x, IBlobStorageService blob)
        {

            return new IncidentCheckinBindingModel
            {
                StatusId = x.StatusId,
                Date = x.CreatedOn,
                Comments = x.Comments,
                Officer = x.Officer.ToUserBindingModel(blob),
                Photos = blob.GetImages(x.GroupId).Select(s => new ImageReference() { ThumbnailUrl = s, Url = s }).ToList(),

            };
        }
    }
}
