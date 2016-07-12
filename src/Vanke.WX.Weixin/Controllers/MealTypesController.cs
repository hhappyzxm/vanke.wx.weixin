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
    public class MealTypesController : GenericApiController
    {
        private readonly IMealTypeService _service = IoC.Container.GetInstance<IMealTypeService>();

        /// <summary>
        /// Get all dinner types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<MealTypeModel>> Get()
        {
            return await _service.GetAllAsync();
        }

        /// <summary>
        /// Get dinner type by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MealTypeModel> Get(long id)
        {
            return await _service.GetByKeyAsync(id);
        }
        
        /// <summary>
        /// Insert/Update dinner type
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(MealTypeModel model)
        {
            if (model.ID.Equals(0))
            {
                await _service.InsertAsync(model);
            }
            else
            {
                await _service.UpdateAsync(model.ID, model);
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
            await _service.RemoveAsync(id);
        }
    }
}
