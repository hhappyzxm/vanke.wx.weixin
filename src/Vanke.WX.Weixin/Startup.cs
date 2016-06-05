using System.Drawing;
using System.IO;
using System.Web;
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
            var rootPath = HttpRuntime.AppDomainAppPath;
            var tempFolderPath = rootPath + @"Temp";
            var uploadFolderPath = rootPath + @"Upload";

            if (Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(tempFolderPath);
            }
            if (Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            ConfigureSimpleInjector(app);

            ConfigureAuth(app);

            ConfigureWebApi(app);

            ConfigureAccountManager(app);
        }
    }
}
