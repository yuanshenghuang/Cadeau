using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cadeau.Startup))]
namespace Cadeau
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
