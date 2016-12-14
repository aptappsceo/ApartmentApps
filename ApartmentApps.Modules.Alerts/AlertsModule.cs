using System;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Ninject;

namespace ApartmentApps.Api
{
    /// <summary>
    /// This service is used to handle when push notifications should be sent out.
    /// </summary>
    public class AlertsModule : Module<AlertsModuleConfig>, IMaintenanceSubmissionEvent, IMaintenanceRequestCheckinEvent, IIncidentReportSubmissionEvent, IIncidentReportCheckinEvent
    {
        public PropertyContext Context { get; set; }
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IEmailService _emailService;
        private IPushNotifiationHandler _pushHandler;

        public AlertsModule(IKernel kernel, IRepository<ApplicationUser> userRepository, IRepository<AlertsModuleConfig> configRepo, IUserContext userContext, IEmailService emailService, IPushNotifiationHandler pushHandler, PropertyContext context) : base(kernel, configRepo, userContext)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _pushHandler = pushHandler;
            Context = context;
        }


        public void MaintenanceRequestSubmited( MaitenanceRequest maitenanceRequest)
        {
            if (maitenanceRequest.User.PropertyId != null)
            {
                SendAlert(maitenanceRequest.User.PropertyId.Value, "Maintenance", "New maintenance request has been created", maitenanceRequest.Message, "Maintenance", maitenanceRequest.Id);
            }
                
            
        }

        public void MaintenanceRequestCheckin( MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request)
        {
            if (request.User?.PropertyId != null)
            {
                var unitId = request.UnitId;
                if (unitId != null)
                {
                    var users = _userRepository.GetAll().Where(p => p.UnitId == unitId).ToArray();
                    foreach (var item in users)
                    {
                        SendAlert(item, $"Maintenance", "Your maintenance request has been " + request.StatusId, "Maintenance", request.Id, true);
                    }
                }
              
            }
        }

        public void SendAlert(ApplicationUser user, string title, string message, string type, int relatedId = 0, bool email = false, string pushMessage = null)
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
            if (email)
            {
                _emailService.SendAsync(new IdentityMessage() { Body = message, Destination = user.Email, Subject = title }).Wait();
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
        public void SendAlert( int propertyId, string role, string title, string message, string type, int relatedId = 0, bool email = false)
        {
            foreach (var item in Context.Users.Where(x => x.Roles.Any(p => p.RoleId == role)))
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
                if (email == true)
                _emailService.SendAsync(new IdentityMessage() {Body = message, Destination = item.Email, Subject = title});
            }

            Context.SaveChanges();
       
            //_pushHandler.SendToRole(propertyId, role, title);

            _pushHandler.SendToRole(propertyId, role, new NotificationPayload()
            {
                Action = "View",
                DataId = relatedId,
                DataType = type,
                Message = message,
                Title = title
            });

        }

        public void IncidentReportSubmited( IncidentReport incidentReport)
        {
            if (incidentReport.User.PropertyId != null)
                SendAlert(incidentReport.User.PropertyId.Value, "Officer", "An incident report has been submitted", incidentReport.Comments, "Incident", incidentReport.Id);
        }

        public void IncidentReportCheckin( IncidentReportCheckin incidentReportCheckin,
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

        public void SendAlert(object[] ids,string title, string message, string type, int relatedId, bool email = false)
        {
            foreach (var id in ids)
            {
                var user = Context.Users.Find(id);
                SendAlert(user, title, message, type, relatedId, email);
            }

        }
    }
}