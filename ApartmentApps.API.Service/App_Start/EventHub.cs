using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ApartmentApps.API.Service.App_Start
{
    public class EventHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        [Authorize]
        public void SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            BroadcastMessage(message);
        }

        private void BroadcastMessage(string message)
        {
            var userName = Context.User.Identity.Name;

            Clients.All.OnMessage(userName, message);

            var excerpt = message.Length <= 3 ? message : message.Substring(0, 3) + "...";
            Clients.All.OnMessage("[someone]", excerpt);
        }
    }
}