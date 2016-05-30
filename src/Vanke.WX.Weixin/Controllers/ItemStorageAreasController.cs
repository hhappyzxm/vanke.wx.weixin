using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Controllers
{
    public class ItemStorageAreasController : GenericApiController
    {
        private readonly IItemStorageAreaService _service = IoC.Container.GetInstance<IItemStorageAreaService>();

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ItemStorageAreaModel>> Get()
        {
            return await _service.GetAllAsync();
        }

        /// <summary>
        /// Get item by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ItemStorageAreaModel> Get(long id)
        {
            return await _service.GetByKeyAsync(id);
        }

        /// <summary>
        /// Insert/Update item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(ItemStorageAreaModel model)
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
        /// Delete item
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
