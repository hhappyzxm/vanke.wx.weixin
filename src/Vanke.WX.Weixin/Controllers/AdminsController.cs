using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Controllers
{
    public class AdminsController : GenericApiController
    {
        private readonly IAdminService _adminService = IoC.Container.GetInstance<IAdminService>();

        /// <summary>
        /// Get all admins
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<AdminModel>> Get()
        {
            return await _adminService.GetAllAsync();
        }

        /// <summary>
        /// Get admin by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AdminModel> Get(int id)
        {
            var admin =  await _adminService.GetByKeyAsync(id);
            admin.Password = "******";

            return admin;
        }

        /// <summary>
        /// Insert/Update admin
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(AdminModel entity)
        {
            if (entity.ID == 0)
            {
                await _adminService.InsertAsync(entity);
            }
            else
            {
               // await _adminService.UpdateAsync(entity);
            }
        }

        /// <summary>
        /// Delete admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(int id)
        {
            var entity = await _adminService.GetByKeyAsync(id);
            await _adminService.RemoveAsync(entity);
        }
    }
}
