using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.NewFolder1;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Modules.Maintenance;
using Microsoft.AspNet.Identity;
using Ninject;
using RazorEngine.Templating;
using System.Web;

namespace ApartmentApps.Api
{
    [Persistant]
    public class MarketingModuleConfig : GlobalModuleConfig
    {
        [DataType(DataType.Html)]
        public string EngagementEmailTemplate { get; set; }


    }

    public interface IEmailVariableProvider
    {
        string GetVariable(string name);
    }

    public class MessageData : EmailData
    {
        public string Body { get; set; }
    }
    public class ActionEmailData : EmailData
    {

        public string Message { get; set; }
    }

    public class PasswordEmailData : EmailData
    {
        public string NewPassword { get; set; }
        public string Username { get; set; }
    }

    public class MaintenanceCheckinEmailData : ActionEmailData
    {
        public MaintenanceCheckinBindingModel BindingModel { get; set; }
    }
    public class UpdateEmailData : EmailData
    {
        public FeedItemBindingModel FeedItem { get; set; }
        public string Message { get; set; }
    }
    public class EngagementLetterData : EmailData
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }

    [Persistant]
    public class UserAlertsConfig : UserEntity
    {
        [DisplayName("Email Notifications?")]
        public bool EmailNotifications { get; set; }

    }


    public class UserAlertsConfigProvider : UserConfigProvider<UserAlertsConfig>
    {
        public override string Title => "Notifications";

        public UserAlertsConfigProvider(IRepository<UserAlertsConfig> configRepo, IKernel kernel) : base(configRepo, kernel)
        {
        }

        protected override UserAlertsConfig CreateDefaultConfig()
        {
            var defaultConfig = base.CreateDefaultConfig();
            defaultConfig.EmailNotifications = true;
            return defaultConfig;
        }
    }
    /// <summary>
    /// This service is used to handle when push notifications should be sent out.
    /// </summary>
    public class AlertsModule : Module<AlertsModuleConfig>, IMaintenanceSubmissionEvent, IMaintenanceRequestCheckinEvent, IIncidentReportSubmissionEvent, IIncidentReportCheckinEvent
    {
        public PropertyContext Context { get; set; }
        private readonly EmailQueuer _emailQueuer;
        private readonly IRazorEngineService _razorService;
        private readonly IRepository<UserAlertsConfig> _alertsConfigRepo;
        private readonly IMapper<ApplicationUser, UserBindingModel> _userMapper;
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IEmailService _emailService;
        private IPushNotifiationHandler _pushHandler;

        public AlertsModule(EmailQueuer emailQueuer, IRazorEngineService razorService, IRepository<UserAlertsConfig> alertsConfigRepo, IMapper<ApplicationUser, UserBindingModel> userMapper, IKernel kernel, IRepository<ApplicationUser> userRepository, IRepository<AlertsModuleConfig> configRepo, IUserContext userContext, IEmailService emailService, IPushNotifiationHandler pushHandler, PropertyContext context) : base(kernel, configRepo, userContext)
        {
            _emailQueuer = emailQueuer;
            _razorService = razorService;
            _alertsConfigRepo = alertsConfigRepo;
            _userMapper = userMapper;
            _userRepository = userRepository;
            _emailService = emailService;
            _pushHandler = pushHandler;
            Context = context;
        }


        public void FillActions(List<ActionLinkModel> actions, object viewModel)
        {
            if (!UserContext.IsInRole("Admin") && !UserContext.IsInRole("PropertyAdmin")) return;

            var user = viewModel as UserBindingModel;
            if (user != null)
            {
                //paymentsHome.Children.Add(new MenuItemViewModel("Overview", "fa-shopping-cart", "UserPaymentsOverview", "Payments",new {id = UserContext.CurrentUser.Id}));
                actions.Add(new ActionLinkModel("Send Engagement Letter", "SendEngagementLetter", "UserManagement", new { id = user.Id })
                {
                    Icon = "fa-address-card",
                    Group = "Alerts"
                });
            }
        }

        public void MaintenanceRequestSubmited(MaitenanceRequest maitenanceRequest)
        {
            if (maitenanceRequest.User.PropertyId != null)
            {
                var viewUrl = $"http://portal.apartmentapps.com/MaitenanceRequests/Details/{maitenanceRequest.Id}";
#if DEBUG       
                viewUrl = $"http://localhost:58731/MaitenanceRequests/Details/{maitenanceRequest.Id}";
#endif
                var mapper = Kernel.Get<FeedSerivce>();
                SendAlert(maitenanceRequest.User.PropertyId.Value, "Maintenance", "New maintenance request has been created", maitenanceRequest.Message, "Maintenance", maitenanceRequest.Id,
                    new UpdateEmailData()
                    {
                        FeedItem = mapper.ToFeedItemBindingModel(maitenanceRequest),
                        Links = new Dictionary<string, string>() { { "View", viewUrl } },
                    });
            }
        }

        public void MaintenanceRequestCheckin(MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request)
        {
            if (request.User?.PropertyId != null)
            {
                var unitId = request.UnitId;
                if (unitId != null)
                {
                    //var mapper = Kernel.Get<FeedSerivce>();
                    //var mrcm = Kernel.Get<IMapper<MaintenanceRequestCheckin, MaintenanceCheckinBindingModel>>();
                    //var vm = mrcm.ToViewModel(maitenanceRequest);
                    var vm = maitenanceRequest.ToMaintenanceCheckinBindingModel(Kernel.Get<IBlobStorageService>());
                    var users = _userRepository.GetAll().Where(p => p.UnitId == unitId && p.Archived == false).ToArray();
                    var viewUrl = $"http://portal.apartmentapps.com/MaitenanceRequests/Details/{request.Id}";
#if DEBUG                   
                    viewUrl = $"http://localhost:58731/MaitenanceRequests/Details/{request.Id}";
#endif
                    foreach (var item in users)
                    {
                        SendAlert(item, $"Maintenance", "Your maintenance request has been " + request.StatusId, "Maintenance", request.Id, new MaintenanceCheckinEmailData()
                        {
                            BindingModel = vm,
                            Links = new Dictionary<string, string>() { { "View", viewUrl } },
                        });
                    }
                }
            }
        }

       

        public void SendAlert(ApplicationUser user, string title, string message, string type, int relatedId = 0, EmailData email = null, string pushMessage = null)
        {

            var alert = new UserAlert()
            {
                Title = title,
                Message = message,
                CreatedOn = user.Property.TimeZone.Now(),
                RelatedId = relatedId,
                Type = type,
                UserId = user.Id
            };
            Context.UserAlerts.Add(alert);
            Context.SaveChanges();

            if (email != null)
            {
                email.Subject = title;
                email.ToEmail = user.Email;
               
                email.User = _userMapper.ToViewModel(user);
                //var userConfig = _alertsConfigRepo.GetAll().FirstOrDefault(p => p.UserId == user.Id);
                //if (userConfig != null && userConfig.EmailNotifications)
                //{
                    SendEmail(email);
                //}
            }

            _pushHandler.SendToUser(user.Id, new NotificationPayload()
            {
                Action = "View",
                DataId = relatedId,
                DataType = type,
                Message = pushMessage ?? message,
                Title = title
            });

        }
        public void SendAlert(int propertyId, string role, string title, string message, string type, int relatedId = 0, EmailData email = null)
        {
            
            foreach (var item in Context.Users.Where(x => x.Roles.Any(p => p.RoleId == role) && x.Archived == false).ToArray())
            {

                Context.UserAlerts.Add(new UserAlert()
                {
                    Title = title,
                    Message = message,
                    CreatedOn = item.TimeZone.Now(),
                    RelatedId = relatedId,
                    Type = type,
                    UserId = item.Id
                });
                if (email != null)
                {
                    email.Subject = title;
                    email.ToEmail = item.Email;
                    email.User = _userMapper.ToViewModel(item);
                    SendEmail(email);
                  

                  
                    // _emailService.SendAsync(new IdentityMessage() { Body = message, Destination = item.Email, Subject = title });
                }
                _pushHandler.SendToUser(item.Id, new NotificationPayload()
                {
                    Action = "View",
                    DataId = relatedId,
                    DataType = type,
                    Message = message,
                    Title = title
                });

            }
            Context.SaveChanges();


            //_pushHandler.SendToRole(propertyId, role, title);


        }

        public void IncidentReportSubmited(IncidentReport incidentReport)
        {
           

            
                SendAlert(UserContext.PropertyId, "Officer", "An incident report has been submitted", incidentReport.Comments, "Incident", incidentReport.Id);
        }

        public void IncidentReportCheckin(IncidentReportCheckin incidentReportCheckin,
            IncidentReport incidentReport)
        {
            if (incidentReport.User?.PropertyId != null)
            {
                var unitId = incidentReport.UnitId;
                if (unitId != null)
                {
                    var users = _userRepository.GetAll().Where(p => p.UnitId == unitId && !p.Archived).ToArray();
                    foreach (var item in users)
                    {

                        SendAlert(item, $"Incident Report {incidentReport.StatusId}", incidentReport.Comments, "Incident", incidentReport.Id);
                    }
                }

                //SendAlert(incidentReport.User, $"Incident Report {incidentReport.StatusId}", incidentReport.Comments, "Incident", incidentReport.Id);
            }
        }

        public void SendAlert(object[] ids, string title, string message, string type, int relatedId, EmailData email)
        {
            foreach (var id in ids)
            {
                var user = Context.Users.Find(id);
                SendAlert(user, title, message, type, relatedId, email);
            }
        }

        public static IRazorEngineService CreateRazorService()
        {
            var razorEngineService = RazorEngineService.Create();
            razorEngineService.AddTemplate("_Layout", LoadHtmlFile($"ApartmentApps.Modules.Alerts.EmailTemplates._Layout.cshtml"));
            return razorEngineService;
        }

        //public string CreateEmail<TData>(TData data) where TData : EmailData
        //{
        //    var templateType = data.GetType();
        //    var templateName = data.GetType().Name;
        //    data.UserContext = UserContext;
        //    data.Config = Config;


        //    if (!_razorService.IsTemplateCached(templateName, templateType))
        //    {
        //        _razorService.AddTemplate(templateName,
        //            LoadHtmlFile($"ApartmentApps.Modules.Alerts.EmailTemplates.{templateName}.cshtml"));
        //    }
        //    //else
        //    //{
        //    //    return _razorService.Run(templateName, templateType, data);
        //    //}

        //    return _razorService.RunCompile(templateName, templateType, data);
        //}

        public void SendUserEngagementLetter(ApplicationUser user)
        {
            var mapper = Kernel.Get<IMapper<ApplicationUser, UserBindingModel>>();

            SendEmail(new ActionEmailData()
            {

                Subject = $"Your account for {user.Property.Name} is ready!",
                Message = "Your account must be registered in order to submit maintenance requests of any kind for this property.  Click the button below to begin the process.",
                ToEmail = user.Email,
                User = mapper.ToViewModel(user),
                Links = new Dictionary<string, string>()
                 {
                     { "Register Now", "http://portal.apartmentapps.com/Account/Register" }
                 }
            });


        }

        protected override AlertsModuleConfig CreateDefaultConfig()
        {
            return new AlertsModuleConfig()
            {
                DaysBetweenEngagementLetters = 7,
                Enabled = true,

            };
        }

        public void SendEmail<TData>(TData data, bool inBackground = true) where TData : EmailData
        {
            //var queueItems = Kernel.Get<EmailQueuer>();
            _emailQueuer.QueueEmail(data);

        }

        private static string LoadHtmlFile(string resourceName)
        {
            using (Stream stream = typeof(AlertsModule).Assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }

   
    }
}