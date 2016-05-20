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
    public class ItemsController : GenericApiController
    {
        private readonly IItemService _itemService = IoC.Container.GetInstance<IItemService>();

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ItemModel>> Get()
        {
            return await _itemService.GetAllAsync();
        }

        /// <summary>
        /// Get item by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ItemModel> Get(long id)
        {
            return await _itemService.GetByKeyAsync(id);
        }
        
        /// <summary>
        /// Insert/Update item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(ItemModel model)
        {
            if (model.ID.Equals(0))
            {
                await _itemService.InsertAsync(model);
            }
            else
            {
                await _itemService.UpdateAsync(model.ID, model);
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
            await _itemService.RemoveAsync(id);
        }
    }
}
