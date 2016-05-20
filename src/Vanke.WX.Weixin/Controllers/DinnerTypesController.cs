using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

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
        public async Task<IEnumerable<DinnerTypeModel>> Get()
        {
            return await _dinnerTypeService.GetAllAsync();
        }

        /// <summary>
        /// Get dinner type by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<DinnerTypeModel> Get(long id)
        {
            return await _dinnerTypeService.GetByKeyAsync(id);
        }
        
        /// <summary>
        /// Insert/Update dinner type
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(DinnerTypeModel model)
        {
            if (model.ID.Equals(0))
            {
                await _dinnerTypeService.InsertAsync(model);
            }
            else
            {
                await _dinnerTypeService.UpdateAsync(model.ID, model);
            }
        }

        /// <summary>
        /// Delete dinner type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(long id)
        {
            await _dinnerTypeService.RemoveAsync(id);
        }
    }
}
