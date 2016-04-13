using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MalengoTestApplication.Startup))]

namespace MalengoTestApplication
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
