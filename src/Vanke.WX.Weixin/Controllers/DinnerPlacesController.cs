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
    public class DinnerPlacesController : GenericApiController
    {
        private readonly IDinnerPlaceService _dinnerPlaceService = IoC.Container.GetInstance<IDinnerPlaceService>();

        /// <summary>
        /// Get all dinner palce
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<DinnerPlaceModel>> Get()
        {
            return await _dinnerPlaceService.GetAllAsync();
        }

        /// <summary>
        /// Get dinner place by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<DinnerPlaceModel> Get(long id)
        {
            return await _dinnerPlaceService.GetByKeyAsync(id);
        }

        /// <summary>
        /// Insert/Update dinner place
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(DinnerPlaceModel model)
        {
            if (model.ID.Equals(0))
            {
                await _dinnerPlaceService.InsertAsync(model);
            }
            else
            {
                await _dinnerPlaceService.UpdateAsync(model.ID, model);
            }
        }

        /// <summary>
        /// Delete dinner place
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(long id)
        {
            await _dinnerPlaceService.RemoveAsync(id);
        }
    }
}
