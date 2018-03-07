using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpDesk.Startup))]
[assembly: OwinStartup(typeof(HelpDesk.Startup))]

namespace HelpDesk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //mapeo de signalR para las notificaciones
            app.MapSignalR();
            /*--------------------------------------*/
        }
    }
}
