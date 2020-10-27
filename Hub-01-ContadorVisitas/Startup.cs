﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hub_01_ContadorVisitas.Startup))]

namespace Hub_01_ContadorVisitas
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR("/realtime", new Microsoft.AspNet.SignalR.HubConfiguration());
        }
    }
}
