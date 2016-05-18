using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IAccountService : IService
    {
        IdentityUser Login(string loginName, string password);

        CurrentLogin GetCurrentLogin(object userId);
    }
}
