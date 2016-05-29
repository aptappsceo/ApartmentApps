using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

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

    }
    public class MessagingModule : Module<MessagingConfig>, IMenuItemProvider, IAdminConfigurable
    {
        public IRepository<Message> Messages { get; set; }
        private readonly AlertsService _service;

        public MessagingModule(IRepository<Message> messages, AlertsService service, IRepository<MessagingConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
            Messages = messages;
            _service = service;
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            menuItems.Add(new MenuItemViewModel("Messaging","fa-envelope")
            {
                Children = new List<MenuItemViewModel>()
                {
                    new MenuItemViewModel("New Message","fa-plus-square","Index","Messaging")
                }
            });

        }

        public void SendMessage(object[] ids, string subject, string message)
        {
            var entity = new Message()
            {
                FromId = UserContext.UserId,
                SentToCount = ids.Length,
                Subject = subject,
                Body = message,
                SentOn = UserContext.CurrentUser.TimeZone.Now()
            };
            Messages.Add(entity);
            Messages.Save();
            _service.SendAlert(ids, subject, message,"Message",entity.Id);
        }
        public string SettingsController => "MessagingConfig";
    }
}