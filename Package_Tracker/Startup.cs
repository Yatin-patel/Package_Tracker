using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Package_Tracker.Startup))]
namespace Package_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
