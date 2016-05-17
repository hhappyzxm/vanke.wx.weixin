using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;

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
        public async Task<IEnumerable<Admin>> Get()
        {
            return await _adminService.GetAllAsync();
        }

        /// <summary>
        /// Get admin by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Admin> Get(int id)
        {
            return await _adminService.GetByKeyAsync(id);
        }
        
        /// <summary>
        /// Insert/Update admin
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(Admin entity)
        {
            if (entity.ID == 0)
            {
                await _adminService.InsertAsync(entity);
            }
            else
            {
                await _adminService.UpdateAsync(entity);
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
