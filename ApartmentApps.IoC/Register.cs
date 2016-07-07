using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Syntax;
#if !JOBS
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Ninject.Web.Common;
#endif
namespace ApartmentApps.IoC
{
    public static class Register
    {
#if JOBS
        public static void InRequestScope<T>(this IBindingWhenInNamedWithOrOnSyntax<T> b)
        {
            b.InSingletonScope();
        }
#endif
        public static void RegisterMappable<TModel, TViewModel,TService>(this IKernel kernel) where TModel : IBaseEntity, new() where TViewModel : BaseViewModel, new() where TService : StandardCrudService<TModel, TViewModel>
        {
            
           
            kernel.Bind< IService,
                IMapper < TModel, TViewModel >,
                StandardCrudService <TModel, TViewModel>, IServiceFor<TViewModel>>()
                .To<TService>().InRequestScope();

            //kernel.Bind<IMapper<TModel, TViewModel>>().To<TService>().InRequestScope();
                //.ToMethod(_ => _.<StandardCrudService<TModel, TViewModel>>())
                //.InRequestScope();
        }

        public static void RegisterModule<TModule, TModuleConfig>( this IKernel kernel ) where TModule : Module<TModuleConfig> where TModuleConfig : ModuleConfig, new()
        {
            kernel.Bind<TModule, IModule, Module<TModuleConfig>>().To<TModule>().InRequestScope();
            
            //kernel.Bind<IRepository<TModuleConfig>>().To<Module<TModuleConfig>.ConfigRepository>().InRequestScope();
        }
        public static void RegisterServices(IKernel kernel)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!assembly.FullName.StartsWith("ApartmentApps")) continue;
                var entityTypes = assembly
                  .GetTypes()
                  .Where(t =>
                    t.GetCustomAttributes(typeof(PersistantAttribute), inherit: true)
                    .Any());

                foreach (var entityType in entityTypes)
                {
                    if (typeof (ModuleConfig).IsAssignableFrom(entityType))
                    {
                        kernel.Bind(typeof(IRepository<>).MakeGenericType(entityType))
                           .To(typeof(PropertyRepository<>).MakeGenericType(entityType));
                    }
                    else if (typeof (PropertyEntity).IsAssignableFrom(entityType))
                    {
                        kernel.Bind(typeof (IRepository<>).MakeGenericType(entityType))
                            .To(typeof (PropertyRepository<>).MakeGenericType(entityType));
                    }
                    else
                    {
                        kernel.Bind(typeof(IRepository<>).MakeGenericType(entityType))
                              .To(typeof(BaseRepository<>).MakeGenericType(entityType));

                    }
                }
                    
            }
            kernel.RegisterModule<AdminModule, PortalConfig>();
            kernel.RegisterModule<PaymentsModule, PaymentsConfig>();
            kernel.RegisterModule<MaintenanceModule, MaintenanceConfig>();
            kernel.RegisterModule<CourtesyModule, CourtesyConfig>();
            kernel.RegisterModule<MessagingModule, MessagingConfig>();
            kernel.RegisterModule<PaymentsModule, PaymentsConfig>();
            kernel.RegisterModule<EntrataModule, EntrataConfig>();
            
            //kernel.Bind<IKernel>().ToMethod((v) => kernel).InRequestScope();
            ServiceExtensions.GetServices = () => kernel.GetAll<IService>();

         
            kernel.Bind<IRepository<UserPaymentOption>>().To<PropertyRepository<UserPaymentOption>>().InRequestScope();
            kernel.Bind<IRepository<UserTransaction>>().To<PropertyRepository<UserTransaction>>().InRequestScope();


            //kernel.Bind<EntrataIntegration>().ToSelf().InRequestScope();
            kernel.Bind<IUnitImporter>().To<UnitImporter>().InRequestScope();
            kernel.Bind<IIdentityMessageService>().To<EmailService>().InRequestScope();
            kernel.Bind<AlertsService>().ToSelf().InRequestScope();
            kernel.Bind<Property>().ToMethod(_ => kernel.Get<IUserContext>().CurrentUser.Property).InRequestScope();
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
            //kernel.Bind<IInci>().To<MaintenanceService>().InRequestScope();
            kernel.Bind<IIncidentsService>().To<IncidentsService>().InRequestScope();
            kernel.Bind<DbContext>().ToMethod(_ => _.Kernel.Get<ApplicationDbContext>()).InRequestScope();
            kernel.Bind<IFeedSerivce>().To<FeedSerivce>().InRequestScope();

            kernel.RegisterMappable<Unit, UnitViewModel, UnitService>();
            kernel.RegisterMappable<Building, BuildingViewModel, BuildingService>();
            kernel.RegisterMappable<Message, MessageViewModel, MessagingService>();
            kernel.RegisterMappable<ApplicationUser, UserBindingModel, UserService>();
            kernel.RegisterMappable<MaitenanceRequest, MaintenanceRequestViewModel, MaintenanceService>();
            kernel.RegisterMappable<IncidentReport, IncidentReportViewModel, IncidentsService>();
            kernel.RegisterMappable<CourtesyOfficerCheckin, CourtesyCheckinViewModel, CourtesyOfficerService>();

            kernel.Bind<IServiceFor<NotificationViewModel>>().To<NotificationService>().InRequestScope();

            kernel.Bind<UserManager<ApplicationUser>>().ToSelf().InRequestScope();



#if !JOBS
            kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().InRequestScope();
            kernel.Bind<ISecureDataFormat<AuthenticationTicket>>().To<SecureDataFormat<AuthenticationTicket>>().InRequestScope();
#endif


            //try
            //{
            //    var config = new DbMigrationsConfiguration<ApplicationDbContext>
            //    {
            //        AutomaticMigrationsEnabled = true,
            //        AutomaticMigrationDataLossAllowed = true
            //    };
            //    var migrator = new DbMigrator(config);
            //    if (migrator.GetPendingMigrations().Any())
            //        migrator.Update();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}




        }
    }
    //public sealed class GalleryDbMigrationConfiguration : DbMigrationsConfiguration
    //{
      
       
    //}
}