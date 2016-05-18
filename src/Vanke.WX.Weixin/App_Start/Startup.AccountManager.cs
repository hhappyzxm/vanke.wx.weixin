using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using Owin;
using SimpleInjector.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin
{
    public partial class Startup
    {
        public void ConfigureAccountManager(IAppBuilder app)
        {
            AccountManager.Register(FindUser, GetUserInfo);
        }

        private IdentityUser FindUser(string loginName, string password)
        {
            return IoC.Container.GetInstance<IAccountService>().Login(loginName, password);
        }

        private ICurrentLogin GetUserInfo(object key)
        {
            return IoC.Container.GetInstance<IAccountService>().GetCurrentLogin(key);
        }
    }
}
