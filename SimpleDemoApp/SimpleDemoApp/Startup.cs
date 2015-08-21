using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleDemoApp.Startup))]
namespace SimpleDemoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
