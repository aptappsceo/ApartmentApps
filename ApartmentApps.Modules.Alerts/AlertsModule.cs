using System;
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
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Microsoft.AspNet.Identity;
using Ninject;
using RazorEngine.Templating;

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


    public class MarketingModule : Module<MarketingModuleConfig>
    {
        public MarketingModule(IKernel kernel, IRepository<MarketingModuleConfig> configRepo, IUserContext userContext) : base(kernel, configRepo, userContext)
        {
            Razor = RazorEngineService.Create();
        }

        public IRazorEngineService Razor { get; set; }

        //public string CreateActionEmail(Dictionary<string, string> actions)
        //{
        //    var actionLinks = new StringBuilder();
        //    foreach (var item in actionLinks.)
        //    {

        //    }
        //}

        //public string CreateEmailFromTemplate(string template, Dictionary<string,string> variables)
        //{
        //    return Regex.Replace(template, @"\{\{([a-zA-Z]+?)\}\}",match =>
        //    {
        //        var name = match.Groups[0].Value;
        //        if (variables.ContainsKey(name))
        //        {
        //            return variables[name];
        //        }
        //        var result = EnabledModules.OfType<IEmailVariableProvider>()
        //            .Select(x => x.GetVariable(name))
        //            .FirstOrDefault(x => x != null);
        //        if (result != null)
        //        {
        //            return result;
        //        }
        //        return string.Empty;
        //    });
        //}



        protected override MarketingModuleConfig CreateDefaultConfig()
        {

            //http://www.freeformatter.com/java-dotnet-escape.html
            return new MarketingModuleConfig()
            {
                EngagementEmailTemplate = "<h1>{{Subject}}</h1><p>{{Body}}</p>",
                Enabled = true
            };
        }
    }

    public class EmailData
    {
        public AlertsModuleConfig Config { get; set; }
        public IUserContext UserContext { get; set; }

        public Dictionary<string, string> Links { get; set; } = new Dictionary<string, string>();
        public UserBindingModel User { get; set; }

        public string ToEmail { get; set; }
        public string FromEmail { get; set; }

        public string Subject { get; set; }

    }
    public class ActionEmailData : EmailData
    {

        public string Message { get; set; }
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
            var defaultConfig =  base.CreateDefaultConfig();
            defaultConfig.EmailNotifications = true;
            return defaultConfig;
        }
    }
    /// <summary>
    /// This service is used to handle when push notifications should be sent out.
    /// </summary>
    public class AlertsModule : Module<AlertsModuleConfig>, IMaintenanceSubmissionEvent, IMaintenanceRequestCheckinEvent, IIncidentReportSubmissionEvent, IIncidentReportCheckinEvent, IWebJob
    {
        public PropertyContext Context { get; set; }
        private readonly IRazorEngineService _razorService;
        private readonly IRepository<UserAlertsConfig> _alertsConfigRepo;
        private readonly IMapper<ApplicationUser, UserBindingModel> _userMapper;
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IEmailService _emailService;
        private IPushNotifiationHandler _pushHandler;

        public AlertsModule(IRazorEngineService razorService, IRepository<UserAlertsConfig> alertsConfigRepo, IMapper<ApplicationUser, UserBindingModel> userMapper, IKernel kernel, IRepository<ApplicationUser> userRepository, IRepository<AlertsModuleConfig> configRepo, IUserContext userContext, IEmailService emailService, IPushNotifiationHandler pushHandler, PropertyContext context) : base(kernel, configRepo, userContext)
        {
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
            if (user != null )
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
                var mapper = Kernel.Get<FeedSerivce>();
                SendAlert(maitenanceRequest.User.PropertyId.Value, "Maintenance", "New maintenance request has been created", maitenanceRequest.Message, "Maintenance", maitenanceRequest.Id, 
                    new UpdateEmailData()
                    {
                        FeedItem = mapper.ToFeedItemBindingModel(maitenanceRequest),
                        Links = new Dictionary<string, string>() { { "View", $"http://portal.apartmentapps.com/MaitenanceRequests/Details/{maitenanceRequest.Id}" } },
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
                    var mapper = Kernel.Get<FeedSerivce>();
                    var users = _userRepository.GetAll().Where(p => p.UnitId == unitId && p.Archived == false).ToArray();
                    foreach (var item in users)
                    {
                        SendAlert(item, $"Maintenance", "Your maintenance request has been " + request.StatusId, "Maintenance", request.Id, new UpdateEmailData()
                        {
                            FeedItem = mapper.ToFeedItemBindingModel(maitenanceRequest),

                            Links = new Dictionary<string, string>() { { "View", $"http://portal.apartmentapps.com/MaitenanceRequests/Details/{request.Id}" } },

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
                var userConfig = _alertsConfigRepo.GetAll().FirstOrDefault(p => p.UserId == user.Id);
                if (userConfig == null || userConfig.EmailNotifications)
                {
                    SendEmail(email);
                }
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
            foreach (var item in Context.Users.Where(x => x.Roles.Any(p => p.RoleId == role)).ToArray())
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
                    var userConfig = _alertsConfigRepo.GetAll().FirstOrDefault(p => p.UserId == item.Id);
                    if (userConfig == null || userConfig.EmailNotifications)
                    {
                        SendEmail(email);
                    }

                    _pushHandler.SendToUser(item.Id, new NotificationPayload()
                    {
                        Action = "View",
                        DataId = relatedId,
                        DataType = type,
                        Message = message,
                        Title = title
                    });
                    // _emailService.SendAsync(new IdentityMessage() { Body = message, Destination = item.Email, Subject = title });
                }
                    
            }
            Context.SaveChanges();


            //_pushHandler.SendToRole(propertyId, role, title);


        }

        public void IncidentReportSubmited(IncidentReport incidentReport)
        {
            if (incidentReport.User.PropertyId != null)
                SendAlert(incidentReport.User.PropertyId.Value, "Officer", "An incident report has been submitted", incidentReport.Comments, "Incident", incidentReport.Id);
        }

        public void IncidentReportCheckin(IncidentReportCheckin incidentReportCheckin,
            IncidentReport incidentReport)
        {
            if (incidentReport.User?.PropertyId != null)
            {
                var unitId = incidentReport.UnitId;
                if (unitId != null)
                {
                    var users = _userRepository.GetAll().Where(p => p.UnitId == unitId).ToArray();
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

        public string CreateEmail<TData>(TData data) where TData : EmailData
        {
            var templateType = data.GetType();
            var templateName = data.GetType().Name;
            data.UserContext = UserContext;
            data.Config = Config;

            
            if (!_razorService.IsTemplateCached(templateName, templateType))
            {
                _razorService.AddTemplate(templateName,
                    LoadHtmlFile($"ApartmentApps.Modules.Alerts.EmailTemplates.{templateName}.cshtml"));
            }
            //else
            //{
            //    return _razorService.Run(templateName, templateType, data);
            //}
            
            return _razorService.RunCompile(templateName, templateType, data);
        }

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

        public void SendEmail<TData>(TData data) where TData : EmailData
        {
            if (data.ToEmail != null)
                _emailService.SendAsync(new IdentityMessage()
                {
                    Body = CreateEmail(data),
                    Destination = data.ToEmail,
                    Subject = data.Subject
                }).Wait();
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
       
        public void Execute(ILogger logger)
        {
            var users = _userRepository.GetAll().Where(x=>!x.Archived && x.LastMobileLoginTime == null && x.LastPortalLoginTime == null).ToArray();
            foreach (var user in users)
            {
                if (user.EngagementLetterSentOn == null ||
                    DateTime.UtcNow.Subtract(user.EngagementLetterSentOn.Value).Days >= Config.DaysBetweenEngagementLetters)
                {
                    SendUserEngagementLetter(user);
                    user.EngagementLetterSentOn = DateTime.UtcNow;
                    _userRepository.Save();
                }
            }
        }
    }
}