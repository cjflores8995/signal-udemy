using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Hub_01_Broadcast.Hubs
{
    public class BroadcastHub : Hub
    {
        public void BroadcastMessage(string message)
        {
            Clients.All.displayText(message);
        }
    }
}