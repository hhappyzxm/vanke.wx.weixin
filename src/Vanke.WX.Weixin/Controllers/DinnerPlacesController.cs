using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;

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
        public async Task<IEnumerable<DinnerPlace>> Get()
        {
            return await _dinnerPlaceService.GetAllAsync();
        }

        /// <summary>
        /// Get dinner place by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<DinnerPlace> Get(long id)
        {
            return await _dinnerPlaceService.GetByKeyAsync(id);
        }
        
        /// <summary>
        /// Insert/Update dinner place
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(DinnerPlace entity)
        {
            if (entity.ID == 0)
            {
                await _dinnerPlaceService.InsertAsync(entity);
            }
            else
            {
                await _dinnerPlaceService.UpdateAsync(entity);
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
