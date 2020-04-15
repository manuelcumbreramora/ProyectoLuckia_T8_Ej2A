using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CelulaRiego.Startup))]
namespace CelulaRiego
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
