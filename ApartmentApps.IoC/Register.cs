using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.DataSheets;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Modules.Corporations;
using ApartmentApps.Api.NewFolder1;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Inspections;
using ApartmentApps.Modules.Maintenance;
using ApartmentApps.Modules.Payments;
using ApartmentApps.Modules.Prospect;
//using ApartmentApps.Modules.Inspections;
using ApartmentApps.Portal.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Syntax;


using RazorEngine.Templating;

#if !JOBS
using Ploeh.Hyprlinkr;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Ninject.Web.Common;
#endif
namespace ApartmentApps.IoC
{
    public static class Register
    {

        static Register()
        {
            RegisterAssemblies();
            //ApplicationDbContext.SearchAssemblies.Add(typeof(Forte).Assembly);
        }

        public static void RegisterAssemblies()
        {
            EnsureModuleAssemblies();
        }

        public static void EnsureModuleAssemblies()
        {
            ApplicationDbContext.SearchAssemblies.Clear();
            ApplicationDbContext.SearchAssemblies.Add(typeof (MaitenanceRequest).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (IModule).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (AlertsModule).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (CourtesyModule).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (EntrataModule).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (InspectionsModule).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (MaintenanceModule).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (MessagingModule).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (PaymentsModule).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (YardiModule).Assembly);
            ApplicationDbContext.SearchAssemblies.Add(typeof (ProspectModule).Assembly);
        }

#if JOBS
        public static void InRequestScope<T>(this IBindingWhenInNamedWithOrOnSyntax<T> b)
        {
            b.InSingletonScope();
        }
#endif

        public static void RegisterMapper<TData, TViewModel, TMapper>(this IKernel kernel) where TMapper : IMapper<TData,TViewModel>
        {
            kernel.Bind<IMapper<TData,TViewModel>>().To<TMapper>().InRequestScope();
        }
        public static void RegisterMappable<TModel, TViewModel,TService, TDefaultMapper>(this IKernel kernel) where TModel : class, IBaseEntity, new() where TViewModel : BaseViewModel, new() where TService : StandardCrudService<TModel> where TDefaultMapper : IMapper<TModel, TViewModel>
        {

           kernel.Bind<IMapper<TModel,TViewModel>>().To<TDefaultMapper>().InRequestScope();

            kernel.Bind< IService,
                StandardCrudService <TModel>>()
                .To<TService>().InRequestScope();

            //kernel.Bind<IMapper<TModel, TViewModel>>().To<TService>().InRequestScope();
                //.ToMethod(_ => _.<StandardCrudService<TModel, TViewModel>>())
                //.InRequestScope();
        }

        public static void RegisterModule<TModule, TModuleConfig>( this IKernel kernel ) where TModule : Module<TModuleConfig> where TModuleConfig : class,IModuleConfig, new()
        {
            kernel.Bind<TModule, IModule, ConfigProvider<TModuleConfig>,  Module<TModuleConfig>>().To<TModule>().InRequestScope();
            kernel.Bind<IConfigProvider>().To<TModule>().InRequestScope();
            //kernel.Bind<IRepository<TModuleConfig>>().To<Module<TModuleConfig>.ConfigRepository>().InRequestScope();
        }
        public static void RegisterConfig<TModule, TModuleConfig>(this IKernel kernel) where TModule : Module<TModuleConfig> where TModuleConfig : class, IModuleConfig, new()
        {

            //kernel.Bind<IRepository<TModuleConfig>>().To<Module<TModuleConfig>.ConfigRepository>().InRequestScope();
        }


        public static void RegisterServices(IKernel kernel)
        {
            Kernel = kernel;
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
                    if (typeof (PropertyModuleConfig).IsAssignableFrom(entityType))
                    {
                        kernel.Bind(typeof(IRepository<>).MakeGenericType(entityType))
                           .To(typeof(PropertyRepository<>).MakeGenericType(entityType));

                      
                    }
                    else if (typeof (PropertyEntity).IsAssignableFrom(entityType))
                    {
                        kernel.Bind(typeof (IRepository<>).MakeGenericType(entityType))
                            .To(typeof (PropertyRepository<>).MakeGenericType(entityType)).InRequestScope();
                        kernel.Bind(typeof(IDataSheet<>).MakeGenericType(entityType))
                            .To(typeof(BasePropertyDataSheet<>).MakeGenericType(entityType)).InRequestScope();
                    }
                    else if (typeof(UserEntity).IsAssignableFrom(entityType))
                    {
                        kernel.Bind(typeof(IRepository<>).MakeGenericType(entityType))
                            .To(typeof(UserRepository<>).MakeGenericType(entityType)).InRequestScope();
                    }
                    else
                    {
                        kernel.Bind(typeof(IRepository<>).MakeGenericType(entityType))
                              .To(typeof(BaseRepository<>).MakeGenericType(entityType)).InRequestScope();

                        kernel.Bind(typeof(IDataSheet<>).MakeGenericType(entityType))
                            .To(typeof(BaseDataSheet<>).MakeGenericType(entityType)).InRequestScope();

                    }
                }

            }

            kernel.Bind<IDataSheet<IncidentReport>>().To<IncidentsDataSheet>().InRequestScope();
            kernel.Bind<IDataSheet<IncidentReportStatus>>().To<BaseDataSheet<IncidentReportStatus>>().InRequestScope();
            kernel.Bind<IDataSheet<Property>>().To<PropertyDataSheet>().InRequestScope();
            kernel.Bind<IDataSheet<Corporation>>().To<CorporationDataSheet>().InRequestScope();
            
            kernel.Bind<IRazorEngineService>().ToMethod(x => AlertsModule.CreateRazorService()).InSingletonScope();
            kernel.Bind<IModuleHelper, ModuleHelper>().To<ModuleHelper>().InRequestScope();
            kernel.Bind<IConfigProvider, ConfigProvider<UserAlertsConfig>>().To<UserAlertsConfigProvider>().InRequestScope();
            kernel.RegisterModule<AnalyticsModule, AnalyticsConfig>();
            kernel.RegisterModule<AlertsModule, AlertsModuleConfig>();
            kernel.RegisterModule<ApartmentAppsModule, PortalConfig>();
            kernel.RegisterModule<PaymentsModule, PaymentsConfig>();
            kernel.RegisterModule<MaintenanceModule, MaintenanceConfig>();
            kernel.RegisterModule<MarketingModule, MarketingModuleConfig>();
            kernel.RegisterModule<CourtesyModule, CourtesyConfig>();
            kernel.RegisterModule<MessagingModule, MessagingConfig>();
            //kernel.RegisterModule<PaymentsModule, PaymentsConfig>();
            kernel.RegisterModule<EntrataModule, EntrataConfig>();
            kernel.RegisterModule<ProspectModule,ProspectModuleConfig>();
            kernel.RegisterModule<CompanySettingsModule, CompanySettingsConfig>();

            //kernel.RegisterModule<InspectionsModule, InspectionsModuleConfig>();

            //kernel.Bind<IKernel>().ToMethod((v) => kernel).InRequestScope();
            //ServiceExtensions.GetServices = () => kernel.GetAll<IService>();


            kernel.Bind<IRepository<UserPaymentOption>>().To<PropertyRepository<UserPaymentOption>>().InRequestScope();
            kernel.Bind<IRepository<UserTransaction>>().To<PropertyRepository<UserTransaction>>().InRequestScope();
            //kernel.Bind<IRepository<EmailQueueItem>>().To<PropertyRepository<EmailQueueItem>>().InRequestScope();


            //kernel.Bind<EntrataIntegration>().ToSelf().InRequestScope();
            kernel.Bind<IUnitImporter>().To<UnitImporter>().InRequestScope();
            kernel.Bind<IIdentityMessageService>().To<EmailService>().InRequestScope();

            kernel.Bind<Property>().ToMethod(_ =>
            {
                var implementation = kernel.Get<IUserContext>().CurrentUser.Property;
                CurrentUserDateTime.TimeZone = implementation.TimeZone;
                return implementation;
            }).InRequestScope();
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
            //kernel.Bind<IService>().To<AlertsModule>().InRequestScope();
            kernel.Bind<IMaintenanceService>().To<MaintenanceService>().InRequestScope();
            //kernel.Bind<IInci>().To<MaintenanceService>().InRequestScope();
            kernel.Bind<IIncidentsService>().To<IncidentsService>().InRequestScope();
            kernel.Bind<DbContext>().ToMethod(_ => _.Kernel.Get<ApplicationDbContext>()).InRequestScope();
            kernel.Bind<IFeedSerivce>().To<FeedSerivce>().InRequestScope();

            kernel.RegisterMappable<Unit, UnitViewModel, UnitService, UnitMapper>();
            //kernel.RegisterMappable<Inspection, InspectionViewModel, InspectionsService, InspectionViewModelMapper>();
            kernel.RegisterMappable<Building, BuildingViewModel, BuildingService, BuildingMapper>();
            kernel.RegisterMappable<Message, MessageViewModel, MessagingService, MessageMapper>();
            kernel.RegisterMappable<ApplicationUser, UserBindingModel, UserService, UserMapper>();
            kernel.RegisterMappable<MaitenanceRequest, MaintenanceRequestViewModel, MaintenanceService, MaintenanceRequestMapper>();
            kernel.RegisterMappable<UserLeaseInfo, UserLeaseInfoBindingModel, PaymentsRequestsService, PaymentsRequestsMapper>();
            kernel.RegisterMappable<Invoice, PaymentRequestInvoiceViewModel, InvoicesService, PaymentsRequestsInvoiceMapper>();
            kernel.RegisterMappable<IncidentReport, IncidentReportViewModel, IncidentsService, IncidentReportMapper>();
            kernel.RegisterMappable<CourtesyOfficerCheckin, CourtesyCheckinViewModel, CourtesyOfficerService, CourtesyCheckinMapper>();
            kernel.RegisterMappable<Property, PropertyFormBindingModel, PropertyService, PropertyMapper>();
            kernel.RegisterMappable<ProspectApplication, ProspectApplicationBindingModel, ProspectService,ProspectApplicationMapper>();
            kernel.RegisterMapper<Unit,UnitFormModel,UnitFormMapper>();
            kernel.RegisterMapper<Message,MessageFormViewModel,MessageFormMapper>();
            kernel.RegisterMapper<MaitenanceRequest, MaintenanceRequestEditModel, MaintenanceRequestEditMapper>();
            kernel.RegisterMapper<IncidentReport, IncidentReportFormModel, IncidentReportFormMapper>();
            kernel.RegisterMapper<Message, MessageTargetsViewModel, MessageTargetMapper>();
            kernel.RegisterMapper<ApplicationUser, UserListModel, UserListMapper>();
            kernel.RegisterMapper<ApplicationUser, UserLookupBindingModel, UserLookupMapper>();
            kernel.RegisterMapper<ApplicationUser, LookupBindingModel, ApplicationUserLookupMapper>();
            kernel.RegisterMapper<UserLeaseInfo, EditUserLeaseInfoBindingModel, PaymentsRequestsEditMapper>();
            kernel.RegisterMapper<UserPaymentOption, PaymentOptionBindingModel, PaymentOptionMapper>();
            kernel.RegisterMapper<MaitenanceRequestType, LookupBindingModel, MaintenanceRequestTypeLookupMapper>();
            kernel.RegisterMapper<MaintenanceRequestStatus, LookupBindingModel, MaintenanceRequestStatusLookupMapper>();
            kernel.RegisterMapper<Unit, LookupBindingModel, UnitLookupMapper>();
            kernel.RegisterMapper<Property, PropertyIndexBindingModel, PropertyIndexMapper>();
            kernel.RegisterMapper<IncidentReportStatus, LookupBindingModel, IncidentStatusLookupMapper>();
            kernel.RegisterMapper<Corporation, CorporationIndexBindingModel, CorporationIndexMapper>();
           // kernel.RegisterMapper<Property,PropertyBindingModel,PropertyMapper>();

            //kernel.Bind<IServiceFor<NotificationViewModel>>().To<NotificationService>().InRequestScope();

            kernel.Bind<UserManager<ApplicationUser>>().ToSelf().InRequestScope();

            kernel.Bind<IEmailService>().To<EmailService>().InRequestScope();

         

            kernel.Bind<IDataSheet<MaitenanceRequest>>().To<MaintenanceRequestDataSheet>().InRequestScope();
            kernel.Bind<IDataSheet<MaintenanceRequestStatus>>().To<MaintenanceRequestStatusDataSheet>().InRequestScope();
            kernel.Bind<IDataSheet<Unit>>().To<UnitDataSheet>().InRequestScope();
            kernel.Bind<IDataSheet<MaitenanceRequestType>>().To<MaintenanceRequestTypeDataSheet>().InRequestScope();
            kernel.Bind<IDataSheet<ApplicationUser>>().To<UserDataSheet>().InRequestScope();

            kernel.Bind<ISearchCompiler>().To<SearchCompiler>().InRequestScope();
#if JOBS
            kernel.Bind<IBackgroundScheduler>().To<DefaultBackgroundScheduler>().InRequestScope();
#endif
#if !JOBS
            kernel.Bind<RouteLinker>().ToSelf().InRequestScope();
            kernel.Bind<HttpRequestMessage>()
               .ToMethod(_ => HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage)
               .InRequestScope();

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

        public static IKernel Kernel { get; set; }
    }
    //public sealed class GalleryDbMigrationConfiguration : DbMigrationsConfiguration
    //{



    //}
}
