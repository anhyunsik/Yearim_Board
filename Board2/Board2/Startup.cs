using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Board2.Startup))]
namespace Board2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
