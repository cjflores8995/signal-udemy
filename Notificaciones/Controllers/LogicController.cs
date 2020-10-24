using Notificaciones.Hubs;
using Notificaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Notificaciones.Controllers
{
    public class LogicController : Controller
    {
        private NotifEntities context = new NotifEntities();

        public ActionResult SendNotification(NotifModels obj)
        {
            NotificationHub objNotifHub = new NotificationHub();
            Notification objNotif = new Notification();
            objNotif.SentTo = obj.UserID;
            objNotif.Details = obj.Message;

            context.Configuration.ProxyCreationEnabled = false;
            context.Notification.Add(objNotif);
            context.SaveChanges();

            objNotifHub.SendNotification(objNotif.SentTo);

            return Json(new { OK = true, Message = "Transacción realizada correctamente" }, JsonRequestBehavior.AllowGet);
        }
    }
}
