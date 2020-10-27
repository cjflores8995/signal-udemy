using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Hub_01_ContadorVisitas.Hubs
{
    public class ContadorHub : Hub
    {
        private static int _visitantes = 0;

        public override async Task OnConnected()
        {
            Interlocked.Increment(ref _visitantes);

            await Clients.Others.Message("Nueva conexión: " + Context.ConnectionId + " | Total visitantes: " + _visitantes);
            await Clients.Caller.Message("Hola bienvenido!");
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Interlocked.Decrement(ref _visitantes);
            return Clients.All.Message(Context.ConnectionId + " se ha desconectado | Total visitantes: " + _visitantes);
        }

        public Task Broadcast(string message)
        {
            return Clients.All.Message(Context.ConnectionId + ">> " + message);
        }
    }
}