using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LojaVitual.Web.Startup))]
namespace LojaVitual.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
