using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sensei.Startup))]
namespace Sensei
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
