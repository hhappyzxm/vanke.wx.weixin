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

        private IdentityUser FindUser(string loginName, string password)
        {
            var admin = IoC.Container.GetInstance<IAdminService>().Login(loginName, password);

            if (admin == null)
            {
                return null;
            }
            else
            {
                return new IdentityUser
                {
                    Id = admin.ID,
                    UserName = admin.RealName,
                    Roles = new List<string> {"Admin"}
                };
            }
        }

        private ICurrentLogin GetUserInfo(object key)
        {
            var user = IoC.Container.GetInstance<IAdminService>().GetByKey(key);

            return new CurrentLogin
            {
                ID = user.ID,
                UserName = user.RealName
            };
        }
    }
}
