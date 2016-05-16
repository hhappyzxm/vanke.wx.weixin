using Microsoft.Owin;
using Owin;
using Vanke.WX.Weixin;

[assembly: OwinStartup(typeof(Startup))]
namespace Vanke.WX.Weixin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureSimpleInjector(app);

            ConfigureAuth(app);

            ConfigureWebApi(app);

            ConfigureAccountManager(app);
        }
    }
}
