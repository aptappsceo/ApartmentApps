using System;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.API.Service.Controllers.Api
{
    [Authorize]
    public class MessagingController : ApartmentAppsApiController
    {
        private readonly IRepository<Message> _messages;

        public MessagingController(IKernel kernel, IRepository<Message> messages, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            _messages = messages;
        }

        public AlertBindingModel GetMessage(int id)
        {
            var alert = _messages.Find(id);
            return new AlertBindingModel()
            { 
                Id = id,
                RelatedId = id,
                Message = alert.Body,
                Title = alert.Subject,
                CreatedOn = alert.SentOn ?? DateTime.Now,
                Type="Message"
            };
        } 
    }
}