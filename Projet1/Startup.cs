using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projet1.Startup))]
namespace Projet1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
