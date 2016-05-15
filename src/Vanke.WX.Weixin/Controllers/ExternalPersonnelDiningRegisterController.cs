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

    public class ExternalPersonnelDiningRegisterController : GenericApiController
    {
        private readonly IExternalPersonnelDiningRegisterService _externalPersonnelDiningRegisterService = IoC.Container.GetInstance<IExternalPersonnelDiningRegisterService>();

        /// <summary>
        /// Get all admins
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Admin>> Get()
        {
            throw new Exception();
            //return await _externalPersonnelDiningRegisterService.GetAllActiveAdmins();
        }

        /// <summary>
        /// Get admin by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ExternalPersonnelDiningRegisterHistory> Get(int id)
        {
            return await _externalPersonnelDiningRegisterService.GetByKeyAsync(id);
        }
        
        /// <summary>
        /// Insert/Update admin
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(ExternalPersonnelDiningRegisterHistory entity)
        {
            if (entity.ID == 0)
            {
                await _externalPersonnelDiningRegisterService.InsertAsync(entity);
            }
            else
            {
                await _externalPersonnelDiningRegisterService.UpdateAsync(entity);
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
            var entity = await _externalPersonnelDiningRegisterService.GetByKeyAsync(id);
            await _externalPersonnelDiningRegisterService.RemoveAsync(entity);
        }
    }
}
