using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Notificaciones.Startup))]
namespace Notificaciones
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
