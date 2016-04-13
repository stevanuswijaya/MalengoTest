using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MalengoTestApplication.View.Startup))]

namespace MalengoTestApplication.View
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
