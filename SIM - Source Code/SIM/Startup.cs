using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIM.Startup))]
namespace SIM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
