using System;
using System.Threading.Tasks;
using Ejemplo02_Chat.Middleware;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ejemplo02_Chat.Startup))]

namespace Ejemplo02_Chat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR<ConexionChat>("/chatSignalR");
        }
    }
}
