using Microsoft.Owin;
using Owin;
using System.Threading;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(gui.Startup))]
[assembly: OwinStartup(typeof(gui.Startup))]
namespace gui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
