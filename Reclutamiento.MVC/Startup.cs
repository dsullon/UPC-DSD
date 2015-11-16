using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reclutamiento.MVC.Startup))]
namespace Reclutamiento.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
