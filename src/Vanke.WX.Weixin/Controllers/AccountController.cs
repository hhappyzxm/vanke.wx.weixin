using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.EntityFramework;
using EZ.Framework.Integration.Identity;
using EZ.Framework.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.ViewModels;

namespace Vanke.WX.Weixin.Controllers
{
    [RoutePrefix("api/account")]
    [Route("{action}")]
    public class AccountController : GenericApiController
    {
        private readonly IAdminService _adminService = IoC.Container.GetInstance<IAdminService>();
        private IAuthenticationManager AuthenticationManager => Request.GetOwinContext().Authentication;

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login(LoginViewModel viewModel)
        {
            var admin = await _adminService.LoginAsync(viewModel.LoginName, viewModel.Password);

            if (admin != null)
            {
                var identityUser = new IdentityUser
                {
                    Id = admin.ID.ToString(),
                    UserName = admin.RealName,
                    Roles = new List<string> { "Admin" }
                };
                AuthenticationManager.SignIn(identityUser.GenerateUserIdentity());
            }

            return new { Result = admin != null };
        }

        [AllowAnonymous]
        [HttpPost]
        public void Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
