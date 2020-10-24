using System;
using System.Threading.Tasks;
using Ejemplo01_ContadorVisitas.Middleware;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ejemplo01_ContadorVisitas.Startup))]

namespace Ejemplo01_ContadorVisitas
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //nos permite habilitar la propiedad de json p para consumir informacion se servicios cruzados
            var config = new ConnectionConfiguration();
            //config.EnableJSONP = true;

            app.MapSignalR<Conexion>("/realtime", config);

        }
    }
}
