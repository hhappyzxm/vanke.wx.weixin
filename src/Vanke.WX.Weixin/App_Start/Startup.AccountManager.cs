using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using Owin;
using SimpleInjector.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin
{
    public partial class Startup
    {
        public void ConfigureAccountManager(IAppBuilder app)
        {
            AccountManager.Register(FindUser, GetUserInfo);
        }

        private async Task<IdentityUser> FindUser(string loginName, string password)
        {
            var admin = await IoC.Container.GetInstance<IAdminService>().LoginAsync(loginName, password);

            return new IdentityUser
            {
                Id = admin.ID,
                UserName = admin.RealName,
                Roles = new List<string> {"Admin"}
            };
        }

        private async Task<ICurrentLogin> GetUserInfo(object key)
        {
            var user = await IoC.Container.GetInstance<IAdminService>().GetByKeyAsync(key);

            return new CurrentLogin
            {
                ID = user.ID,
                UserName = user.RealName
            };
        }
    }
}
