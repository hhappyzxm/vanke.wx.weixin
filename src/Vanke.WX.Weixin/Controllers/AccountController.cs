using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;
using Vanke.WX.Weixin.ViewModels;

namespace Vanke.WX.Weixin.Controllers
{
    [AllowAnonymous]
    public class AccountController : GenericApiController
    {
        /// <summary>
        /// Get current login user name
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public object Get()
        //{
        //    return new
        //    {
        //        UserName = AccountManager.Instance.CurrentLoginUser.UserName
        //    };
        //}

        [HttpPost]
        [Route("api/account/login")]
        public object Login(LoginViewModel viewModel)
        {
            var currentLogin = (CurrentLogin)AccountManager.Instance.SignIn(viewModel.LoginName, viewModel.Password);

            return new
            {
                IsAuthed = currentLogin != null,
                User = currentLogin
            };
        }

        [HttpPost]
        [Route("api/account/logout")]
        public void Logout()
        {
            AccountManager.Instance.SignOut();
        }
    }
}
