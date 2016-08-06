using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Ninject;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class Message : PropertyEntity
    {
        public string FromId { get; set; }
        [ForeignKey("FromId")]
        public ApplicationUser From
        {
            get;set;
        }
        public int SentToCount { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentOn { get; set; }

        public virtual ICollection<MessageReceipt> MessageReceipts { get; set; }

    }
    [Persistant]
    public class MessageReceipt : PropertyEntity
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User
        {
            get; set;
        }

        public int MessageId { get; set; }

        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }

        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public bool Opened { get; set; }
    }
    public class MessagingModule : Module<MessagingConfig>, IMenuItemProvider, IAdminConfigurable
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
                        new MenuItemViewModel("New Message","fa-plus-square","Index","Messaging"),
                        new MenuItemViewModel("Sent","fa-history","History","Messaging"),
                    }
                });
            }
        }

        public void SendMessage(object[] ids, string subject, string message, string host)
        {
            var entity = new Message()
            {
                FromId = UserContext.UserId,
                SentToCount = ids.Length,
                Subject = subject,
                Body = message ,
                SentOn = UserContext.CurrentUser.TimeZone.Now()
            };
            Messages.Add(entity);
            Messages.Save();
            foreach (var item in ids)
            {
                var user = _context.Users.Find(item);
                // Send the push notification
                _alertsService.SendAlert(user, subject, message, "Message", entity.Id);
                // Send the email
                SendEmailAsync(entity, user, new IdentityMessage() { Body = message + $"<img src='{host}/{entity.Id}/{item}.png' />", Destination = user.Email, Subject = subject }).Wait();
            }
            

        }
        public async Task SendEmailAsync(Message messageRecord,ApplicationUser user, IdentityMessage message)
        {

            string apiKey = "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";
            var fromEmail = "noreply@apartmentapps.com";

            if (!string.IsNullOrEmpty(Config.SendGridApiToken))
            {
                apiKey = Config.SendGridApiToken;
                fromEmail = Config.SendFromEmail;
            }
            dynamic sg = new SendGridAPIClient(apiKey);

            Email from = new Email(fromEmail);
            string subject = message.Subject;
            Email to = new Email(message.Destination);
            Content content = new Content("text/html", message.Body);
            Mail mail = new Mail(from, subject, to, content);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
            var status = (HttpStatusCode)response.StatusCode;

            _messageReceipts.Add(new MessageReceipt()
            {
                UserId = user.Id,
                Error =  status != HttpStatusCode.Accepted,
                ErrorMessage = Config.FullLogging ? response.StatusCode.ToString() + response.Body.ReadAsStringAsync().Result : response.StatusCode.ToString(),
                MessageId = messageRecord.Id,
            });
            _messageReceipts.Save();

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
    }
}