using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;

namespace ApartmentApps.Modules.Maintenance
{
    public static class ModelExtensions
    {

        public static MaintenanceCheckinBindingModel ToMaintenanceCheckinBindingModel(this MaintenanceRequestCheckin x, IBlobStorageService blob)
        {
            return new MaintenanceCheckinBindingModel
            {
                StatusId = x.StatusId,
                Date = x.Date,
                Comments = x.Comments,
                Worker = x.Worker.ToUserBindingModel(blob),
                Photos = blob.GetImages(x.GroupId).Select(s => new ImageReference() { ThumbnailUrl = s, Url = s }).ToList()
            };
        }
    }
}
