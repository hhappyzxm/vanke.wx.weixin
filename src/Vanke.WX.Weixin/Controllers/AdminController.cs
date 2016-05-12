using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.App_Base;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.ViewModels;

namespace Vanke.WX.Weixin.Controllers
{
    
    public class AdminController : BaseApiController
    {
        private readonly IAdminService _adminService = IoC.Container.GetInstance<IAdminService>();

        public IEnumerable<string> Get()
        {
            var s = IoC.Container.GetInstance<IAdminService>();
            //return new string[] { "11", "22" };

            throw  new Exception();
        }

        public async Task<AdminViewModel> Get(int id)
        {
            throw new Exception();
            //return (AdminViewModel)await _adminService.GetByKeyAsync(id);
        }

        [HttpPost]
        public async Task Post(AdminViewModel viewModel)
        {
            throw new Exception("asdfasdf");
            await _adminService.InsertAsync(ConvertToEntity(viewModel));
        }

        [HttpPut]
        public async Task Put(AdminViewModel viewModel)
        {
            await _adminService.UpdateAsync(ConvertToEntity(viewModel));
        }

        private Admin ConvertToEntity(AdminViewModel viewModel)
        {
            return new Admin
            {
                ID = viewModel.ID,
                User = new User
                {
                    LoginName = viewModel.LoginName,
                    Password = viewModel.Password
                }
            };
        }

        // DELETE api/values/5
        //public async Task Delete(int id)
        //{
            
        //}
    }
}
