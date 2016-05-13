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
    
    public class AdminController : GenericApiController
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
            throw new BusinessException("asf");
            //return (AdminViewModel)await _adminService.GetByKeyAsync(id);
        }

        [HttpPost]
        public async Task Post(AdminViewModel viewModel)
        {
            var newEntity = new Admin
            {
                ID = viewModel.ID,
                LoginName = viewModel.LoginName,
                Password = viewModel.Password
            };

            await _adminService.InsertAsync(newEntity);
        }

        //[HttpPut]
        //public async Task Put(AdminViewModel viewModel)
        //{
        //   await _adminService.UpdateAsync(ConvertToEntity(viewModel));
        //}
        

        // DELETE api/values/5
        //public async Task Delete(int id)
        //{
            
        //}
    }
}
