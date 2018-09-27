using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnyoneTennis.Startup))]
namespace AnyoneTennis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
