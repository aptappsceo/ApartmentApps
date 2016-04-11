using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Web.Common;

namespace ApartmentApps.IoC
{
    public static class Register
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<PropertyContext>().ToSelf().InRequestScope();

            kernel.Bind<IRepository<MaitenanceRequestType>>()
                .To<BaseRepository<MaitenanceRequestType>>()
                .InRequestScope();
            kernel.Bind<IRepository<MaintenanceRequestStatus>>()
                .To<BaseRepository<MaintenanceRequestStatus>>()
                .InRequestScope();
            kernel.Bind<IRepository<IncidentReportStatus>>().To<BaseRepository<IncidentReportStatus>>().InRequestScope();
            kernel.Bind<IRepository<Corporation>>().To<BaseRepository<Corporation>>().InRequestScope();
            kernel.Bind<IRepository<Property>>().To<BaseRepository<Property>>().InRequestScope();
            kernel.Bind<IRepository<ImageReference>>().To<BaseRepository<ImageReference>>().InRequestScope();
            kernel.Bind<IRepository<IdentityRole>>().To<BaseRepository<IdentityRole>>().InRequestScope();

            kernel.Bind<IRepository<Building>>().To<PropertyRepository<Building>>().InRequestScope();
            kernel.Bind<IRepository<Unit>>().To<UnitRepository>().InRequestScope();
            kernel.Bind<IRepository<Tenant>>().To<PropertyRepository<Tenant>>().InRequestScope();
            kernel.Bind<IRepository<MaitenanceRequest>>().To<MaintenanceRepository>().InRequestScope();
            kernel.Bind<IRepository<MaintenanceRequestCheckin>>()
                .To<PropertyRepository<MaintenanceRequestCheckin>>()
                .InRequestScope();
            kernel.Bind<IRepository<PropertyEntrataInfo>>()
                .To<PropertyRepository<PropertyEntrataInfo>>()
                .InRequestScope();
            kernel.Bind<IRepository<PropertyYardiInfo>>().To<PropertyRepository<PropertyYardiInfo>>().InRequestScope();
            kernel.Bind<IRepository<CourtesyOfficerLocation>>()
                .To<PropertyRepository<CourtesyOfficerLocation>>()
                .InRequestScope();
            kernel.Bind<IRepository<CourtesyOfficerCheckin>>()
                .To<PropertyRepository<CourtesyOfficerCheckin>>()
                .InRequestScope();
            kernel.Bind<IRepository<IncidentReport>>().To<IncidentReportRepository>().InRequestScope();
            kernel.Bind<IRepository<IncidentReportCheckin>>()
                .To<PropertyRepository<IncidentReportCheckin>>()
                .InRequestScope();
            kernel.Bind<IRepository<UserAlert>>().To<PropertyRepository<UserAlert>>().InRequestScope();
            kernel.Bind<IRepository<ApplicationUser>>().To<UserRepository>().InRequestScope();

            kernel.Bind<IPushNotifiationHandler>().To<AzurePushNotificationHandler>().InRequestScope();
            kernel.Bind<IBlobStorageService>().To<BlobStorageService>().InRequestScope();
            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IService>().To<AlertsService>().InRequestScope();
            kernel.Bind<IMaintenanceService>().To<MaintenanceService>().InRequestScope();
            kernel.Bind<ICourtesyService>().To<CourtesyService>().InRequestScope();
            kernel.Bind<DbContext>().ToMethod(_ => _.Kernel.Get<ApplicationDbContext>()).InRequestScope();


        }
    }
}