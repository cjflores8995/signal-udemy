using Notificaciones.Hubs;
using Notificaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Notificaciones.Controllers
{
    public class ValuesController : ApiController
    {
        private NotifEntities context = new NotifEntities();

        [HttpPost]
        public HttpResponseMessage SendNotification(NotifModels obj)
        {
            NotificationHub objNotifHub = new NotificationHub();
            Notification objNotif = new Notification();
            objNotif.SentTo = obj.UserID;
            //objNotif.Details = obj.Message;

            context.Configuration.ProxyCreationEnabled = false;
            context.Notification.Add(objNotif);
            context.SaveChanges();

            objNotifHub.SendNotification(objNotif.SentTo);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
