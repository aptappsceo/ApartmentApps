using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Ninject;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ApartmentApps.Api.Modules
{


    public class MessagingModule : Module<MessagingConfig>, IMenuItemProvider, IAdminConfigurable, IApplyAnalytics
    {
        public IRepository<Message> Messages { get; set; }
        private readonly PropertyContext _context;
        private readonly IEmailService _emailService;
        private readonly IRepository<MessageReceipt> _messageReceipts;
        private readonly AlertsModule _alertsService;

        public MessagingModule(PropertyContext context,IEmailService emailService, IRepository<MessageReceipt> messageReceipts,IRepository<Message> messages, AlertsModule service, IRepository<MessagingConfig> configRepo, IUserContext userContext, IKernel kernel) : base(kernel, configRepo, userContext)
        {
            Messages = messages;
            _context = context;
            _emailService = emailService;
            _messageReceipts = messageReceipts;
            _alertsService = service;
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            if (UserContext.IsInRole("PropertyAdmin") || UserContext.IsInRole("Admin"))
            {
                menuItems.Add(new MenuItemViewModel("Messaging", "fa-envelope")
                {
                    Children = new List<MenuItemViewModel>()
                    {
                        new MenuItemViewModel("New Campaign","fa-plus-square","Entry","Messaging"),
                        new MenuItemViewModel("Campaigns","fa-history","Index","Messaging"),
                    }
                });
            }
        }

        public void SendMessage(object[] ids, MessageViewModel message, string host)
        {
          
            foreach (var item in ids)
            {
                var user = _context.Users.Find(item);
                if (user.Archived) continue;
                // Send the push notification
                _alertsService.SendAlert(user, message.Title, message.Body, "Message", Convert.ToInt32(message.Id), null, "Open to read the full message.");
                // Send the email
                //$"<img src='{host}/{message.Id}/{item}.png' />", Destination = user.Email, Subject = message. }
                SendEmailAsync(message, user, new IdentityMessage() { Subject = message.Title, Body = message.Body, Destination = user.Email}).Wait();
            }
            var messages = this.Kernel.Get<IRepository<Message>>();
            var messageRecord = messages.Find(message.Id);
            if (messageRecord != null)
            {
                messageRecord.SentOn = UserContext.CurrentUser.TimeZone.Now();
                messageRecord.Sent = true;
                messages.Save();
            }

        }
        public async Task SendEmailAsync(MessageViewModel messageRecord,ApplicationUser user, IdentityMessage message)
        {
            await Kernel.Get<IEmailService>().SendAsync(message);
            _messageReceipts.Add(new MessageReceipt()
            {
                UserId = user.Id,
                Error = false,
                ErrorMessage = null,
                MessageId = Convert.ToInt32(messageRecord.Id),
            });
            _messageReceipts.Save();
            //string apiKey = "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";
            //var fromEmail = "noreply@apartmentapps.com";

            //if (!string.IsNullOrEmpty(Config.SendGridApiToken))
            //{
            //    apiKey = Config.SendGridApiToken;
            //    fromEmail = Config.SendFromEmail;
            //}
            //dynamic sg = new SendGridAPIClient(apiKey);

            //Email from = new Email(fromEmail);
            //string subject = message.Subject;
            //Email to = new Email(message.Destination);
            //Content content = new Content("text/html", message.Body);
            //Mail mail = new Mail(from, subject, to, content);

            //dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
            //var status = (HttpStatusCode)response.StatusCode;


            //_messageReceipts.Add(new MessageReceipt()
            //{
            //    UserId = user.Id,
            //    Error = status != HttpStatusCode.Accepted,
            //    ErrorMessage = Config.FullLogging ? response.StatusCode.ToString() + response.Body.ReadAsStringAsync().Result : response.StatusCode.ToString(),
            //    MessageId = Convert.ToInt32(messageRecord.Id),
            //});
            //_messageReceipts.Save();

        }
        public string SettingsController => "MessagingConfig";

        public void ReadMessage(int messageId, string userId)
        {
            var message = _messageReceipts.FirstOrDefault(p => p.MessageId == messageId && p.UserId == userId);
            if (message != null)
            {
                message.Opened = true;
                _messageReceipts.Save();
            }
        }

        public void ApplyAnalytics(AnalyticsModule module, AnalyticsItem analyticsItem, DateTime startDate)
        {
            analyticsItem.NumberMessagesSent =
                module.Repo<Message>().Count(p => p.Sent && p.SentOn > startDate);

        }
    }
}