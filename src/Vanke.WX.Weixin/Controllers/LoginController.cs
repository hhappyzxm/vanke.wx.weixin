using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.ViewModels;

namespace Vanke.WX.Weixin.Controllers
{

    public class LoginController : GenericApiController
    {
        private readonly IAdminService _adminService = IoC.Container.GetInstance<IAdminService>();

        [HttpPost]
        [Route("/{controller}/{action}")]
        public async Task<bool> Login(LoginViewModel viewModel)
        {
            var s = IoC.Container.GetInstance<IAdminService>();
            //return new string[] { "11", "22" };
            return true;
        }
    }
}
