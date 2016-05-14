using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework;
using EZ.Framework.EntityFramework;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.ViewModels;

namespace Vanke.WX.Weixin.Controllers
{

    public class AdminsController : GenericApiController
    {
        private readonly IAdminService _adminService = IoC.Container.GetInstance<IAdminService>();

        /// <summary>
        /// Get all admins
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Admin>> Get()
        {
            return await _adminService.GetAllAsync();
        }

        /// <summary>
        /// Get admin by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Admin> Get(int id)
        {
            return await _adminService.GetByKeyAsync(id);
        }
        
        /// <summary>
        /// Insert admin
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(Admin entity)
        {
            await _adminService.InsertAsync(entity);
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
