using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gui.Startup))]
namespace gui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
