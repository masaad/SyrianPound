using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SyrainPound.Web.Startup))]
namespace SyrainPound.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
