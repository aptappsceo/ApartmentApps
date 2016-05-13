using System.Threading.Tasks;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;

namespace ApartmentApps.Portal.Controllers
{
    public class MessagingController : AAController
    {
        public IIdentityMessageService MessagingService { get; set; }

        public MessagingController(IIdentityMessageService messagingService, PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
            MessagingService = messagingService;
        }

        public async Task<ActionResult> Index()
        {
            await MessagingService.SendAsync(new IdentityMessage()
            {
                Destination = "micahosborne@gmail.com",
                Body = "Test Message Body",
                Subject = "Test Subject"
            });
            return Content("YUP");
        }
    }
}