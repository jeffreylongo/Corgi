using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Corgi.Startup))]
namespace Corgi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
