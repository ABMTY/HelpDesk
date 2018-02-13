using CtrlHelpDesk.Catalogos;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk
{
    public class NotificationComponent
    {
        CtrlZonas control = new CtrlZonas();
        public void RegisterNotification(DateTime currentTime)
        {

            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            notificationHub.Clients.All.notify("added");
            control.RegisterNotification(DateTime.Now);
        }


    }
}