using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Controllers
{
    public class DinnerTypesController : GenericApiController
    {
        private readonly IDinnerTypeService _dinnerTypeService = IoC.Container.GetInstance<IDinnerTypeService>();

        /// <summary>
        /// Get all dinner types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<DinnerType>> Get()
        {
            return await _dinnerTypeService.GetAllAsync();
        }

        /// <summary>
        /// Get dinner type by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<DinnerType> Get(int id)
        {
            return await _dinnerTypeService.GetByKeyAsync(id);
        }
        
        /// <summary>
        /// Insert/Update dinner type
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(DinnerType entity)
        {
            if (entity.ID == 0)
            {
                await _dinnerTypeService.InsertAsync(entity);
            }
            else
            {
                await _dinnerTypeService.UpdateAsync(entity);
            }
        }

        /// <summary>
        /// Delete dinner type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _dinnerTypeService.RemoveAsync(id);
        }
    }
}
