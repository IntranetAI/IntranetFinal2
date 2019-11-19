using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServicioWeb2.Startup))]
namespace ServicioWeb2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
